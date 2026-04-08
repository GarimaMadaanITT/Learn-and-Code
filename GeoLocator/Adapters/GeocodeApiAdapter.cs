using System.Globalization;
using System.Text.Json;
using GeoLocationFetcher.Config;
using GeoLocationFetcher.Interfaces;
using GeoLocationFetcher.Models;

namespace GeoLocationFetcher.Adapters;

public class GeocodeApiAdapter(HttpClient httpClient, GeocodingSettings settings) : IGeocodingProvider
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly GeocodingSettings _settings = settings;

    public async Task<GeocodingResponse> GeocodeAsync(string location, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(_settings.BaseUrl))
        {
            return new GeocodingResponse
            {
                Query = location,
                Success = false,
                ErrorMessage = "Geocoding API base URL is missing. Set GeocodingApi:BaseUrl in appsettings.json."
            };
        }

        var query = Uri.EscapeDataString(location);
        var requestUri = $"{_settings.BaseUrl}?q={query}&format=jsonv2&limit=5";

        try
        {
            using var response = await _httpClient.GetAsync(requestUri, cancellationToken);
            var content = await response.Content.ReadAsStringAsync(cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                return new GeocodingResponse
                {
                    Query = location,
                    Success = false,
                    ErrorMessage = $"Geocoding HTTP error: {(int)response.StatusCode} ({response.StatusCode})."
                };
            }

            using var doc = JsonDocument.Parse(content);
            if (doc.RootElement.ValueKind != JsonValueKind.Array)
            {
                return new GeocodingResponse
                {
                    Query = location,
                    Success = false,
                    ErrorMessage = "Unexpected geocoding response format."
                };
            }

            var results = new List<LocationResult>();
            foreach (var item in doc.RootElement.EnumerateArray())
            {
                var latText = item.TryGetProperty("lat", out var latProperty) ? latProperty.GetString() : null;
                var lonText = item.TryGetProperty("lon", out var lonProperty) ? lonProperty.GetString() : null;

                if (!double.TryParse(latText, CultureInfo.InvariantCulture, out var latitude) ||
                    !double.TryParse(lonText, CultureInfo.InvariantCulture, out var longitude))
                {
                    continue;
                }

                string placeId = string.Empty;
                if (item.TryGetProperty("place_id", out var placeIdProperty))
                {
                    placeId = placeIdProperty.ValueKind switch
                    {
                        JsonValueKind.String => placeIdProperty.GetString() ?? string.Empty,
                        JsonValueKind.Number => placeIdProperty.GetRawText(),
                        _ => string.Empty
                    };
                }

                results.Add(new LocationResult
                {
                    Address = item.TryGetProperty("display_name", out var displayNameProperty)
                        ? displayNameProperty.GetString() ?? string.Empty
                        : string.Empty,
                    PlaceId = placeId,
                    Latitude = latitude,
                    Longitude = longitude
                });
            }

            return new GeocodingResponse
            {
                Query = location,
                Success = true,
                ResultCount = results.Count,
                Results = results
            };
        }
        catch (OperationCanceledException)
        {
            return new GeocodingResponse
            {
                Query = location,
                Success = false,
                ErrorMessage = "Request cancelled."
            };
        }
        catch (HttpRequestException ex)
        {
            return new GeocodingResponse
            {
                Query = location,
                Success = false,
                ErrorMessage = $"Network error while calling geocoding API: {ex.Message}"
            };
        }
        catch (JsonException ex)
        {
            return new GeocodingResponse
            {
                Query = location,
                Success = false,
                ErrorMessage = $"Failed to parse geocoding response: {ex.Message}"
            };
        }
    }
}

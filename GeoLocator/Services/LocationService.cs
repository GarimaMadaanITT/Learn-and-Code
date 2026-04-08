using GeoLocationFetcher.Interfaces;
using GeoLocationFetcher.Models;
using GeoLocationFetcher.Validations;

namespace GeoLocationFetcher.Services;

public class LocationService(IGeocodingProvider provider) : ILocationService
{
    private readonly IGeocodingProvider _provider = provider;

    public async Task<GeocodingResponse> GetLocationAsync(string? location, CancellationToken cancellationToken = default)
    {
        if (!InputValidator.TryValidateLocation(location, out var validationError))
        {
            return new GeocodingResponse
            {
                Query = location?.Trim() ?? string.Empty,
                Success = false,
                ErrorMessage = validationError
            };
        }

        return await _provider.GeocodeAsync(location!.Trim(), cancellationToken);
    }
}

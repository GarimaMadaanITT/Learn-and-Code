namespace GeoLocationFetcher.Models;

public class GeocodingResponse
{
    public string Query { get; init; } = string.Empty;
    public bool Success { get; init; }
    public string? ErrorMessage { get; init; }
    public int ResultCount { get; init; }
    public IReadOnlyList<LocationResult> Results { get; init; } = [];
}

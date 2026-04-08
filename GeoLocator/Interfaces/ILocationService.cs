using GeoLocationFetcher.Models;

namespace GeoLocationFetcher.Interfaces;

public interface ILocationService
{
    Task<GeocodingResponse> GetLocationAsync(string? location, CancellationToken cancellationToken = default);
}

using GeoLocationFetcher.Models;

namespace GeoLocationFetcher.Interfaces;

public interface IGeocodingProvider
{
    Task<GeocodingResponse> GeocodeAsync(string location, CancellationToken cancellationToken = default);
}

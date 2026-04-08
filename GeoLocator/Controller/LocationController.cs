using GeoLocationFetcher.Interfaces;
using GeoLocationFetcher.Models;

namespace GeoLocationFetcher.Controllers;

public class LocationController(ILocationService service)
{
    private readonly ILocationService _service = service;

    public Task<GeocodingResponse> GetLocationAsync(string? input, CancellationToken cancellationToken = default)
    {
        return _service.GetLocationAsync(input, cancellationToken);
    }
}

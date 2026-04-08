namespace GeoLocationFetcher.Models;

public class LocationResult
{
    public string Address { get; set; } = string.Empty;
    public string PlaceId { get; set; } = string.Empty;
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}

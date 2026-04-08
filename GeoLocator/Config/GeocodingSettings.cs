namespace GeoLocationFetcher.Config;

public class GeocodingSettings
{
    public string BaseUrl { get; set; } = "https://nominatim.openstreetmap.org/search";
    public string ApiKey { get; set; } = string.Empty;
}

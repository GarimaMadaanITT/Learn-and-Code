using GeoLocationFetcher.Adapters;
using GeoLocationFetcher.Application;
using GeoLocationFetcher.Config;
using GeoLocationFetcher.Controllers;
using GeoLocationFetcher.Interfaces;
using GeoLocationFetcher.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var configuration = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
    .AddEnvironmentVariables()
    .Build();

var geocodingSettings = configuration.GetSection("GeocodingApi").Get<GeocodingSettings>() ?? new GeocodingSettings();

var services = new ServiceCollection();
services.AddSingleton(geocodingSettings);
services.AddHttpClient<IGeocodingProvider, GeocodeApiAdapter>(client =>
{
    client.Timeout = TimeSpan.FromSeconds(10);
    client.DefaultRequestHeaders.UserAgent.ParseAdd("GeoLocatorApp/1.0");
});
services.AddScoped<ILocationService, LocationService>();
services.AddScoped<LocationController>();
services.AddScoped<App>();

await using var provider = services.BuildServiceProvider().CreateAsyncScope();
var app = provider.ServiceProvider.GetRequiredService<App>();
await app.RunAsync();

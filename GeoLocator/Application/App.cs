using System.Text.Json;
using GeoLocationFetcher.Controllers;
using GeoLocationFetcher.Models;

namespace GeoLocationFetcher.Application;

public class App(LocationController controller)
{
    private readonly LocationController _controller = controller;

    public async Task RunAsync(CancellationToken cancellationToken = default)
    {
        Console.Write("Enter location: ");
        var location = Console.ReadLine();

        GeocodingResponse response = await _controller.GetLocationAsync(location, cancellationToken);

        var output = new
        {
            response.Query,
            response.Success,
            response.ResultCount,
            response.ErrorMessage,
            response.Results
        };

        var json = JsonSerializer.Serialize(output, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        Console.WriteLine(json);
    }
}

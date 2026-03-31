using FinanceTracker.ConsoleClient.Configurations;
using System.Text.Json;

namespace FinanceTracker.ConsoleClient.Infrastructure
{
    public static class SettingsLoader
    {
        public static ApiSettings Load(string settingsFilePath)
        {
            if (!File.Exists(settingsFilePath))
            {
                throw new InvalidOperationException($"Configuration file was not found: {settingsFilePath}");
            }

            var json = File.ReadAllText(settingsFilePath);
            var document = JsonDocument.Parse(json);

            if (!document.RootElement.TryGetProperty("ApiSettings", out var apiSettingsElement))
            {
                throw new InvalidOperationException("ApiSettings section is missing from appsettings.json.");
            }

            var settings = apiSettingsElement.Deserialize<ApiSettings>(CreateSerializerOptions());

            if (settings is null || string.IsNullOrWhiteSpace(settings.BaseUrl))
            {
                throw new InvalidOperationException("ApiSettings:BaseUrl must be provided.");
            }

            return settings;
        }

        private static JsonSerializerOptions CreateSerializerOptions()
        {
            return new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }
    }
}

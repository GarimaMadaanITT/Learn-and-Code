using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using CountryNeighborLookup.Models;

namespace CountryNeighborLookup.Services
{
    public class CountryNeighborReader
    {
        private readonly List<Country> _countries;

        public CountryNeighborReader(string fileName)
        {
            _countries = LoadCountriesFromFile(fileName);
        }

        private static List<Country> LoadCountriesFromFile(string fileName)
        {
            string filePath = Path.Combine(
                AppContext.BaseDirectory,
                "Data",
                fileName
            );

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException(
                    $"Countries JSON file not found at: {filePath}"
                );
            }

            string jsonContent = File.ReadAllText(filePath);

            Dictionary<string, List<string>> countryData =
                JsonSerializer.Deserialize<Dictionary<string, List<string>>>(jsonContent)
                ?? throw new InvalidOperationException("Countries JSON is invalid.");

            List<Country> countries = new List<Country>();

            foreach (KeyValuePair <string, List<string>> entry in countryData)
            {
                var country = new Country
                {
                    Code = entry.Key.ToUpper(),
                    NeighboringCountries = entry.Value ?? new List<string>()
                };

                countries.Add(country);
            }

            return countries;
        }

        public List<string> GetNeighbors(string countryCode)
        {
            if (string.IsNullOrWhiteSpace(countryCode))
                return new List<string>();

            countryCode = countryCode.ToUpper();

            foreach (var country in _countries)
            {
                if (country.Code == countryCode)
                    return country.NeighboringCountries ?? new List<string>();
            }

            return new List<string>();
        }

    }
}

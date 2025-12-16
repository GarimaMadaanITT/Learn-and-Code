using System.Collections.Generic;

namespace CountryNeighborLookup.Models
{
    public class Country
    {
        public string Code { get; set; } = string.Empty;
        public List<string> NeighboringCountries { get; set; } = new();
    }
}

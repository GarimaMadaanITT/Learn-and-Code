using CleanCodeAssignments.Core.Interfaces;
using CleanCodeAssignments.Models;

namespace CleanCodeAssignments.Implementations.Parsers;

public class CsvDataParser : IDataParser
{
    public List<Record> Parse(List<string> rawData)
    {
        var records = new List<Record>();

        foreach (var line in rawData)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;

            var parts = line.Split(',');

            if (parts.Length < 3) continue;

            var record = new Record
            {
                Id = parts[0].Trim(),
                Name = parts[1].Trim(),
                Value = double.TryParse(parts[2], out var val) ? val : 0
            };

            if (parts.Length >= 4 && DateTime.TryParse(parts[3], out var date))
            {
                record.Date = date;
            }

            records.Add(record);
        }

        return records;
    }
}
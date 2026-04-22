using CleanCodeAssignments.Core.Interfaces;
using CleanCodeAssignments.Models;
using System.Text.Json;

namespace CleanCodeAssignments.Exporters;

public class JsonExporter : IDataExporter
{
    public void Export(string path, List<Record> records)
    {
        var json = JsonSerializer.Serialize(records, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText(path, json);
    }
}
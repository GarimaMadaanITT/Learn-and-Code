using CleanCodeAssignments.Core.Interfaces;
using CleanCodeAssignments.Models;

namespace CleanCodeAssignments.Implementations.Writers;

public class CsvDataWriter : IDataWriter
{
    public void Write(string path, List<Record> records)
    {
        var lines = new List<string>
        {
            "ID,NAME,VALUE,DATE,DOUBLED_VALUE,SQUARED_VALUE"
        };

        foreach (var r in records)
        {
            lines.Add($"{r.Id},{r.Name},{r.Value},{r.Date},{r.DoubledValue},{r.SquaredValue}");
        }

        File.WriteAllLines(path, lines);
    }
}
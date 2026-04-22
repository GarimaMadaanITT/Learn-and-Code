using CleanCodeAssignments.Core.Interfaces;
using CleanCodeAssignments.Models;
using System.Xml.Serialization;

namespace CleanCodeAssignments.Exporters;

public class XmlExporter : IDataExporter
{
    public void Export(string path, List<Record> records)
    {
        var serializer = new XmlSerializer(typeof(List<Record>));

        using var writer = new StreamWriter(path);
        serializer.Serialize(writer, records);
    }
}
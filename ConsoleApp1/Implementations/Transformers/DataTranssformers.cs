using CleanCodeAssignments.Core.Interfaces;
using CleanCodeAssignments.Models;

namespace CleanCodeAssignments.Implementations.Transformers;

public class DataTransformer : IDataTransformer
{
    public List<Record> Transform(List<Record> records)
    {
        foreach (var r in records)
        {
            r.Name = r.Name.ToUpper();
        }

        return records;
    }
}
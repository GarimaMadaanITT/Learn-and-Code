using CleanCodeAssignments.Core.Interfaces;
using CleanCodeAssignments.Models;

namespace CleanCodeAssignments.Implementations.Validators;

public class DataValidator : IDataValidator
{
    public List<Record> Validate(List<Record> records)
    {
        return records.Where(r =>
            !string.IsNullOrEmpty(r.Id) &&
            !string.IsNullOrEmpty(r.Name)
        ).ToList();
    }
}
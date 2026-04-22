using System.Collections.Generic;
using CleanCodeAssignments.Models;

namespace CleanCodeAssignments.Core.Interfaces;

public interface IDataValidator
{
    List<Record> Validate(List<Record> records);
}
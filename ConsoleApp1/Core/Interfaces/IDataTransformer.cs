using System.Collections.Generic;
using CleanCodeAssignments.Models;

namespace CleanCodeAssignments.Core.Interfaces;

public interface IDataTransformer
{
    List<Record> Transform(List<Record> records);
}
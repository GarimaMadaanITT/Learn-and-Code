using System.Collections.Generic;
using CleanCodeAssignments.Models;

namespace CleanCodeAssignments.Core.Interfaces;

public interface IDataParser
{
    List<Record> Parse(List<string> rawData);
}
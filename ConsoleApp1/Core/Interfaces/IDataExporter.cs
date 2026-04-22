using System.Collections.Generic;
using CleanCodeAssignments.Models;

namespace CleanCodeAssignments.Core.Interfaces;

public interface IDataExporter
{
    void Export(string path, List<Record> records);
}
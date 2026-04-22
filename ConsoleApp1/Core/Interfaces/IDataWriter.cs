using System.Collections.Generic;
using CleanCodeAssignments.Models;

namespace CleanCodeAssignments.Core.Interfaces;

public interface IDataWriter
{
    void Write(string path, List<Record> records);
}
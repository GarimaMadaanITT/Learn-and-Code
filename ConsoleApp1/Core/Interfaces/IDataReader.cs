using System.Collections.Generic;

namespace CleanCodeAssignments.Core.Interfaces;

public interface IDataReader
{
    List<string> Read(string path);
}
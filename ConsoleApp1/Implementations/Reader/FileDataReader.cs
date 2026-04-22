using CleanCodeAssignments.Core.Interfaces;

namespace CleanCodeAssignments.Implementations.Readers;

public class FileDataReader : IDataReader
{
    public List<string> Read(string path)
    {
        if (!File.Exists(path))
            File.Create(path).Close();

        return new List<string>(File.ReadAllLines(path));
    }
}
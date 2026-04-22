using System.Text;
using CleanCodeAssignments.Core.Interfaces;

namespace CleanCodeAssignments.Utilities;

public class Logger : ILogger
{
    private readonly StringBuilder logBuffer = new StringBuilder();

    public void Log(string message)
    {
        string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        logBuffer.AppendLine($"[{timestamp}] {message}");
    }

    public void Save(string path)
    {
        File.WriteAllText(path, logBuffer.ToString());
    }
}
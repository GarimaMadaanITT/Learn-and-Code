namespace CleanCodeAssignments.Core.Interfaces
{
    public interface ILogger
    {
        void Log(string message);
        void Save(string path);
    }
}
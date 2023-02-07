namespace Core
{
    public interface ILoggerManager : IDisposable
    {
        void LogInfo(string message);
        void LogWarn(string message);
        void LogDebug(string message);
        void LogError(string message);
    }
}
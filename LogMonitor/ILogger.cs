namespace LogMonitor
{    /// <summary>
    /// Logs an error caused by the system
    /// </summary>
    internal interface ILogger
    {
        void LogErrorMessage(string errorMessage);
    }
}
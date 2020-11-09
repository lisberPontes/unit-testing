namespace LogMonitor.UnitTests.Mocks__Handwritten_
{
    internal sealed class MockLogger:ILogger
    {
        public string LastError { get; set; }
        public void LogErrorMessage(string errorMessage)
        {
            LastError = errorMessage;
        }
    }
}
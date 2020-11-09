using System;

namespace LogMonitor
{
    internal sealed class LogAnalyzer: ILogAnalyzer
    {
        private IExtensionManager ExtensionManager { get; }
        private ILogger Logger { get; }
        public DateTime LastInvalidFileNameDate { get; set; }

        public LogAnalyzer(IExtensionManager extensionManager, ILogger logger)
        {
            ExtensionManager = extensionManager;
            Logger = logger;
        }

        public bool IsValidFileName(string fileName)
        {
            if(fileName == null)
                throw new ArgumentNullException(nameof(fileName), "This parameter cannot be null");


            if (ExtensionManager.IsValid(fileName))
            {
                return fileName.StartsWith("Log_");
            }

            LastInvalidFileNameDate = DateTime.UtcNow;

            Logger.LogErrorMessage($"The fileName: {fileName} is invalid!!");

            return false;
        }
    }
}
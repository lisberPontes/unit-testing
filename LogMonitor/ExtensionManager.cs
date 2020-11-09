using System;
using System.Configuration;

namespace LogMonitor
{
    internal sealed class ExtensionManager: IExtensionManager
    {
        public bool IsValid(string fileName)
        {
            var validFileExtension = ConfigurationManager.AppSettings.Get("Valid_Log_File_Name_Extension");

            return fileName.Equals(validFileExtension,StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
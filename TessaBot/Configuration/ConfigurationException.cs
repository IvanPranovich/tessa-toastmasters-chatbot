using System;

namespace TessaBot.Configuration
{
    /// <summary>
    /// Exception to check misconfigured appsettings file.
    /// </summary>
    public class ConfigurationException : Exception
    {
        public ConfigurationException(string configurationXPath)
            :base($"Appsettings is misconfigured. Check {configurationXPath} path value")
        {
            
        }
    }
}
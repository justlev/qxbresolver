using System;
using System.Collections.Generic;
using System.IO;
using Resolver.Services.Configuration;

namespace ResolverConsole
{
    /// <summary>
    /// This is a "storage" for testing purposes.
    /// Of course, we would want to encrypt the keys and values and not simply store them in memory as-is, since then they are observable via different Process Exploring tools. (i.e: SysInternals strings.exe)
    /// This class is just to show that some values should be stored in configuration, and accessed from there.
    /// </summary>
    public class DemoMemoryConfiguration : IConfigurationProvider
    {
        private Dictionary<string, string> _configurationStorage;
        
        public DemoMemoryConfiguration()
        {
            _configurationStorage = new Dictionary<string, string>();
        }

        public void Add(string key, string value)
        {
            _configurationStorage[key] = value;
        }

        public string GetValue(string key)
        {
            return _configurationStorage.ContainsKey(key) ? _configurationStorage[key] : string.Empty;
        }

        public string GetValueByCurrentPlatform(string key)
        {
            var finalKey = string.Empty;
            var osVersion = GetOSVersion();
            switch (osVersion)
            {
                case OSVersion.MacOS:
                {
                    finalKey = key + "_OSX";
                    break;
                }
                case OSVersion.Linux:
                {
                    finalKey = key + "_UNIX";
                    break;
                }
                default:
                {
                    finalKey = key + "";
                    break;
                }
            }

            return GetValue(finalKey);
        }

        /// <summary>
        /// The .NET Core implementation of Environment.Platform and RuntimeServices.OSVersion DO NOT detect MacOS.
        /// </summary>
        /// <returns>Version of the OS</returns>
        private OSVersion GetOSVersion()
        {
            string windir = Environment.GetEnvironmentVariable("windir");
            if (!string.IsNullOrEmpty(windir) && windir.Contains(@"\") && Directory.Exists(windir))
            {
                return OSVersion.Windows;
            }

            if (File.Exists(@"/proc/sys/kernel/ostype"))
            {
                string osType = File.ReadAllText(@"/proc/sys/kernel/ostype");
                if (osType.StartsWith("Linux", StringComparison.OrdinalIgnoreCase))
                {
                    return OSVersion.Linux;
                }
                
            }
            else if (File.Exists(@"/System/Library/CoreServices/SystemVersion.plist"))
            {
                return OSVersion.MacOS;
            }

            return OSVersion.Unknown;
        }

        private enum OSVersion
        {
            Windows,
            Linux,
            MacOS,
            Unknown
        }
    }
}
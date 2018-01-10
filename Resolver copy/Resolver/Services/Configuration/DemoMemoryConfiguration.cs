using System.Collections.Generic;
using System.IO;

namespace Resolver.Services.Configuration
{
    public class DemoMemoryConfiguration : IConfigurationProvider
    {
        private Dictionary<string, string> _configurationStorage;
        
        public DemoMemoryConfiguration()
        {
            _configurationStorage = new Dictionary<string, string>();
            Load();
        }

        private void Load()
        {
            _configurationStorage.Add(ConfigurationKeys.ISAKOV_RESOLVER_PROCESS_CONFIG_KEY, "isakov_mac");
            _configurationStorage.Add(ConfigurationKeys.ISAKOV_RESOLVER_WORKING_DIRECTORY_CONFIG_KEY, Directory.GetCurrentDirectory());
            _configurationStorage.Add(ConfigurationKeys.ISAKOV_RESOLVER_PROCESS_ARGS_CONFIG_KEY, "-s 100 -r 100000");
        }


        public string GetValue(string key)
        {
            return _configurationStorage.ContainsKey(key) ? _configurationStorage[key] : string.Empty;
        }
    }
}
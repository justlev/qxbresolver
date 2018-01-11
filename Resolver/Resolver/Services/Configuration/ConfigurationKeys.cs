namespace Resolver.Services.Configuration
{
    /// <summary>
    /// Better to save string constants in variables.
    /// Even better to use obfuscation, so that keys can't be seen as plain strings via ProcExp, and etc.
    /// </summary>
    public static class ConfigurationKeys
    {
        public static string ISAKOV_INPUT_FILE_NAME = "CONFIG_ISAKOV_SCRIPT_INPUT_FILENAME";
        public const string ISAKOV_RESOLVER_PROCESS_CONFIG_KEY = "CONFIG_ISAKOV_PROCESS";
        public const string ISAKOV_RESOLVER_WORKING_DIRECTORY_CONFIG_KEY = "CONFIG_ISAKOV_WORKING_DIR";
        public const string ISAKOV_RESOLVER_PROCESS_ARGS_CONFIG_KEY = "CONFIG_ISAKOV_PROCESS_ARGS";
    }
}
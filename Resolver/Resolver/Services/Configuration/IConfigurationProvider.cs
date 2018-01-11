namespace Resolver.Services.Configuration
{
    /// <summary>
    /// Sample Configuration interface. Any system has configuration.
    /// </summary>
    public interface IConfigurationProvider
    {
        void Add(string key, string value);
        string GetValue(string key);
        string GetValueByCurrentPlatform(string key);
    }
}
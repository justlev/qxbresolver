namespace Resolver.Services.Configuration
{
    /// <summary>
    /// Simple Configuration interface. Basic functionality.
    /// </summary>
    public interface IConfigurationProvider
    {
        void Add(string key, string value);
        string GetValue(string key);
        string GetValueByCurrentPlatform(string key);
    }
}
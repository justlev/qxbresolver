namespace Resolver.Services.Configuration
{
    public interface IConfigurationProvider
    {
        string GetValue(string key);
    }
}
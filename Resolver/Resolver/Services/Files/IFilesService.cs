
namespace Resolver.Services.Files
{
    /// <summary>
    /// Wrapper around simple IO operations.
    /// Wrapper is mainly useful for testing purposes, since we can Mock it (unlike the static File class provided by .NET).
    /// </summary>
    public interface IFilesService
    {
        string ReadFile(string path);
        void WriteToFile(string path, string content);
    }
}
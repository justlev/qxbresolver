using System.IO;

namespace Resolver.Services.Files
{
    public interface IFilesService
    {
        string ReadFile(string path);
        void WriteToFile(string path, string content);
    }
}
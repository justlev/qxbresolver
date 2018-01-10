using System.IO;

namespace Resolver.Services.Process
{
    public interface IProcessService
    {
        StreamReader StartProcess(string workingDirectoryPath, string processName, string args);
    }
}
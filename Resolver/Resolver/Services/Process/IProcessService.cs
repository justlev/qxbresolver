using System.IO;

namespace Resolver.Services.Process
{
    /// <summary>
    /// Process wrapper. Useful for testing purposes, as it can be mocked.
    /// </summary>
    public interface IProcessService
    {
        StreamReader StartProcess(string workingDirectoryPath, string processName, string args);
    }
}
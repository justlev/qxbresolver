using System.Diagnostics;
using System.IO;

namespace Resolver.Services.Process
{
    public class ProcessService : IProcessService
    {
        public StreamReader StartProcess(string workingDirectoryPath, string processName, string args)
        {
            var processStartInfo = new ProcessStartInfo();
            processStartInfo.WorkingDirectory = workingDirectoryPath;
            processStartInfo.FileName = processName;
            processStartInfo.Arguments = args;
            processStartInfo.RedirectStandardOutput = true;
            var process = System.Diagnostics.Process.Start(processStartInfo);
            return process.StandardOutput;
        }
    }
}
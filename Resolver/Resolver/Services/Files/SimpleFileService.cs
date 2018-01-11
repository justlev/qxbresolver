using System.IO;
using System.Text;

namespace Resolver.Services.Files
{
    public class SimpleFileService : IFilesService
    {
        public void WriteToFile(string path, string content)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            using (var fs = File.OpenWrite(path))
            {
                var encoded = Encoding.UTF8.GetBytes(content); //Can be improved by sending encoding externally.
                fs.Write(encoded, 0, encoded.Length);
                fs.Flush();
            }
        }
    }
}
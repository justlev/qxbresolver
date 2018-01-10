using System.IO;
using System.Text;

namespace Resolver.Services.Files
{
    public class SimpleFileService : IFilesService
    {
        public string ReadFile(string path) //I allow it to throw FileNotFoundException since it's something that has to be reported.
        {
            using (var fs = File.OpenText(path))
            {
                return fs.ReadToEnd();
            }
        }

        public void WriteToFile(string path, string content)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            using (var fs = File.OpenWrite(path))
            {
                var encoded = Encoding.UTF8.GetBytes(content);
                fs.Write(encoded, 0, encoded.Length);
                fs.Flush();
            }
        }
    }
}
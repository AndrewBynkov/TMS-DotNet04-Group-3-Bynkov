using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace APIapplicationCore
{
    /// <inheritdoc cref="IFileService"/>
    public class FileService: IFileService
    {

        public async Task WriteToFileAsync(string text)
        {
            await WriteAsync(text, ConstantsWeather.FileName);
        }

        public async Task WriteToFileAsync(string text, string path)
        {
            await WriteAsync(text, path);
        }

        private async Task WriteAsync(string text, string path)
        {
            try
            {
                using StreamWriter sw = new StreamWriter(path, true, Encoding.Default);
                await sw.WriteLineAsync(text);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

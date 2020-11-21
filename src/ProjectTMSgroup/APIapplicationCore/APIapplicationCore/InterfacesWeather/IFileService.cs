using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APIapplicationCore
{
   public interface IFileService
    {
        /// <summary>
        /// Write to file.
        /// </summary>
        /// <param name="text">Text.</param>
        Task WriteToFileAsync(string text);

        /// <summary>
        /// Write to file.
        /// </summary>
        /// <param name="text">Text.</param>
        /// <param name="path">Path.</param>
        Task WriteToFileAsync(string text, string path);
    }
}

using System;
using APIapplicationCore;

namespace APIapplicationUI
{
    class Program
    {
        private static readonly WeatherManager export = new WeatherManager();

        static void Main(string[] args)
        {
            export.FileExportAsync().GetAwaiter().GetResult();
        }
    }
}

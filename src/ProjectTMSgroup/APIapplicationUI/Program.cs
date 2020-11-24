using APIapplicationCore;
using APIapplicationCore.InterfacesConverter;
using APIapplicationCore.Manager;
using APIapplicationCore.ServicesConverter;
using System;

namespace APIapplicationUI
{
    class Program
    {
        private static readonly WeatherManager export = new WeatherManager();
        private static readonly ConverterManager exportConverter = new ConverterManager();

        static void Main(string[] args)
        {
            ///export.FileExportAsync().GetAwaiter().GetResult();
            exportConverter.GetResultsRequest();
            exportConverter.ReturnCurrency();
        }
    }
}

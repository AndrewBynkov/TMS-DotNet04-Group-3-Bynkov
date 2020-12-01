using APIapplicationCore;
using APIapplicationCore.InterfacesConverter;
using APIapplicationCore.Manager;
using APIapplicationCore.ModelsConverter;
using APIapplicationCore.ServicesConverter;
using System;
using System.Threading.Tasks;

namespace APIapplicationUI
{
    public class Program
    {
        private static readonly UserInput userInput = new UserInput();
        private static readonly ConverterManager convererManager = new ConverterManager();
        private static readonly WeatherManager export = new WeatherManager();
        private static readonly MajorCurrencies major = new MajorCurrencies();


        static void Main(string[] args)
        {
            StartWeather();
            StartConverter();
        }

        public static void StartWeather()
        {
            export.FileExportAsync().GetAwaiter().GetResult();
        }

        public static void StartConverter()
        {
            convererManager.GetResultsRequestAsync().GetAwaiter().GetResult();
        }
    }
}

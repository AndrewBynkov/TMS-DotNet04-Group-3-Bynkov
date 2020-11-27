using APIapplicationCore;
using APIapplicationCore.InterfacesConverter;
using APIapplicationCore.Manager;
using APIapplicationCore.ServicesConverter;
using System;
using System.Threading.Tasks;

namespace APIapplicationUI
{
    class Program
    {
        private static readonly WeatherManager export = new WeatherManager();
        private static readonly ConverterManager exportConverter = new ConverterManager();

        static void Main(string[] args)
        {
            ///StartWeather();
            StartConverter();
        }

        public static void StartWeather()
        {
            export.FileExportAsync().GetAwaiter().GetResult();
        }

        public static void StartConverter()
        {

            Console.Write("\nEnter the name of the currency to get the rate (USD/EUR/RUB): ");
            string currencyUserInput = Console.ReadLine();
            exportConverter.GetResultsRequest();
            exportConverter.GetInfoSelectUserCurrencyToday(currencyUserInput);
            exportConverter.GetInfoSelectUserCurrencyYesturday("RUB");
            exportConverter.CourseDynamics();
            exportConverter.GetInfo();
        }
    }
}

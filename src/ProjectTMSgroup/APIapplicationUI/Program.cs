using APIapplicationCore;
using APIapplicationCore.ModelsConverter;

namespace APIapplicationUI
{
    public class Program
    {
        private static readonly UserInput userInput = new UserInput();
        private static readonly APIapplicationCore.Manager.ConverterManager converterManager = new APIapplicationCore.Manager.ConverterManager(userInput);
        private static readonly WeatherManager export = new WeatherManager();


        static void Main(string[] args)
        {
            //StartWeather();
            StartConverter();
        }

        public static void StartWeather()
        {
            export.FileExportAsync().GetAwaiter().GetResult();
        }

        public static void StartConverter()
        {
            userInput.UserInpAsync().GetAwaiter().GetResult();
            converterManager.GetResultsRequestAsync().GetAwaiter().GetResult();
            converterManager.GetInfoSelectUserCurrencyToday();
            converterManager.GetInfoSelectUserCurrencyYesturday();
            converterManager.CourseDynamics();
        }
    }
}

using APIapplicationCore;
using APIapplicationCore.Manager;
using APIapplicationCore.ModelsConverter;
using System;

namespace APIapplicationUI
{
    public class Program
    {
        private static readonly UserInput userInput = new UserInput();
        private static readonly APIapplicationCore.Manager.ConverterManager converterManager = new APIapplicationCore.Manager.ConverterManager(userInput);
        private static readonly WeatherManager export = new WeatherManager();
        private static readonly NewsManager exportNews = new NewsManager();


        static void Main(string[] args)
        {
            while (true)
            {
                ShowMenu();
                int.TryParse(Console.ReadLine(), out int userInput);
                switch (userInput)
                {
                    case 1:
                        {
                            StartWeather();
                        }
                        break;

                    case 2:
                        {
                            StartConverter();
                        }
                        break;

                    case 3:
                        {
                            StartNews();
                        }
                        break;

                    case 4:
                        {
                            Environment.Exit(0);
                        }
                        break;

                    default:
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Action not found.");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        break;
                }
                Console.WriteLine();
            }
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

        public static void StartNews()
        {
            do
            {
                Console.WriteLine("Enter keywords (topic of the article): ");
                var keyword = Console.ReadLine();
                exportNews.ArticleAsync(keyword).GetAwaiter().GetResult();
            }
            while (Console.ReadKey().Key != ConsoleKey.Enter);
        }
        private static void ShowMenu()
        {
            Console.WriteLine("What would you like to do? Select desired option:");
            Console.WriteLine("1. Weather.");
            Console.WriteLine("2. Currency.");
            Console.WriteLine("3. News.");
            Console.WriteLine("4. Exit.");
        }
    }
}

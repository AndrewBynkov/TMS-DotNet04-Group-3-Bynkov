using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Linq;

namespace APIapplicationCore
{
    /// <summary>
    /// Dynamics export to txt file.
    /// </summary>
    public class WeatherManager
    {
        private readonly IRequestService _requestService;
        private readonly IFileService _fileService;

        public WeatherManager()
        {
            _requestService = new RequestServiсe();
            _fileService = new FileService();

        }
        public async Task FileExportAsync()
        {
            Console.WriteLine("\nEnter city");
            while (true)
            {
                var nameCity = Console.ReadLine();

                var cities = await _requestService.GetExampleSearchAsync(nameCity);

                var result = cities.FirstOrDefault();
                if (result != null)
                {
                    Console.WriteLine(result.title + " " + result.location_type);
                }
                else
                {
                    Console.WriteLine("Try again");
                }
                var weatherResult = await _requestService.GetConsolidatedWeather(result.woeid);
                Console.WriteLine("Weather for today or for a week?");
                {
                    int.TryParse(Console.ReadLine(), out int userInput);
                    switch (userInput)
                    {
                        case 1:
                            {
                                weatherResult.consolidated_weather.FirstOrDefault();
                            }
                            break;

                        case 2:
                            {
                                weatherResult.consolidated_weather.ForEach(weather => Console.WriteLine($"{weather.weather_state_name} and {weather.wind_speed}"));
                            }
                            break;
                    }
                }

            }
        }
    }
}

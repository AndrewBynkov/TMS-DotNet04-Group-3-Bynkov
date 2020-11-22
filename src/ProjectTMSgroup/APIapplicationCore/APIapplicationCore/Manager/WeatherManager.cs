using System;
using System.Threading.Tasks;
using System.Linq;

namespace APIapplicationCore
{
    /// <summary>
    /// Get the city, weather for a day and for several days.
    /// </summary>
    public class WeatherManager
    {
        private readonly IRequestService _requestService;

        public WeatherManager()
        {
            _requestService = new RequestServiсe();
        }
        public async Task FileExportAsync()
        {
            Console.WriteLine("Enter city:");
            do
            {
                var nameCity = Console.ReadLine();

                var cities = await _requestService.GetExampleSearchAsync(nameCity);

                var result = cities.FirstOrDefault();
                if (result != null)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(result.location_type + " " + result.title);
                    Console.ResetColor();
                    Console.WriteLine("GPS coordinates:" + result.latt_long + "\nCity code:" + result.woeid);
                    await GetWeatherDayAsync(result.woeid);
                    await GetWeatherWeekAsync(result.woeid);
                }
                else
                {
                    Console.WriteLine("Try again...");
                }
            }
            while (Console.ReadKey().Key != ConsoleKey.Enter);
        }
        public async Task GetWeatherDayAsync(int woeid)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nToday");
            Console.ResetColor();
            var weatherResult = await _requestService.GetConsolidatedWeather(woeid);
            var dayWeather=weatherResult.consolidated_weather.FirstOrDefault();
            if (weatherResult != null)
            {
                string speed = Convert.ToString(String.Format("{0:F3}", dayWeather.wind_speed));

                Console.WriteLine("Weather states name: " + dayWeather.weather_state_name + "Humidity: " + dayWeather.humidity+"%"+
                    "\nLatest report: " + dayWeather.applicable_date +
                    "\nWind direction and speed: " + dayWeather.wind_direction_compass+ " " + speed + "km/h"+
                    "\nTemperature max/min: " + dayWeather.max_temp + "/" + dayWeather.min_temp + "°C");
            }
            else
            {
                Console.WriteLine("Try again");
            }
        }
        public async Task GetWeatherWeekAsync(int woeid)
        {
            var dateTimeNow = DateTime.Today;
            var dateTime = dateTimeNow.AddDays(+5);
            var weatherResult = await _requestService.GetConsolidatedWeather(woeid);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\nWeather for the next 6 days ({dateTimeNow.ToString("d")} - {dateTime.ToString("d")})");
            Console.ResetColor();
            Console.WriteLine(new string('-', 92));
            Console.WriteLine("|   Date   | Weather states | Temperature,°C | Wind compass | Wind speed,km/h | Humidity,% |");
            Console.WriteLine(new string('-', 92));

            foreach (var item in weatherResult.consolidated_weather)
            {
                string temp = Convert.ToString(String.Format("{0:F3}", item.the_temp));
                string speed = Convert.ToString(String.Format("{0:F3}", item.wind_speed));

                Console.WriteLine("|{0,10}|{1, 16}|{2, 16}|{3, 14}|{4, 17}|{5, 12}|", item.applicable_date, item.weather_state_name, temp, item.wind_direction_compass, speed, item.humidity);
            }
            Console.WriteLine(new string('-', 92));
        }
    }
}

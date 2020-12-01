using APIapplicationCore.InterfacesConverter;
using APIapplicationCore.ModelsConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIapplicationCore.Manager
{
    public class ConverterManager
    {
        private readonly IRequestServerConverter _iRequestServerConverter;

        private readonly ConsoleManager consoleManager = new ConsoleManager();

        public ConverterManager(UserInput userInput)
        {
            _iRequestServerConverter = new ServicesConverter.ConverterManager();
            _userInput = userInput;
        }

        public readonly UserInput _userInput;

        public decimal RateCoursToday { get; set; }

        public decimal RateCourseOnTheDate { get; set; }

        /// <summary>
        /// Result of request List of currensy info  (ID, rate, name, etc.)
        /// </summary>
        public IList<ModelsConverter.ModelsConverter> ListOfCurrencyRatesToday { get; set; }

        /// <summary>
        /// Result of request List of currensy info on the input date (ID, rate, name, etc.)
        /// </summary>
        public IList<ModelsConverter.ModelsConverter> ListOfCurrencyRatesOnTheDate { get; set; }

        /// <summary>
        /// Currency info (user select)
        /// </summary>
        public List<ModelsConverter.ModelsConverter> ListOfCurrencyRatesUserSelectToday { get; set; }

        /// <summary>
        /// Currency info on the input date (user select)
        /// </summary>
        public List<ModelsConverter.ModelsConverter> ListOfCurrencyRatesUserSelectOnTheDate { get; set; }

        public async Task GetResultsRequestAsync()
        {
            ListOfCurrencyRatesToday = await _iRequestServerConverter.RequestServerAsyncGetRateToday();
            ListOfCurrencyRatesOnTheDate = await _iRequestServerConverter.RequestServerAsyncGetRateOnTheDate(_userInput.DateUserInput);
        }

        public void GetInfoSelectUserCurrencyToday()
        {
            ListOfCurrencyRatesUserSelectToday = ListOfCurrencyRatesToday.ToList()
                  .Where(item => item.Cur_Abbreviation == _userInput.CurrencyNameUserInput).ToList();
        }

        public void GetInfoSelectUserCurrencyYesturday()
        {
            ListOfCurrencyRatesUserSelectOnTheDate = ListOfCurrencyRatesOnTheDate.ToList()
                 .Where(item => item.Cur_Abbreviation == _userInput.CurrencyNameUserInput).ToList();
        }

        public void CourseDynamics()
        {
            RateCoursToday = ListOfCurrencyRatesUserSelectToday
                .Select(x => (decimal)x.Cur_OfficialRate)
                .ElementAt(0);

            RateCourseOnTheDate = ListOfCurrencyRatesUserSelectOnTheDate
                .Select(x => (decimal)x.Cur_OfficialRate)
                .ElementAt(0);

            consoleManager.ShowMajorCurrency(ListOfCurrencyRatesToday);
            if (RateCoursToday - RateCourseOnTheDate < 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nExchange rate falls     {RateCoursToday - RateCourseOnTheDate}");
                Console.WriteLine("-------------------------------------");
                Console.WriteLine($"{_userInput.DateUserInput}                     {RateCourseOnTheDate}");
                Console.WriteLine($"{DateTime.Now:yyyy-MM-dd}                    {RateCoursToday}");
                Console.ResetColor();
            }

            if (RateCoursToday - RateCourseOnTheDate > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nThe exchange rate is growing! +{RateCoursToday - RateCourseOnTheDate}");
                Console.WriteLine("-------------------------------------");
                Console.WriteLine($"{_userInput.DateUserInput}                       {RateCourseOnTheDate}");
                Console.WriteLine($"{DateTime.Now:yyyy-MM-dd}                     {RateCoursToday}");
                Console.ResetColor();
            }
        }
    }
}

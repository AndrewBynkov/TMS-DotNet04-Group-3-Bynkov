using APIapplicationCore.InterfacesConverter;
using APIapplicationCore.ModelsConverter;
using APIapplicationCore.ServicesConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIapplicationCore.Manager
{
    public class ConverterManager
    {
        private readonly IRequestServerConverter _iRequestServerConverter;

        public ConverterManager()
        {
            _iRequestServerConverter = new RequestServiceConverter();
        }

        private readonly UserInput userInput = new UserInput();

        public decimal RateCoursToday { get; set; }

        public decimal RateCourseOnTheDate{ get; set; }

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
        public List<ModelsConverter.ModelsConverter> ListOfCurrencyRatesUserSelectYesterday { get; set; }

        public async Task GetResultsRequestAsync()
        {
            ListOfCurrencyRatesToday = await _iRequestServerConverter.RequestServerAsyncGetRateToday();
            ListOfCurrencyRatesOnTheDate = await _iRequestServerConverter.RequestServerAsyncGetRateYesterday(userInput.DateUserInput);
            GetInfoSelectUserCurrencyToday();
            GetInfoSelectUserCurrencyYesturday();
            CourseDynamics();
        }

        public void GetInfoSelectUserCurrencyToday()
        {
            userInput.UserInp();
            while (!ListOfCurrencyRatesToday.Any(item => item.Cur_Abbreviation == userInput.CurrencyNameUserInput))
            {
                Console.Write("Currency incorrect: ");
                userInput.CurrencyNameUserInput = Console.ReadLine().ToUpper();
            }

            ListOfCurrencyRatesUserSelectToday = ListOfCurrencyRatesToday.ToList()
                  .Where(item => item.Cur_Abbreviation == userInput.CurrencyNameUserInput).ToList();
        }

        public void GetInfoSelectUserCurrencyYesturday()
        {
            ListOfCurrencyRatesUserSelectYesterday = ListOfCurrencyRatesOnTheDate.ToList()
                 .Where(item => item.Cur_Abbreviation == userInput.CurrencyNameUserInput).ToList();
        }

        public void CourseDynamics()
        {
            RateCoursToday = ListOfCurrencyRatesUserSelectToday
                .Select(x => (decimal)x.Cur_OfficialRate)
                .ElementAt(0);
        }
    }
}

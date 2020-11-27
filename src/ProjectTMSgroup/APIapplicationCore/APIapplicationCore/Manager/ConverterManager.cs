using APIapplicationCore.InterfacesConverter;
using APIapplicationCore.ServicesConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIapplicationCore.Manager
{
    public class ConverterManager
    {
        public Func<string, IEnumerable<ModelsConverter.ModelsConverter>> start;

        private decimal _rateCoursToday;

        private decimal _rateCoursYesterday;

        /// <summary>
        /// Result of request List of currensy info  (ID, rate, name, etc.)
        /// </summary>
        public IList<ModelsConverter.ModelsConverter> ListOfCurrencyRatesToday { get; set; }

        public IList<ModelsConverter.ModelsConverter> ListOfCurrencyRatesYesterday { get; set; }

        public IEnumerable<ModelsConverter.ModelsConverter> ListOfCurrencyUserSelectRatesToday { get; set; } =
            new List<ModelsConverter.ModelsConverter>();

        public IEnumerable<ModelsConverter.ModelsConverter> ListOfCurrencyUserSelectRatesYesterday { get; set; } =
            new List<ModelsConverter.ModelsConverter>();

        public void GetResultsRequest()
        {
            IRequestServerConverter resultRequest = new ServiceConverter();
            ListOfCurrencyRatesToday = resultRequest.RequestServerAsyncGetRateToday().GetAwaiter().GetResult();
            ListOfCurrencyRatesYesterday = resultRequest.RequestServerAsyncGetRateYesterday().GetAwaiter().GetResult();
        }

        public IEnumerable<ModelsConverter.ModelsConverter> GetInfoSelectUserCurrencyToday(string inpCur)
        {
            while (!ListOfCurrencyRatesToday.Any(item => item.Cur_Abbreviation == inpCur))
            {
                Console.Write("Currency incorrect: ");
                inpCur = Console.ReadLine().ToUpper();
            }

          return ListOfCurrencyUserSelectRatesToday = ListOfCurrencyRatesToday.ToList()
                .Where(item => item.Cur_Abbreviation == inpCur);
        }

        public IEnumerable<ModelsConverter.ModelsConverter> GetInfoSelectUserCurrencyYesturday(string inpCur)
        {
           return ListOfCurrencyUserSelectRatesYesterday = ListOfCurrencyRatesYesterday
                .Where(item => item.Cur_Abbreviation == inpCur);
        }

        public void CourseDynamics()
        {
            var res = Convert.ToDecimal((ListOfCurrencyUserSelectRatesToday.ToList().Select(x => x.Cur_OfficialRate)).ToString());
            var res2 = ListOfCurrencyUserSelectRatesYesterday.ToList().Select(x => x.Cur_OfficialRate);
        }

        public void GetInfo()
        {
            foreach (var item in ListOfCurrencyUserSelectRatesToday)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Exchange rate on the date - {item.Date}");
                Console.ResetColor();
                Console.WriteLine($"Cur abr - {item.Cur_Abbreviation}");
                Console.WriteLine($"Cur name - {item.Cur_Name}");
                Console.WriteLine($"Cur rate - {item.Cur_OfficialRate}\n");
            }

            foreach (var item in ListOfCurrencyUserSelectRatesYesterday)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Exchange rate on the date - {item.Date}");
                Console.ResetColor();
                Console.WriteLine($"Cur abr - {item.Cur_Abbreviation}");
                Console.WriteLine($"Cur name - {item.Cur_Name}");
                Console.WriteLine($"Cur rate - {item.Cur_OfficialRate}");
            }

        }
    }
}

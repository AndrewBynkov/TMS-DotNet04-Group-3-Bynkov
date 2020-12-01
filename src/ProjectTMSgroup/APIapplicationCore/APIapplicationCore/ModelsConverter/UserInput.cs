using APIapplicationCore.InterfacesConverter;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace APIapplicationCore.ModelsConverter
{
    public class UserInput
    {
        private IRequestServerConverter _requestService = new ServicesConverter.ConverterManager();

        public string CurrencyNameUserInput { get; set; }

        public string DateUserInput { get; private set; }

        public async Task UserInpAsync()
        {
            var rateToDay = await _requestService.RequestServerAsyncGetRateToday();

            Console.Write("Enter date for comparison(YY-MM-DD): ");
            DateUserInput = Console.ReadLine();

            Console.Write("Enter the name of the currency to get the rate (USD/EUR/RUB): ");
            CurrencyNameUserInput = Console.ReadLine();

            while (!rateToDay.Any(item => item.Cur_Abbreviation == CurrencyNameUserInput))
            {
                Console.Write("Currency incorrect: ");
                CurrencyNameUserInput = Console.ReadLine().ToUpper();
            }
        }
    }
}

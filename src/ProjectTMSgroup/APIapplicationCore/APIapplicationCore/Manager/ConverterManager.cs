using APIapplicationCore.InterfacesConverter;
using APIapplicationCore.ServicesConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APIapplicationCore.Manager
{
    public class ConverterManager
    {
        public IList<ModelsConverter.ModelsConverter> ListOfCurrencyRates { get; set; }

        public void GetResultsRequest()
        {
            IRequestServerConverter resultRequest = new ServiceConverter();
            ListOfCurrencyRates = resultRequest.RequestServerAsync().GetAwaiter().GetResult();
        }

        public void ReturnCurrency()
        {
            var modelsConverter = new ModelsConverter.ModelsConverter();

            var result = ListOfCurrencyRates.ToList().Select(n => n.Cur_Abbreviation = "BYN");
            foreach (var item in result)
            {
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}

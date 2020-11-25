using APIapplicationCore.InterfacesConverter;
using APIapplicationCore.ServicesConverter;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APIapplicationCore.Manager
{
    public class ConverterManager
    {
        /// <summary>
        /// List of currensy info (ID, rate, name, etc.)
        /// </summary>
        public IList<ModelsConverter.ModelsConverter> ListOfCurrencyRates { get; set; }

        public void GetResultsRequest()
        {
            IRequestServerConverter resultRequest = new ServiceConverter();
            ListOfCurrencyRates = resultRequest.RequestServerAsync().GetAwaiter().GetResult();
        }

        public void ReturnSelectCurrency(string inpCur)
        {
            while (!ListOfCurrencyRates.Any(item => item.Cur_Abbreviation == inpCur))
            {
                Console.Write("Currency incorrect: ");
                inpCur = Console.ReadLine().ToUpper();
            }

            var result = ListOfCurrencyRates.Where(n => n.Cur_Abbreviation == inpCur);

            foreach (var item in result)
            {
                Console.WriteLine($"\nCurrency abbriviation - {item.Cur_Abbreviation}\n" +
                    $"ID - {item.Cur_ID}\n" +
                    $"Currensy name - {item.Cur_Name}\n" +
                    $"Rate - {item.Cur_OfficialRate}\n" +
                    $"Date - {item.Date}");
            }
        }
    }
}

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
            if (!ListOfCurrencyRates.Any(n => n.Cur_Abbreviation.StartsWith(inpCur)))
            {
                var result = ListOfCurrencyRates.Where(n => n.Cur_Abbreviation == inpCur);

                foreach (var item in result)
                {
                    Console.WriteLine($"Currency abbriviation - {item.Cur_Abbreviation}\n" +
                        $"ID - {item.Cur_ID}\n" +
                        $"Currensy name - {item.Cur_Name}\n" +
                        $"Rate - {item.Cur_OfficialRate}\n" +
                        $"Date - {item.Date}");
                }
            }
            else
            {
                Console.WriteLine("not currensy");
            }
        }
    }
}

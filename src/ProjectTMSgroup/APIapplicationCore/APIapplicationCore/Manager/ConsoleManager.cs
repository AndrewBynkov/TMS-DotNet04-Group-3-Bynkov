using System;
using System.Collections.Generic;
using System.Linq;

namespace APIapplicationCore.Manager
{
    public class ConsoleManager
    {
        public void ShowMajorCurrency(IList<ModelsConverter.ModelsConverter> listOfCurrencyRatesToday)
        {
            var coursUSDtoDay = listOfCurrencyRatesToday.Where(item => item.Cur_Abbreviation == "USD").ToList();
            var coursEURtoDay = listOfCurrencyRatesToday.Where(item => item.Cur_Abbreviation == "EUR").ToList();
            var coursRUBtoDay = listOfCurrencyRatesToday.Where(item => item.Cur_Abbreviation == "RUB").ToList();

            foreach (var USD in coursUSDtoDay)
            {
                foreach (var EUR in coursEURtoDay)
                {
                    foreach (var RUB in coursRUBtoDay)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"\nInformation on date - {EUR.Date} National Bank of the Republic of Belarus");
                        Console.WriteLine("--------------------------");
                        Console.WriteLine($"  {USD.Cur_Abbreviation}  |  {EUR.Cur_Abbreviation}   |   {RUB.Cur_Abbreviation}  |");
                        Console.WriteLine($"{USD.Cur_OfficialRate} | {EUR.Cur_OfficialRate} | {RUB.Cur_OfficialRate} |");
                        Console.ResetColor();
                    }
                }
            }
        }
    }
}

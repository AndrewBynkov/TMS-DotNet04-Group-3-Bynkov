using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APIapplicationCore.Manager
{
    public class ConsoleManager
    {
        public ConsoleManager(ConverterManager converterManager)
        {
            _converterManager = converterManager;
        }

        private ConverterManager _converterManager;

        public void OutputConsole()
        {
            var coursUSDtoDay = _converterManager.ListOfCurrencyRatesToday.Where(item => item.Cur_Abbreviation  == "USD").ToList();
            var coursEURtoDay = _converterManager.ListOfCurrencyRatesToday.Where(item => item.Cur_Abbreviation  == "EUR").ToList();
            var coursRUBtoDay = _converterManager.ListOfCurrencyRatesToday.Where(item => item.Cur_Abbreviation  == "RUB").ToList();
        }
    }
}

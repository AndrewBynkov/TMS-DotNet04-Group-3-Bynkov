using APIapplicationCore.InterfacesConverter;
using APIapplicationCore.ServicesConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIapplicationCore.ModelsConverter
{
    public class MajorCurrencies
    {
        private readonly IRequestServerConverter _iRequestServerConverter;

        public MajorCurrencies()
        {
            _iRequestServerConverter = new RequestServiceConverter();
        }

        private string _abbrivCurUSD;
        private string _nameCurUSD;
        private decimal _rateCurUSD;

        private string _abbrivCurEUR;
        private string _nameCurEUR;
        private decimal _rateCurEUR;

        private string _abbrivCurRUB;
        private string _nameCurRUB;
        private decimal _rateCurRUB;

        public void GetResultsRequestAsyncMajorCurrencies()
        {
            var curUSD = _iRequestServerConverter.RequestServerAsyncGetRateUSD().GetAwaiter().GetResult().ToList();
            var curEUR = _iRequestServerConverter.RequestServerAsyncGetRateEUR().GetAwaiter().GetResult();
            var curRUB = _iRequestServerConverter.RequestServerAsyncGetRateRUB().GetAwaiter().GetResult();


            _abbrivCurUSD = curUSD.Select(x => x.Cur_Abbreviation).ElementAt(0);
            _nameCurUSD = curUSD.Select(x => x.Cur_Name).ElementAt(0);
            _rateCurUSD = curUSD.Select(x => (decimal)x.Cur_OfficialRate).ElementAt(0);

            _abbrivCurEUR = curUSD.Select(x => x.Cur_Abbreviation).ElementAt(0);
            _nameCurEUR = curUSD.Select(x => x.Cur_Name).ElementAt(0);
            _rateCurEUR = curUSD.Select(x => (decimal)x.Cur_OfficialRate).ElementAt(0);

            _abbrivCurRUB = curUSD.Select(x => x.Cur_Abbreviation).ElementAt(0);
            _nameCurRUB = curUSD.Select(x => x.Cur_Name).ElementAt(0);
            _rateCurRUB = curUSD.Select(x => (decimal)x.Cur_OfficialRate).ElementAt(0);
        }

        public void ScreenControllerMainCurrenciesAsync()
        {
            Console.Write($"Abbriviation    | {_abbrivCurEUR} | {_abbrivCurRUB} | {_abbrivCurRUB} |");
            Console.Write($"Name currensy {_nameCurEUR} | ");
            Console.Write($"Name currensy {_nameCurUSD} | ");
            Console.Write($"Name currensy {_nameCurRUB} | ");
            ///https://www.nbrb.by/api/exrates/rates/USD?parammode=2
        }
    }
}

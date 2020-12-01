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
            var curUSD = _iRequestServerConverter.RequestServerAsyncGetRateUSD().GetAwaiter().GetResult();
            var curEUR = _iRequestServerConverter.RequestServerAsyncGetRateEUR().GetAwaiter().GetResult();
            var curRUB = _iRequestServerConverter.RequestServerAsyncGetRateRUB().GetAwaiter().GetResult();
        }
    }
}

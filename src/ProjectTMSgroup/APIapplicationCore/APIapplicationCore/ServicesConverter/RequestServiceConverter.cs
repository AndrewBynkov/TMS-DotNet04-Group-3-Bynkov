using APIapplicationCore.ConstantsCoverter;
using APIapplicationCore.InterfacesConverter;
using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APIapplicationCore.ServicesConverter
{
    public class RequestServiceConverter : IRequestServerConverter
    {
        public async Task<IList<ModelsConverter.ModelsConverter>> RequestServerAsyncGetRateToday()
        {
            return await CommonConverterUrl.UrlConverter
               .AppendPathSegments("/api/exrates/rates")
               .SetQueryParams(new { periodicity = 0 })
               .GetJsonAsync<IList<ModelsConverter.ModelsConverter>>();
        }

        public async Task<IList<ModelsConverter.ModelsConverter>> RequestServerAsyncGetRateYesterday(string userInputDate)
        {
            return await CommonConverterUrl.UrlConverter
               .AppendPathSegments("/api/exrates/rates")
               .SetQueryParams(new { ondate = userInputDate, periodicity = 0 })
               .GetJsonAsync<IList<ModelsConverter.ModelsConverter>>();
        }

        public async Task<IList<ModelsConverter.ModelsConverter>> RequestServerAsyncGetRateUSD()
        {
            return await CommonConverterUrl.UrlConverter
                .AppendPathSegments("/api/exrates/rates/USD")
                .SetQueryParams(new { parammode = 2 })
                .GetJsonAsync<List<ModelsConverter.ModelsConverter>>();
        }

        public async Task<IList<ModelsConverter.ModelsConverter>> RequestServerAsyncGetRateEUR()
        {
            return await CommonConverterUrl.UrlConverter
                .AppendPathSegments("/api/exrates/rates/EUR")
                .SetQueryParams(new { parammode = 2 })
                .GetJsonAsync<IList<ModelsConverter.ModelsConverter>>();
        }

        public async Task<IList<ModelsConverter.ModelsConverter>> RequestServerAsyncGetRateRUB()
        {
            return await CommonConverterUrl.UrlConverter
                .AppendPathSegments("/api/exrates/rates/RUB")
                .SetQueryParams(new { parammode = 2 })
                .GetJsonAsync<IList<ModelsConverter.ModelsConverter>>();
        }
    }
}
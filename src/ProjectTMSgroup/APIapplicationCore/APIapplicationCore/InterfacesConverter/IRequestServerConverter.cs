using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APIapplicationCore.InterfacesConverter
{
    public interface IRequestServerConverter
    {
        public Task<IList<ModelsConverter.ModelsConverter>> RequestServerAsyncGetRateToday();

        public Task<IList<ModelsConverter.ModelsConverter>> RequestServerAsyncGetRateYesterday(string date);

        public Task<IList<ModelsConverter.ModelsConverter>> RequestServerAsyncGetRateUSD();

        public Task<IList<ModelsConverter.ModelsConverter>> RequestServerAsyncGetRateEUR();

        public Task<IList<ModelsConverter.ModelsConverter>> RequestServerAsyncGetRateRUB();
    }
}

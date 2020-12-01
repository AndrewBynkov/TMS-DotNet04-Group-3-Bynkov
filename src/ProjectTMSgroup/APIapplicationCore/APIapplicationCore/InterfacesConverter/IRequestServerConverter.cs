using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIapplicationCore.InterfacesConverter
{
    public interface IRequestServerConverter
    {
        public Task<IList<ModelsConverter.ModelsConverter>> RequestServerAsyncGetRateToday();

        public Task<IList<ModelsConverter.ModelsConverter>> RequestServerAsyncGetRateOnTheDate(string userInputDate);

        public Task<IList<ModelsConverter.ModelsConverter>> RequestServerAsyncGetRateUSD();

        public Task<IList<ModelsConverter.ModelsConverter>> RequestServerAsyncGetRateEUR();

        public Task<IList<ModelsConverter.ModelsConverter>> RequestServerAsyncGetRateRUB();
    }
}

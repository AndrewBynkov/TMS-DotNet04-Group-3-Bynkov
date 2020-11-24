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
    public class ServiceConverter : IRequestServerConverter
    {
        public async Task<IList<ModelsConverter.ModelsConverter>> RequestServerAsync()
        {
            return await CommonConverterUrl.UrlConverter
               .AppendPathSegments("/api/exrates/rates")
               .SetQueryParams(new { periodicity = 0 })
               .GetJsonAsync<IList<ModelsConverter.ModelsConverter>>();
        }
    }
}

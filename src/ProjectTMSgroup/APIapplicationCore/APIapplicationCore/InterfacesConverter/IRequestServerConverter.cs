using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APIapplicationCore.InterfacesConverter
{
    public interface IRequestServerConverter
    {
        public Task<IList<ModelsConverter.ModelsConverter>> RequestServerAsync();
    }
}

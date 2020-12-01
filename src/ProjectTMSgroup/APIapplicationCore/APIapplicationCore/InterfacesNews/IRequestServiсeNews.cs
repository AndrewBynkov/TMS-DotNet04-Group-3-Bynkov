using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIapplicationCore.InterfacesNews
{
    /// <summary>
    /// Service for working with requests.
    /// </summary>
    public interface IRequestServiceNews
    {
        /// <summary>
        /// Search articles by keywords.
        /// </summary>
        /// <param name="keyword">  .</param>
        /// <returns>Currency.</returns>
        Task<ModelsNews.RootObject> GetListAtricleSearchAsync(string keyword);
    }
}

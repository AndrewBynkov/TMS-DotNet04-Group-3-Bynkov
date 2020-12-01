using APIapplicationCore.InterfacesNews;
using Flurl;
using Flurl.Http;
using System;
using System.Threading.Tasks;


namespace APIapplicationCore.ServicesNews
{
    /// <inheritdoc cref="IRequestedServiseNews"/>

    public class RequestServiсeNews : IRequestServiceNews
    {
        public async Task<ModelsNews.RootObject> GetListAtricleSearchAsync(string keyword)
        {
            try
            {
                return await "http://api.nytimes.com/svc/search/v2/articlesearch.json"
                    .SetQueryParam("q", keyword)
                    .SetQueryParam("api-key", "LqABtGExaMpoqC9V3MzCZbGB99grEi2D")
                    .GetJsonAsync<ModelsNews.RootObject>();
            }
            catch (FlurlHttpTimeoutException)
            {
                Console.WriteLine("Request timed out.");
            }
            catch (FlurlHttpException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}


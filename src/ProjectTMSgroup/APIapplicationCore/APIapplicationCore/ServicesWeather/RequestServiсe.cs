using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace APIapplicationCore
{
    /// <inheritdoc cref="IRequestedServise"/>

    public class RequestServiсe : IRequestService
    {
        public async Task<List<ExampleSearch>> GetExampleSearchAsync(string city)
        {
            try
            {
                var response = await ConstantsWeather.Url
                    .AppendPathSegment("location/search/")
                    .SetQueryParam("query", city)
                    .GetJsonAsync<List<ExampleSearch>>();
                return response;
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
        public async Task<ConsolidatedWeatherResponse> GetConsolidatedWeather (int woeid)
        {
            try
            {
                var response = await ConstantsWeather.Url
                    .AppendPathSegments("location", woeid )
                    .GetJsonAsync<ConsolidatedWeatherResponse>();
                return response;
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


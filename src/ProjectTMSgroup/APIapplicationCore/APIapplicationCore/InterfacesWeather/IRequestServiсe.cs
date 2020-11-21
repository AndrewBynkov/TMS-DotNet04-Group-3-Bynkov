using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APIapplicationCore
{
        /// <summary>
        /// Service for working with requests.
        /// </summary>
        public interface IRequestService
    {
        /// <summary>
        /// Get specific currency.
        /// </summary>
        /// <param name="code">Currency code.</param>
        /// <returns>Currency.</returns>
        Task<List<ExampleSearch>> GetExampleSearchAsync(string city);

        /// <summary>
        /// Get all currencies.
        /// </summary>
        /// <returns>All currencies.</returns>
        Task<ConsolidatedWeatherResponse> GetConsolidatedWeather(int woeid);

    }
}

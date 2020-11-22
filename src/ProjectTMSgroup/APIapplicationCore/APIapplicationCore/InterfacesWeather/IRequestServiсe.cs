using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIapplicationCore
{
    /// <summary>
    /// Service for working with requests.
    /// </summary>
    public interface IRequestService
    {
        /// <summary>
        /// Get specific city.
        /// </summary>
        /// <param name="city">City woeid.</param>
        /// <returns>Currency.</returns>
        Task<List<ModelsWeather.ExampleSearch>> GetExampleSearchAsync(string city);

        /// <summary>
        /// Get city weather.
        /// </summary>
        /// <returns>All weather for 6 days.</returns>
        Task<ConsolidatedWeatherResponse> GetConsolidatedWeather(int woeid);
    }
}

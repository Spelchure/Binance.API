using Binance.API.Client.Interfaces;

namespace Binance.API.Client.Abstract
{
    /// <summary>
    /// Abstract definition of BinanceClient.
    /// </summary>
    public abstract class AbsBinanceClient
    {

        /// <summary>
        /// Client to be used to call API.
        /// </summary>
        public readonly IApiClient _apiClient;
       
        /// <summary>
        /// Constructor of Binance Client.
        /// </summary>
        /// <param name="apiClient">Client to be used to call API.</param>
        public AbsBinanceClient(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }
    }
}

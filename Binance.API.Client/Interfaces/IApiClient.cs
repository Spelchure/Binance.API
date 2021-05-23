using System.Threading.Tasks;
using Binance.API.Models.Enums;

namespace Binance.API.Client.Interfaces
{
    /// <summary>
    /// Interface for ApiClient
    /// </summary>    
    public interface IApiClient
    {

        /// <summary>
        /// Calls API Method asynchronously.
        /// </summary>
        /// <typeparam name="T">Type to which the response content will be converted.</typeparam>
        /// <param name="method">HTTP method.</param>
        /// <param name="endPoint">Url endpoint.</param>
        /// <param name="isSigned">Specifies if the request needs a signature.</param>
        /// <param name="parameters">Request parameters.</param>
        /// <returns></returns>
        Task<T> ApiCallAsync<T>(ApiMethods method, string endPoint, bool isSigned = false, string parameters = null);
    }
}

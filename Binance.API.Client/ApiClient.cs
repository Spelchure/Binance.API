using Binance.API.Client.Abstract;
using Binance.API.Client.Interfaces;
using Binance.API.Models.Enums;
using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net;
using Binance.API.Client.Utilities;
using Newtonsoft.Json.Linq;


// Thanks for Jose Mejia
namespace Binance.API.Client
{
    public class ApiClient : AbsApiClient, IApiClient
    {
        /// <summary>
        /// ctor of ApiClient
        /// </summary>
        /// <param name="apiKey">API key to be used within the API</param>
        /// <param name="apiSecret">API secret to be used signed Calls.</param>
        /// <param name="apiUrl">Binance API base URL</param>
        /// <param name="addDefaultHeaders">Add default headers or not</param>
        public ApiClient(string apiKey, string apiSecret, string apiUrl = @"https://api1.binance.com", bool addDefaultHeaders = true)
            : base(apiKey,apiSecret,apiUrl,addDefaultHeaders)
        {
        }
   
        
        /// <summary>
        /// Calls API Method asynchronously.
        /// </summary>
        /// <typeparam name="T">Type to which the response content will be converted.</typeparam>
        /// <param name="method">HTTP method.</param>
        /// <param name="endPoint">Url endpoint.</param>
        /// <param name="isSigned">Specifies if the request needs a signature.</param>
        /// <param name="parameters">Request parameters.</param>
        /// <returns></returns>
        public async Task<T> ApiCallAsync<T>(ApiMethods method, string endPoint, bool isSigned = false, string parameters = null)
        {
            var finalEndPoint = endPoint + (string.IsNullOrWhiteSpace(parameters) ? "" : $"?{parameters}");

            if(isSigned) // For signed calls i.e. USER_DATA
            {
                parameters += (!string.IsNullOrWhiteSpace(parameters) ? "&timestamp=" : "timestamp=") +
                    Utilities.Utilities.GenerateTimestamp(DateTime.Now.ToUniversalTime());
                
                // Generate signature for signed calls.
                var signature = Utilities.Utilities.GenerateSignature(_apiSecret, parameters);
                finalEndPoint = $"{endPoint}?{parameters}&signature={signature}";
            }

            // Create request
            var request = new HttpRequestMessage(Utilities.Utilities.CreateHttpMethod(method.ToString()), finalEndPoint);

            // Get response 
            var response = await _httpClient.SendAsync(request).ConfigureAwait(false);

            if (response.IsSuccessStatusCode) // If response OK
            {
                response.EnsureSuccessStatusCode();
                
                var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                return JsonConvert.DeserializeObject<T>(result); // Return the result
            }

            /// Not tested errors !!
            /// Check https://binance-docs.github.io/apidocs/spot/en/#general-api-information
            // We received an error 
            if (response.StatusCode == HttpStatusCode.GatewayTimeout)
            {
                throw new Exception("Api Request Timeout.");
            }
            else if (response.StatusCode == HttpStatusCode.Forbidden) // WAF limit violated
            {
                throw new Exception("Web Application Firewall limit violated.");
            }
            else if (Convert.ToInt32(response.StatusCode) == 429)
            {
                throw new Exception("Request rate limit breaked.");
            }
            else if (Convert.ToInt32(response.StatusCode) == 418)
            {
                throw new Exception("IP banned for continuing to send request after rate limit breaked.");
            }

            // Error code & message
            var e = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            var errorCode = 0;
            string errorMessage = "";
            
            // Get error code and message
            if(e.IsValidJson())
            {
                try
                {
                    var i = JObject.Parse(e);

                    errorCode = i["code"]?.Value<int>() ?? 0;
                    errorMessage = i["msg"]?.Value<string>();
                } catch { }
            }

            // Throw it
            throw new Exception(string.Format("Api Error Code: {0} Message: {1}", errorCode, errorMessage));
        }
    }
}

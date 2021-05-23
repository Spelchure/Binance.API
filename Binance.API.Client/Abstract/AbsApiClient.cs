using System;
using System.Net.Http;

namespace Binance.API.Client.Abstract
{
    public abstract class AbsApiClient
    {
        /// <summary>
        /// API URL to connect 
        /// Default: https://api1.binance.com
        /// </summary>
        public readonly string _apiUrl = "";

        /// <summary>
        /// Key used to authenticate within the API.
        /// </summary>
        public readonly string _apiKey = "";

        /// <summary>
        /// API URL to connect
        /// </summary>
        public readonly string _apiSecret = "";

        /// <summary>
        /// HTTP Connection object
        /// </summary>
        public readonly HttpClient _httpClient;


        /// <summary>
        /// ApiClient's Constructor
        /// </summary>
        /// <param name="apiKey">Key used to authenticate within the API.</param>
        /// <param name="apiSecret">API secret to be used signed API calls.</param>
        /// <param name="apiURL">API URL to connect</param>
        /// <param name="addDefaultHeaders">Configures default headers</param>
        public AbsApiClient(string apiKey, string apiSecret, string apiURL = @"https://api1.binance.com", bool addDefaultHeaders = true)
        {

            if (string.IsNullOrWhiteSpace(apiURL))
                throw new ArgumentException("API URL cannot be null or empty");
            
            _apiUrl = apiURL;
            _apiKey = apiKey;
            _apiSecret = apiSecret;
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(_apiUrl)
            };

            if (addDefaultHeaders)
                ConfigureHttpClient(); 

            
        }
        
        /// <summary>
        /// Configures default HTTP headers for requests
        /// </summary>
        private void ConfigureHttpClient()
        {
            /// Adds API Key.
            _httpClient.DefaultRequestHeaders.Add("X-MBX-APIKEY", _apiKey);
            _httpClient.DefaultRequestHeaders.Accept
                .Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

    }
}

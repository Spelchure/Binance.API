using Binance.API.Client.Abstract;
using Binance.API.Client.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Binance.API.Models.Enums;
using Binance.API.Client.Utilities;
using Binance.API.Models.MarketData;

// Thanks for Jose Mejia
namespace Binance.API.Client
{
    /// <summary>
    /// Main BinanceClient class to be used to call API
    /// </summary>    
    public class BinanceClient : AbsBinanceClient, IBinanceClient
    {
         
        /// <summary>
        /// CTOR. of BinanceClient
        /// </summary>
        /// <param name="apiClient">ApiClient to be used to call API</param>
        public BinanceClient(IApiClient apiClient) : base(apiClient)
        {

        }

        #region MarketDataEndPoints

        /// <summary>
        /// Test connectivity to REST API. 
        /// https://binance-docs.github.io/apidocs/spot/en/#test-connectivity
        /// </summary>
        /// <returns></returns>
        public async Task<dynamic> TestConnectivity()
        {
            var result = await _apiClient.ApiCallAsync<dynamic>(ApiMethods.GET, Utilities.EndPoints.TestConnectivity);
            return result;
        }

        /// <summary>
        /// Test connectivity to Rest API and get the current server time
        /// Weight:1
        /// </summary>
        /// <returns></returns>
        public async Task<ModelServerTime> CheckServerTime()
        {
            var result = await _apiClient.ApiCallAsync<ModelServerTime>(ApiMethods.GET, Utilities.EndPoints.CheckServerTime);
            return result;
        }
        
        /// <summary>
        /// Get order book for specific symbol
        /// </summary>
        /// <param name="symbol">Ticker symbol</param>
        /// <param name="limit">Limit of records</param>
        /// <returns></returns>
        public async Task<ModelOrderBook> GetOrderBook(string symbol, int limit = 100)
        {

            int[] acceptedLimits = { 5, 10, 20, 50, 100, 500, 1000, 5000 }; // Accepted limits.

            // Invalid symbol
            if(string.IsNullOrWhiteSpace(symbol))
            {
                throw new ArgumentException("Symbol cannot be empty."); 
            }
            
            // Invalid limit
            if(!acceptedLimits.Contains(limit))
            {
                throw new ArgumentException("Limit not accepted.");
            }

            // Call API
            var result =
                await _apiClient.ApiCallAsync<dynamic>(ApiMethods.GET, EndPoints.GetOrderBook, false, $"symbol={symbol.ToUpper()}&limit={limit}");

            var parser = new CustomParser();
            var parsedResult = parser.GetParsedOrderBook(result);
            return parsedResult;
        }
        
        /// <summary>
        /// Get recent trades for given symbol
        /// </summary>
        /// <param name="symbol">Symbol to retrieve</param>
        /// <param name="limit">Limit of records, max 1000.</param>
        /// <returns>Recent trades list of symbol.</returns>
        public async Task<IEnumerable<ModelRecentTradesList>> GetRecentTradesList(string symbol, int limit = 500)
        {
            // Invalid symbol.
            if(string.IsNullOrEmpty(symbol))
            {
                throw new ArgumentException("Symbol cannot be empty.");
            }

            // Invalid limit.
            if(limit <= 0 || limit > 1000)
            {
                throw new ArgumentException("Invalid limit value.");
            }

            var result =
                await
                _apiClient.ApiCallAsync<IEnumerable<ModelRecentTradesList>>(ApiMethods.GET, 
                EndPoints.GetRecentTradesList, false, $"symbol={symbol.ToUpper()}&limit={limit}");

            return result;
        }

        /// <summary>
        /// Get compressed, aggregate trades.
        /// </summary>
        /// <param name="symbol">Symbol to retrieve</param>
        /// <param name="fromId">Id to get aggregate trades</param>
        /// <param name="startTime">Timestamp in ms to get aggregate trades from INCLUSIVE</param>
        /// <param name="endTime">Timestamp in ms to get aggregate trades until INCLUSIVE</param>
        /// <param name="limit">Limit of records</param>
        /// <returns>Aggregate trades of symbol</returns>
        public async Task<IEnumerable<ModelAggregateTrades>> GetAggregateTrades(string symbol, long fromId = 0, long startTime = 0, long endTime = 0, int limit = 500)
        {
            // Invalid symbol
            if(string.IsNullOrEmpty(symbol))
            {
                throw new ArgumentException("Symbol cannot be empty.");
            }

            // Invalid limit value
            if(limit <= 0 || limit > 1000)
            {
                throw new ArgumentException("Invalid limit value.");
            }

            // Create parameters
            var args = $"symbol={symbol.ToUpper()}"
                + (fromId != 0 ? $"&fromId={fromId}" : "")
                + (startTime != 0 ? $"&startTime={startTime}" : "")
                + (endTime != 0 ? $"&endTime={endTime}" : "")
                + $"&limit={limit}";

            var result = await _apiClient.ApiCallAsync<IEnumerable<ModelAggregateTrades>>(ApiMethods.GET, EndPoints.GetAggregateTrades, false, args);
            return result;
        }



        /// <summary>
        /// Get current average price for given symbol.
        /// </summary>
        /// <param name="symbol">Symbol to get price</param>
        /// <returns>Average price of symbol</returns>
        public async Task<ModelCurrentAveragePrice> GetCurrentAveragePrice(string symbol)
        {
            // Invalid symbol
            if(string.IsNullOrEmpty(symbol))
            {
                throw new ArgumentException("Symbol cannot be empty.");
            }

            var result = await _apiClient.ApiCallAsync<ModelCurrentAveragePrice>(ApiMethods.GET, EndPoints.GetCurrentAveragePrice, false, $"symbol={symbol.ToUpper()}");
            return result;
        }

        /// <summary>
        /// 24 hour rolling window price change statistics. Careful when accessing this with no symbol.
        /// </summary>
        /// <param name="symbol">Symbol to get 24HR change</param>
        /// <returns>Model of 24 HR Price change stats.</returns>
        public async Task<dynamic> GetTicker24HrPriceChange(string symbol)
        {
            
            if(!string.IsNullOrEmpty(symbol))
            {
                var result =
                    await
                    _apiClient.ApiCallAsync<Model24HrPriceChangeStats>(ApiMethods.GET, EndPoints.Get24HrTickerPriceChangeStats, false, $"symbol={symbol.ToUpper()}");
                return result; 
            } else
            {
                var result =
                    await
                    _apiClient.ApiCallAsync<IEnumerable<Model24HrPriceChangeStats>>(ApiMethods.GET, EndPoints.Get24HrTickerPriceChangeStats);
                return result; 
            }
        }
        

        /// <summary>
        /// Latest price for a symbol or symbols.
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns>Latest price for symbol or symbols.</returns>
        public async Task<dynamic> GetSymbolPrice(string symbol)
        {
            if(!string.IsNullOrEmpty(symbol))
            {
                var result =
                    await
                    _apiClient.ApiCallAsync<ModelSymbolPrice>(ApiMethods.GET, EndPoints.GetSymbolPrice, false, $"symbol={symbol.ToUpper()}");
                return result; 
            } else
            {
                var result =
                    await
                    _apiClient.ApiCallAsync<IEnumerable<ModelSymbolPrice>>(ApiMethods.GET, EndPoints.GetSymbolPrice);
                return result; 
            }

        }

        /// <summary>
        /// Best price/qty on the order book for a symbol or symbols.
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns>OrderBook of symbol or symbols.</returns>
        public async Task<dynamic> GetSymbolOrderBook(string symbol)
        {
            if (!string.IsNullOrEmpty(symbol))
            {
                var result =
                    await
                    _apiClient.ApiCallAsync<ModelSymbolOrderBook>(ApiMethods.GET, EndPoints.GetSymbolOrderBook, false, $"symbol={symbol.ToUpper()}");
                return result;
            }
            else
            {
                var result =
                    await
                    _apiClient.ApiCallAsync<IEnumerable<ModelSymbolOrderBook>>(ApiMethods.GET, EndPoints.GetSymbolOrderBook);
                return result;
            }
        }

        /// <summary>
        /// Get candlestick bars for a symbol
        /// Weight: 1
        /// </summary>
        /// <param name="symbol">Symbol to retrieve</param>
        /// <param name="interval">Time interval</param>
        /// <param name="startTime">Start time for candlestick data</param>
        /// <param name="endTime">End time for candlestick data</param>
        /// <param name="limit">Limit of records</param>
        /// <returns>Enumerable parsed candlestick data</returns>
        public async Task<IEnumerable<ModelCandlestick>> GetCandlestickData(string symbol, TimeInterval interval, DateTime? startTime = null, DateTime? endTime = null, int limit = 500)
        {
            if(string.IsNullOrWhiteSpace(symbol))
            {
                throw new ArgumentException("Symbol cannot be empty.");
            }
            
            if(limit <= 0 || limit > 1000)
            {
                throw new ArgumentException("Invalid limit value.");
            }
 
            var args = $"symbol={symbol.ToUpper()}&interval={interval.GetEnumDescription()}"
                + (startTime.HasValue ? $"&startTime={startTime.Value.GetUnixTimestamp()}" : "")
                + (endTime.HasValue ? $"&endTime={endTime.Value.GetUnixTimestamp()}" : "")
                + $"&limit={limit}";

            var result = await _apiClient.ApiCallAsync<dynamic>(ApiMethods.GET, EndPoints.GetCandlestickData, false, args);

            // Parse result
            var parser = new CustomParser();
            var parsedResult = parser.GetParsedCandlestickData(result);
            return parsedResult;
        }

        /// <summary>
        /// Get current exchange trading rules and symbol information
        /// Careful when calling with multiple symbols list must be :
        ///     ["BTCUSDT","BNBUSDT"]
        /// </summary>
        /// <param name="symbols">Symbol list. Can be empty.</param>
        /// <returns>Exchange traiding rules</returns>
        public async Task<ModelExchangeInfo> GetExchangeInfo(List<string> symbols)
        {
            if(symbols.Count > 0)
            {
                if(symbols.Count == 1)
                {
                    var result =
                        await _apiClient.ApiCallAsync<ModelExchangeInfo>(ApiMethods.GET, 
                        EndPoints.GetExchangeInformation,false,$"symbol={symbols[0].ToUpper()}");
                    return result;
                }
                else // Call with multiple symbol
                {
                    var args = "symbols=[" + string.Join(",",symbols.Select(s => $"\"{s}\"")) + "]";
                    var result =
                        await _apiClient.ApiCallAsync<ModelExchangeInfo>(ApiMethods.GET, 
                        EndPoints.GetExchangeInformation,false,args);
                    return result;
                }
            
            } else
            {
                var result =
                    await _apiClient.ApiCallAsync<ModelExchangeInfo>(ApiMethods.GET, EndPoints.GetExchangeInformation);
                return result;
            }
        }


        #endregion

    } 
}

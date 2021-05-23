using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Binance.API.Models.MarketData;
using Binance.API.Models.Enums;

namespace Binance.API.Client.Interfaces
{

    /// <summary>
    /// Interface for Binance Client.
    /// </summary>
    public interface IBinanceClient
    {

        #region MarketDataEndpoints
        
        /// <summary>
        /// Test connectivity to API.
        /// Weight:1
        /// </summary>
        /// <returns></returns>
        Task<dynamic> TestConnectivity();

        /// <summary>
        /// Test connectivity to Rest API and get the current server time
        /// Weight:1
        /// </summary>
        /// <returns>Server time</returns>
        Task<ModelServerTime> CheckServerTime();

        /// <summary>
        /// Get order book for specific symbol
        /// </summary>
        /// <param name="symbol">Ticker symbol</param>
        /// <param name="limit">Limit of records</param>
        /// <returns>Order book for symbol</returns>
        Task<ModelOrderBook> GetOrderBook(string symbol, int limit = 100);


        /// <summary>
        /// Get recent trades for given symbol
        /// </summary>
        /// <param name="symbol">Symbol to retrieve</param>
        /// <param name="limit">Limit of records, max 1000.</param>
        /// <returns>Recent trades list of symbol.</returns>
        Task<IEnumerable<ModelRecentTradesList>> GetRecentTradesList(string symbol, int limit = 500);

        /// <summary>
        /// Get compressed, aggregate trades.
        /// </summary>
        /// <param name="symbol">Symbol to retrieve</param>
        /// <param name="fromId">Id to get aggregate trades</param>
        /// <param name="startTime">Timestamp in ms to get aggregate trades from INCLUSIVE</param>
        /// <param name="endTime">Timestamp in ms to get aggregate trades until INCLUSIVE</param>
        /// <param name="limit">Limit of records</param>
        /// <returns>Aggregate trades of symbol</returns>
        Task<IEnumerable<ModelAggregateTrades>> GetAggregateTrades(string symbol, long fromId = 0, long startTime = 0, long endTime = 0, int limit = 500);


        /// <summary>
        /// Get current average price for given symbol.
        /// </summary>
        /// <param name="symbol">Symbol to get price</param>
        /// <returns>Average price of symbol</returns>
        Task<ModelCurrentAveragePrice> GetCurrentAveragePrice(string symbol);


        /// <summary>
        /// 24 hour rolling window price change statistics. Careful when accessing this with no symbol.
        /// </summary>
        /// <param name="symbol">Symbol to get 24HR change</param>
        /// <returns>Model of 24 HR Price change stats.</returns>
        Task<dynamic> GetTicker24HrPriceChange(string symbol);

        /// <summary>
        /// Latest price for a symbol or symbols.
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns>Lastest price for symbol or symbols</returns>
        Task<dynamic> GetSymbolPrice(string symbol);

        /// <summary>
        /// Best price/qty on the order book for a symbol or symbols.
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns>Order book of symbol or symbols.</returns>
        Task<dynamic> GetSymbolOrderBook(string symbol);


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
        Task<IEnumerable<ModelCandlestick>> GetCandlestickData(string symbol, TimeInterval interval, DateTime? startTime = null, DateTime? endTime = null, int limit = 500);


        /// <summary>
        /// Get current exchange trading rules and symbol information
        /// </summary>
        /// <param name="symbols">Symbol list. Can be empty.</param>
        /// <returns>Exchange traiding rules</returns>
        Task<ModelExchangeInfo> GetExchangeInfo(List<string> symbols);

        #endregion

    }
}


namespace Binance.API.Client.Utilities
{
    /// <summary>
    /// End point URL definitions for Binance API.
    /// See : https://binance-docs.github.io/apidocs/spot/en/
    /// </summary>
    public static class EndPoints
    {
        #region MarketDataEndpoints

        public static readonly string TestConnectivity = "/api/v3/ping";
        public static readonly string CheckServerTime = "/api/v3/time";
        public static readonly string GetOrderBook = "/api/v3/depth";
        public static readonly string GetRecentTradesList = "/api/v3/trades";
        public static readonly string GetAggregateTrades = "/api/v3/aggTrades";
        public static readonly string GetCurrentAveragePrice = "/api/v3/avgPrice";
        public static readonly string Get24HrTickerPriceChangeStats = "/api/v3/ticker/24hr";
        public static readonly string GetSymbolPrice = "/api/v3/ticker/price";
        public static readonly string GetSymbolOrderBook = "/api/v3/ticker/bookTicker";
        public static readonly string GetExchangeInformation = "/api/v3/exchangeInfo";
        public static readonly string GetCandlestickData = "/api/v3/klines";

        #endregion

    }
}

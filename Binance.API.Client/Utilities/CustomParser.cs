using Binance.API.Models.MarketData;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace Binance.API.Client.Utilities
{
    /// <summary>
    /// Parser for some specific entities.
    /// </summary>
    public class CustomParser {

        /// <summary>
        /// Gets the orderbook data and generates an OrderBook object.
        /// </summary>
        /// <param name="orderBookData">Dynamic that contains order book data.</param>
        /// <returns>Parsed order book</returns>
        public ModelOrderBook GetParsedOrderBook(dynamic orderBookData)
        {
            var result = new ModelOrderBook
            {
                LastUpdateId = orderBookData.lastUpdateId.Value
            };


            var bids = new List<ModelOrderBookOffer>();
            var asks = new List<ModelOrderBookOffer>();

            foreach (JToken item in ((JArray)orderBookData.bids).ToArray())
            {
                bids.Add(new ModelOrderBookOffer()
                {
                    Price = decimal.Parse(item[0].ToString()),
                    Quantity = decimal.Parse(item[1].ToString())
                });
            }

            foreach (JToken item in ((JArray)orderBookData.asks).ToArray())
            {
                asks.Add(new ModelOrderBookOffer()
                {
                    Price = decimal.Parse(item[0].ToString()),
                    Quantity = decimal.Parse(item[1].ToString())
                });
            }

            result.Bids = bids;
            result.Asks = asks;

            return result;
        }
   
        /// <summary>
        /// Converts dynamic candle stick data to ModelCandleStick
        /// </summary>
        /// <param name="candlestickData">Dynamic candlestick data</param>
        /// <returns>List of ModelCandlestick</returns>
        public IEnumerable<ModelCandlestick> GetParsedCandlestickData(dynamic candlestickData)
        {
            var result = new List<ModelCandlestick>();

            foreach(JToken item in ((JArray)candlestickData).ToArray())
            {
                result.Add(new ModelCandlestick()
                {
                    OpenTime = long.Parse(item[0].ToString()),
                    Open = decimal.Parse(item[1].ToString()),
                    High = decimal.Parse(item[2].ToString()),
                    Low = decimal.Parse(item[3].ToString()),
                    Close = decimal.Parse(item[4].ToString()),
                    Volume = decimal.Parse(item[5].ToString()),
                    CloseTime = long.Parse(item[6].ToString()),
                    QuoteAssetVolume = decimal.Parse(item[7].ToString()),
                    NumberOfTrades = int.Parse(item[8].ToString()),
                    TakerBuyBaseAssetVolume = decimal.Parse(item[9].ToString()),
                    TakerBuyQuoteAssetVolume = decimal.Parse(item[10].ToString()),
                    Ignore = decimal.Parse(item[11].ToString()),
                });
            }

            return result;
        }
    
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binance.API.Models.MarketData
{
    /// <summary>
    /// Model for symbol order book
    /// https://binance-docs.github.io/apidocs/spot/en/#symbol-order-book-ticker
    /// </summary>    
    public class ModelSymbolOrderBook
    {
        [JsonProperty("symbol")]  
        public string Symbol { get; set; }

        [JsonProperty("bidPrice")]  
        public string BidPrice { get; set; }
        
        [JsonProperty("bidQty")]  
        public string BidQty { get; set; }

        [JsonProperty("askPrice")]  
        public string AskPrice { get; set; }

        [JsonProperty("askQty")]  
        public string AskQty { get; set; }
    }
}

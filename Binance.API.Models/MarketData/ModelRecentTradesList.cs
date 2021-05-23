using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binance.API.Models.MarketData
{
    /// <summary>
    /// Model for recent trades list for given symbol. 
    /// https://binance-docs.github.io/apidocs/spot/en/#recent-trades-list
    /// </summary>    
    public class ModelRecentTradesList
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("qty")]
        public string Qty { get; set; }

        [JsonProperty("quoteQty")]
        public string QuoteQty { get; set; }

        [JsonProperty("time")]
        public long Time { get; set; }

        [JsonProperty("isBuyerMaker")]
        public bool IsBuyerMaker { get; set; }

        [JsonProperty("isBestMatch")]
        public bool IsBestMatch { get; set; }
    }

 }

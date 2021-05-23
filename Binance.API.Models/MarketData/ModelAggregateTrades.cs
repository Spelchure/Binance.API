using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binance.API.Models.MarketData
{
    /// <summary>
    /// Model for aggregate trades for given symbol
    /// https://binance-docs.github.io/apidocs/spot/en/#compressed-aggregate-trades-list
    /// </summary>
    public class ModelAggregateTrades
    {
        [JsonProperty("a")]
        public long AggregateTradeId { get; set; }

        [JsonProperty("p")]
        public string Price { get; set; }

        [JsonProperty("q")]
        public string Quantity { get; set; }

        [JsonProperty("f")]
        public long FirstTradeId { get; set; }
        
        [JsonProperty("l")]
        public long LastTradeId { get; set; }

        [JsonProperty("T")]
        public long Timestamp { get; set; }

        [JsonProperty("m")]
        public bool IsBuyerMaker { get; set; }

        [JsonProperty("M")]
        public bool IsBestPriceMatch { get; set; }
    }
}

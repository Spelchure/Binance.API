using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binance.API.Models.MarketData
{
    /// <summary>
    /// Model for symbol (ExchangeInfo)
    /// https://binance-docs.github.io/apidocs/spot/en/#exchange-information
    /// </summary>    
    public class ModelSymbol
    {
        [JsonProperty("symbol")] 
        public string Symbol { get; set; }

        [JsonProperty("status")] 
        public string Status { get; set; }

        [JsonProperty("baseAsset")] 
        public string BaseAsset { get; set; }
        
        [JsonProperty("baseAssetPrecision")] 
        public int BaseAssetPrecision { get; set; }

        [JsonProperty("quoteAsset")] 
        public string QuoteAsset { get; set; }
        
        [JsonProperty("quotePrecision")] 
        public int QuotePrecision { get; set; }

        [JsonProperty("quoteAssetPrecision")] 
        public int QuoteAssetPrecision { get; set; }

        [JsonProperty("orderTypes")] 
        public IEnumerable<string> OrderTypes { get; set; }

        [JsonProperty("icebergAllowed")] 
        public bool IcebergAllowed { get; set; }

        [JsonProperty("ocoAllowed")] 
        public bool OcoAllowed { get; set; }

        [JsonProperty("isSpotTradingAllowed")] 
        public bool IsSpotTradingAllowed { get; set; }

        [JsonProperty("isMarginTradingAllowed")] 
        public bool IsMarginTradingAllowed { get; set; }

        [JsonProperty("filters")] 
        public IEnumerable<object> Filters { get; set; }
        
        [JsonProperty("permissions")] 
        public IEnumerable<string> Permissions { get; set; }
    }
}

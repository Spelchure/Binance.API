using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binance.API.Models.MarketData
{
    /// <summary>
    /// Model for symbol price
    /// https://binance-docs.github.io/apidocs/spot/en/#symbol-price-ticker
    /// Weight:
    ///     1: For single symbol
    ///     2: When the symbol parameter is omitted.
    /// </summary>    
    public class ModelSymbolPrice
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }
    }
}

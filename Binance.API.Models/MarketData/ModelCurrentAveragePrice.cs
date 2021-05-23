using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binance.API.Models.MarketData
{
    /// <summary>
    /// Model for current average price of symbol
    /// https://binance-docs.github.io/apidocs/spot/en/#current-average-price
    /// </summary>    
    public class ModelCurrentAveragePrice
    {
        
        [JsonProperty("mins")]
        public int Mins { get; set;  }

        [JsonProperty("price")]
        public string Price { get; set; } 
    }
}

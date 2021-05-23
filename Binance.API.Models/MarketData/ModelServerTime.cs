using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binance.API.Models.MarketData
{
    /// <summary>
    /// Model for Server time
    /// https://binance-docs.github.io/apidocs/spot/en/#test-connectivity
    /// </summary>    
    public class ModelServerTime
    {
        
        [JsonProperty("serverTime")]  
        public long ServerTime { get; set; }
    }
}

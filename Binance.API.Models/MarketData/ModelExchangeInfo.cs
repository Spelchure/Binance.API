using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binance.API.Models.MarketData
{
    /// <summary>
    /// Current exchange trading rules and symbol information
    /// https://binance-docs.github.io/apidocs/spot/en/#exchange-information
    /// </summary>
    public class ModelExchangeInfo
    {

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("serverTime")]
        public long ServerTime { get; set; }

        [JsonProperty("rateLimits")]
        public IEnumerable<ModelRateLimit> RateLimits { get; set; }

        [JsonProperty("exhangeFilters")]
        public IEnumerable<object> ExhangeFilters { get; set; }

        [JsonProperty("symbols")]
        public IEnumerable<ModelSymbol> Symbols { get; set; }

    }
}

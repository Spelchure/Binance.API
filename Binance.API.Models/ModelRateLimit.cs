using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binance.API.Models
{
    /// <summary>
    /// Model for Rate limit
    /// https://binance-docs.github.io/apidocs/spot/en/#public-api-definitions
    /// Rate limiters: REQUEST_WEIGHT, ORDERS, RAW_REQUESTS
    /// Intervals: SECOND,MINUTE,DAY
    /// </summary>
    public class ModelRateLimit
    {
        [JsonProperty("rateLimitType")]
        public string RateLimitType { get; set; } // REQUEST_WEIGHT, ORDERS, RAW_REQUESTS

        [JsonProperty("interval")]
        public string Interval { get; set; }

        [JsonProperty("intervalNum")]
        public int IntervalNum { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }
    }
}

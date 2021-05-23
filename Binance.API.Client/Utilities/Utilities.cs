using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Binance.API.Models.MarketData.Filters;
using System.Security.Cryptography;
using Newtonsoft.Json.Linq;

namespace Binance.API.Client.Utilities
{
    /// <summary>
    /// Useful/Helper functions 
    /// </summary>
    public static class Utilities
    {
        /// <summary>
        /// Generates signature for signed API calls.
        /// </summary>
        /// <param name="apiSecret">Api secret used to generate the signature.</param>
        /// <param name="message">Message to encode</param>
        /// <returns></returns>        
        public static string GenerateSignature(string apiSecret, string message)
        {
            if (string.IsNullOrEmpty(apiSecret) || string.IsNullOrEmpty(message))
                throw new ArgumentException("Both of parameters cannot be empty.");

            var key = Encoding.UTF8.GetBytes(apiSecret);
            string hashString;

            using (var hmac = new HMACSHA256(key))
            {
                var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(message));
                hashString = BitConverter.ToString(hash).Replace("-", "");
            }

            return hashString;
        }

        /// <summary>
        /// Generates timestamp in milliseconds
        /// </summary>
        /// <param name="baseTime"></param>
        /// <returns>Timestamp in milliseconds</returns>
        public static string GenerateTimestamp(DateTime baseTime)
        {
            var dtOffset = new DateTimeOffset(baseTime);
            return dtOffset.ToUnixTimeSeconds().ToString();
        }

        /// <summary>
        /// Creates HTTP method.
        /// </summary>
        /// <param name="method">Method name as string.</param>
        /// <returns>HttpMethod object.</returns>
        public static HttpMethod CreateHttpMethod(string method)
        {
            switch(method.ToUpper())
            {
                case "DELETE":
                    return HttpMethod.Delete;
                case "POST":
                    return HttpMethod.Post;
                case "PUT":
                    return HttpMethod.Put;
                case "GET":
                    return HttpMethod.Get;
                default:
                    throw new NotImplementedException();
            }
        }
    
        /// <summary>
        /// Parse filter defined as JObject into ModelFilter 
        /// </summary>
        /// <param name="filter">Filter to parse</param>
        /// <returns>Specific filter model</returns>
        public static ModelFilter ParseFilter(object filter)
        {
            if(filter.GetType() == typeof(JObject))
            {
                JObject jFilter = (JObject)filter;
                if(jFilter.HasValues)
                {
                    var values = jFilter.ToObject<Dictionary<string, string>>();
                    if(values.ContainsKey("filterType"))
                    {
                         
                        switch(values["filterType"])
                        {
                            // Symbol filters 
                            case "PRICE_FILTER":
                                ModelPriceFilter modelPriceFilter = new ModelPriceFilter
                                {
                                    FilterType = "PRICE_FILTER",
                                    MinPrice = decimal.Parse(values["minPrice"]),
                                    MaxPrice = decimal.Parse(values["maxPrice"]),
                                    TickSize = decimal.Parse(values["tickSize"])
                                };
                                return modelPriceFilter;
                            case "PERCENT_PRICE":
                                ModelPercentPriceFilter modelPercentPriceFilter = new ModelPercentPriceFilter
                                {
                                    FilterType = "PERCENT_PRICE",
                                    MultiplierUp = decimal.Parse(values["multiplierUp"]),
                                    MultiplierDown = decimal.Parse(values["multiplierDown"]),
                                    AvgPriceMins = int.Parse(values["avgPriceMins"])
                                };
                                return modelPercentPriceFilter;
                            case "LOT_SIZE":
                                ModelLotSizeFilter modelLotSizeFilter = new ModelLotSizeFilter
                                {
                                    FilterType = "LOT_SIZE",
                                    MinQty = decimal.Parse(values["minQty"]),
                                    MaxQty = decimal.Parse(values["maxQty"]),
                                    StepSize = decimal.Parse(values["stepSize"])
                                };
                                return modelLotSizeFilter;
                            case "MIN_NOTIONAL":
                                ModelMinNotionalFilter modelMinNotionalFilter = new ModelMinNotionalFilter
                                {
                                    FilterType = "MIN_NOTIONAL",
                                    MinNotional = decimal.Parse(values["minNotional"]),
                                    ApplyToMarket = bool.Parse(values["applyToMarket"]),
                                    AvgPriceMins = int.Parse(values["avgPriceMins"]),
                                };
                                return modelMinNotionalFilter;
                            case "ICEBERG_PARTS":
                                ModelIcebergPartsFilter modelIcebergPartsFilter = new ModelIcebergPartsFilter
                                {
                                    FilterType = "ICEBERG_PARTS",
                                    Limit = int.Parse(values["limit"])
                                };
                                return modelIcebergPartsFilter;
                            case "MARKET_LOT_SIZE":
                                ModelMarketLotSizeFilter modelMarketLotSizeFilter = new ModelMarketLotSizeFilter
                                {
                                    FilterType = "MARKET_LOT_SIZE",
                                    MinQty = decimal.Parse(values["minQty"]),
                                    MaxQty = decimal.Parse(values["maxQty"]),
                                    StepSize = decimal.Parse(values["stepSize"])
                                };
                                return modelMarketLotSizeFilter;
                            case "MAX_NUM_ORDERS":
                                ModelMaxNumOrdersFilter modelMaxNumOrdersFilter = new ModelMaxNumOrdersFilter
                                {
                                    FilterType = "MAX_NUM_ORDERS",
                                    MaxNumOrders = int.Parse(values["maxNumOrders"])
                                };
                                return modelMaxNumOrdersFilter;
                            case "MAX_NUM_ALGO_ORDERS":
                                ModelMaxNumAlgoOrdersFilter modelMaxNumAlgoOrdersFilter = new ModelMaxNumAlgoOrdersFilter
                                {
                                    FilterType = "MAX_NUM_ALGO_ORDERS",
                                    MaxNumAlgoOrders = int.Parse(values["maxNumAlgoOrders"])
                                };
                                return modelMaxNumAlgoOrdersFilter;
                            case "MAX_NUM_ICEBERG_ORDERS":
                                ModelMaxNumIcebergOrders modelMaxNumIcebergOrders = new ModelMaxNumIcebergOrders
                                {
                                    FilterType = "MAX_NUM_ICEBERG_ORDERS",
                                    MaxNumIcebergOrders = int.Parse(values["maxNumIcebergOrders"])
                                };
                                return modelMaxNumIcebergOrders;
                            // Exchange filters
                            case "MAX_POSITION":
                                ModelMaxPositionFilter modelMaxPositionFilter = new ModelMaxPositionFilter
                                {
                                    FilterType = "MAX_POSITION",
                                    MaxPosition = decimal.Parse(values["maxPosition"])
                                };
                                return modelMaxPositionFilter;
                            case "EXCHANGE_MAX_NUM_ORDERS":
                                ModelExchangeMaxNumOrders modelExchangeMaxNumOrders = new ModelExchangeMaxNumOrders
                                {
                                    FilterType = "EXCHANGE_MAX_NUM_ORDERS",
                                    MaxNumOrders = values["maxNumOrders"]
                                };
                                return modelExchangeMaxNumOrders;
                            case "EXCHANGE_MAX_ALGO_ORDERS":
                                ModelExchangeMaxNumAlgoOrders modelExchangeMaxNumAlgoOrders = new ModelExchangeMaxNumAlgoOrders
                                {
                                    FilterType = "EXCHANGE_MAX_ALGO_ORDERS",
                                    MaxNumAlgoOrders = values["maxNumAlgoOrders"]
                                };
                                return modelExchangeMaxNumAlgoOrders;
                            default:
                                throw new NotImplementedException($"Filter type not known: {values["filterType"]}");

                        }
                    } else
                    {
                        throw new ArgumentException("Invalid filter. filterType not found.");
                    }
                }
            }  else
            {
                throw new ArgumentException($"Invalid argument. JObject excepted but found: {filter.GetType().Name}");
            }
            return null;
            //throw new ArgumentException("Invalid filter."); 
        }
    
        /// <summary>
        /// Parse filters defined as enumerable JObject into ModelFilters  list
        /// </summary>
        /// <param name="filter">Filters to parse</param>
        /// <returns>List of Specific filter models</returns>
        public static IEnumerable<ModelFilter> ParseFilter(IEnumerable<object> filters)
        {
            List<ModelFilter> parsedFilters = new List<ModelFilter>();
            foreach(object filter in filters)
            {
                parsedFilters.Add(ParseFilter(filter));
            }
            return parsedFilters;
        }
    }
}

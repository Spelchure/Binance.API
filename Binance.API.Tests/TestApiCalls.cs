using Binance.API.Client;
using Binance.API.Client.Utilities;
using Binance.API.Models.MarketData;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Binance.API.Tests
{
    public class Tests
    {

        /// Api Client to call api. First: ApiKey, Second: ApiSecret
        private static ApiClient apiClient = new ApiClient("", "");

        // Binance Client to call ApiClient and api.
        private static BinanceClient binanceClient = new BinanceClient(apiClient);
        
        /// <summary>
        /// Tests SetUp.
        /// </summary>        
        [SetUp]
        public void Setup()
        {
            
        }

        /// <summary>
        /// Tests for invalid constructions.
        /// For example empty URL with ApiClient.
        /// </summary>
        [Test]
        public void TestInvalidConstructions()
        {
            Assert.Throws<ArgumentException>(() => new ApiClient("", "", ""));
        }


        /// <summary>
        /// Tests for all implemented API Calls.
        /// </summary>
        #region TestsForApiCalls
        
        [Test] 
        public void TestTestConnectivity()
        {
            var result = binanceClient.TestConnectivity().Result; 
        }


        [Test]
        public void TestCheckServerTime()
        {
            var result = binanceClient.CheckServerTime().Result;
            Assert.IsInstanceOf(typeof(ModelServerTime), result);
        }

        [Test]
        public void TestGetOrderBook()
        {
            Assert.ThrowsAsync<ArgumentException>(() => binanceClient.GetOrderBook("")); // Invalid symbol
            Assert.ThrowsAsync<ArgumentException>(() => binanceClient.GetOrderBook("sym", 15)); // Invalid limit
            Assert.ThrowsAsync<Exception>(() => binanceClient.GetOrderBook("INVALIDSYMBOL")); // Invalid symbol too for Binance side
        }

        [Test]
        public void TestGetRecentTradesList()
        {
            Assert.ThrowsAsync<ArgumentException>(() => binanceClient.GetRecentTradesList("")); // Invalid symbol
            Assert.ThrowsAsync<ArgumentException>(() => binanceClient.GetRecentTradesList("SYMBOL", -1)); // Invalid limit
            Assert.ThrowsAsync<ArgumentException>(() => binanceClient.GetRecentTradesList("SYMBOL", 1250)); // Invalid limit
            Assert.ThrowsAsync<Exception>(() => binanceClient.GetRecentTradesList("SYMBOL")); // Invalid symbol for Binance side
        }


        [Test]
        public void TestGetAggregateTrades()
        {
            Assert.ThrowsAsync<ArgumentException>(() => binanceClient.GetAggregateTrades("")); // Invalid symbol
            Assert.ThrowsAsync<ArgumentException>(() => binanceClient.GetAggregateTrades("SYMBOL",limit:-1)); // Invalid limit
            Assert.ThrowsAsync<ArgumentException>(() => binanceClient.GetAggregateTrades("SYMBOL", limit:1250)); // Invalid limit
            Assert.ThrowsAsync<Exception>(() => binanceClient.GetAggregateTrades("SYMBOL")); // Invalid args
        }

        [Test]
        public void TestGetCurrentAveragePrice()
        {
            Assert.ThrowsAsync<ArgumentException>(() => binanceClient.GetCurrentAveragePrice("")); // Invalid symbol
            Assert.ThrowsAsync<Exception>(() => binanceClient.GetCurrentAveragePrice("SYMBOL")); // Invalid args
        }


        [Test]
        public void TestGetTicker24HrPriceChange()
        {
            Assert.ThrowsAsync<Exception>(() => binanceClient.GetTicker24HrPriceChange("SYMBOL")); // Invalid symbol 
            var result = binanceClient.GetTicker24HrPriceChange(""); // Call with no symbol
        }
        
        
        [Test]
        public void TestGetSymbolPrice()
        {
            Assert.ThrowsAsync<Exception>(() => binanceClient.GetSymbolPrice("SYMBOL")); // Invalid symbol 
            var result = binanceClient.GetSymbolPrice(""); // Call with no symbol
        }

        [Test]
        public void TestGetSymbolOrderBook()
        {
            Assert.ThrowsAsync<Exception>(() => binanceClient.GetSymbolOrderBook("SYMBOL")); // Invalid symbol 
            var result = binanceClient.GetSymbolOrderBook(""); // Call with no symbol
        }
       
        
        [Test]
        public void TestGetCandlestickData()
        {
            Assert.ThrowsAsync<ArgumentException>(() => binanceClient.GetCandlestickData("", Models.Enums.TimeInterval.Hours_4));
            Assert.ThrowsAsync<ArgumentException>(() => binanceClient.GetCandlestickData("SYM", Models.Enums.TimeInterval.Hours_4, limit:1200));
        }

        [Test]
        public void TestExchangeInfo()
        {
            var result = binanceClient.GetExchangeInfo(new List<string>() { "BTCUSDT","ETHUSDT" });
        }

        #endregion 


        /// <summary>
        /// Tests for functions in Utilities class
        /// </summary>
        #region TestsForUtilities

        [Test]
        public void TestGenerateSignature()
        {
            Assert.Throws<ArgumentException>(() => Utilities.GenerateSignature("", "msg"));
            Assert.Throws<ArgumentException>(() => Utilities.GenerateSignature("msg", ""));
        }

        [Test]
        public void TestCreateHttpMethod()
        {
            Assert.Throws<NotImplementedException>(() => Utilities.CreateHttpMethod("0"));
        }

        [Test]
        public void TestIsValidJson()
        {
            Assert.AreEqual("X".IsValidJson(), false);
            Assert.AreEqual("".IsValidJson(), false);
            Assert.AreEqual("[]".IsValidJson(), true);
            Assert.AreEqual("{}".IsValidJson(), true);
        }

        [Test]
        public void TestParseFilter()
        {
            var jsonString = @"{
                'unknown1':'unknown2'
            }";

            JObject jObject = JObject.Parse(jsonString);
            JObject jObject1 = JObject.Parse(@"{'filterType':'test'}");
            //JObject jObject2 = JObject.Parse(@"{'filterType':'PRICE_FILTER'}");

            Assert.Throws<ArgumentException>(() => Utilities.ParseFilter("stringValue"));
            Assert.Throws<ArgumentException>(() => Utilities.ParseFilter(jObject));
            Assert.Throws<NotImplementedException>(() => Utilities.ParseFilter(jObject1));
            //Assert.Throws<KeyNotFoundException>(() => Utilities.ParseFilter(jObject2));
        }

        #endregion
    }
}
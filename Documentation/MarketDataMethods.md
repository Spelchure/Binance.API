<!-- START doctoc generated TOC please keep comment here to allow auto update -->
<!-- DON'T EDIT THIS SECTION, INSTEAD RE-RUN doctoc TO UPDATE -->
**Table of Contents**  *generated with [DocToc](https://github.com/thlorenz/doctoc)*

- [Market Data Methods](#market-data-methods)
  - [TestConnectivity](#testconnectivity)
  - [CheckServerTime](#checkservertime)
  - [GetOrderBook](#getorderbook)
  - [GetRecentTradesList](#getrecenttradeslist)
  - [GetAggregateTrades](#getaggregatetrades)
  - [GetTicker24HrPriceChange](#getticker24hrpricechange)
  - [GetSymbolPrice](#getsymbolprice)
  - [GetSymbolOrderBook](#getsymbolorderbook)
  - [GetCandlestickData](#getcandlestickdata)
  - [GetExchangeInfo](#getexchangeinfo)
  - [GetCurrentAveragePrice](#getcurrentaverageprice)

<!-- END doctoc generated TOC please keep comment here to allow auto update -->


# Market Data Methods

## TestConnectivity
Test connectivity to REST API.

### Example
```c#
var result = binanceClient.TestConnectivity().Result; 
```

### Method Signature
```c#
public async Task<dynamic> TestConnectivity()
```


## CheckServerTime
Test connectivity to Rest API and get the current server time

### Example
```c#
var result = binanceClient.CheckServerTime().Result;
```

### Method Signature
```c#
public async Task<ModelServerTime> CheckServerTime()
```

### Model for ServerTime
```c#
  public class ModelServerTime
    {
        
        [JsonProperty("serverTime")]  
        public long ServerTime { get; set; }
    }
```


## GetOrderBook
Get order book for specific symbol

### Example
```c#
var result = binanceClient.GetOrderBook("BTCUSDT");
```

### Method Signature
```c#
public async Task<ModelOrderBook> GetOrderBook(string symbol, int limit = 100)
```

### Model for OrderBook
```c#
 public class ModelOrderBookOffer
    {
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
    }

 public class ModelOrderBook
    {
        public long LastUpdateId { get; set; }

        public IEnumerable<ModelOrderBookOffer> Bids { get; set; }

        public IEnumerable<ModelOrderBookOffer> Asks { get; set; }
    }
```

## GetRecentTradesList
Get recent trades for given symbol

### Example
```c#
var result = binanceClient.GetRecentTradesList("BTCUSDT").Result;
```

### Method Signature
```c#
public async Task<IEnumerable<ModelRecentTradesList>> GetRecentTradesList(string symbol, int limit = 500)
```

### Model for RecentTrades
```c#
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

```



## GetAggregateTrades
Get compressed, aggregate trades.

### Example
```c#
var result = binanceClient.GetAggregateTrades("BTCUSDT");
```

### Method Signature
```c#
public async Task<IEnumerable<ModelAggregateTrades>> GetAggregateTrades(string symbol, long fromId = 0, long startTime = 0, long endTime = 0, int limit = 500)
```

### Model for AggregateTrades
```c#
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

```



## GetTicker24HrPriceChange
24 hour rolling window price change statistics. Careful when accessing this with no symbol.

### Example
```c#
var result =  binanceClient.GetTicker24HrPriceChange("BTCUSDT")).Result;
```

### Method Signature
```c#
public async Task<dynamic> GetTicker24HrPriceChange(string symbol)
```

### Model for 24HrPriceChange
```c#
 public class Model24HrPriceChangeStats
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("priceChange")]
        public string PriceChange { get; set; }
        
        [JsonProperty("priceChangePercent")]
        public string PriceChangePercent { get; set; }

        [JsonProperty("weightedAvgPrice")]
        public string WeightedAvgPrice { get; set; }

        [JsonProperty("prevClosePrice")]
        public string PrevClosePrice { get; set; }

        [JsonProperty("lastPrice")]
        public string LastPrice { get; set; }

        [JsonProperty("lastQty")]
        public string LastQty { get; set; }

        [JsonProperty("bidPrice")]
        public string BidPrice { get; set; }

        [JsonProperty("askPrice")]
        public string AskPrice { get; set; }

        [JsonProperty("openPrice")]
        public string OpenPrice { get; set; }

        [JsonProperty("highPrice")]
        public string HighPrice { get; set; }
        
        [JsonProperty("lowPrice")]
        public string LowPrice { get; set; }

        [JsonProperty("volume")]
        public string Volume { get; set; }

        [JsonProperty("quoteVolume")]
        public string QuoteVolume { get; set; }

        [JsonProperty("openTime")]
        public long OpenTime { get; set; }
       
        [JsonProperty("closeTime")]
        public long CloseTime { get; set; }

        [JsonProperty("firstId")]
        public long FirstId { get; set; }

        [JsonProperty("lastId")]
        public long LastId { get; set; }

        [JsonProperty("count")]
        public long Count { get; set; }
    }

```

## GetSymbolPrice
Latest price for a symbol or symbols.

### Example
```c#
var result = binanceClient.GetSymbolPrice("BTCUSDT").Result;
```

### Method Signature
```c#
public async Task<dynamic> GetSymbolPrice(string symbol)
```

### Model for SymbolPrice
```c#
public class ModelSymbolPrice
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }
    }

```

## GetSymbolOrderBook
Best price/qty on the order book for a symbol or symbols.

### Example
```c#
var result = binanceClient.GetSymbolOrderBook("BTCUSDT").Result;
```

### Method Signature
```c#
public async Task<dynamic> GetSymbolOrderBook(string symbol)
```

### Model for SymbolOrderBook
```c#
 public class ModelSymbolOrderBook
    {
        [JsonProperty("symbol")]  
        public string Symbol { get; set; }

        [JsonProperty("bidPrice")]  
        public string BidPrice { get; set; }
        
        [JsonProperty("bidQty")]  
        public string BidQty { get; set; }

        [JsonProperty("askPrice")]  
        public string AskPrice { get; set; }

        [JsonProperty("askQty")]  
        public string AskQty { get; set; }
    }
```


## GetCandlestickData
Get candlestick bars for a symbol

### Example
```c#
DateTime dateTimeStart = new DateTime(2021, 4, 10);
DateTime dateTimeEnd = new DateTime(2021, 4, 12);
var result = binanceClient.GetCandlestickData("BTCUSDT",Models.Enums.TimeInterval.Hours_4, dateTimeStart,dateTimeEnd).Result;
```

### Method Signature
```c#
public async Task<IEnumerable<ModelCandlestick>> GetCandlestickData(string symbol, TimeInterval interval, DateTime? startTime = null, DateTime? endTime = null, int limit = 500)
```

### Model for CandlestickData
```c#
  public class ModelCandlestick
    {
        public long OpenTime { get; set; }
        
        public decimal Open { get; set; }
        
        public decimal High { get; set; }

        public decimal Low { get; set; }

        public decimal Close { get; set; }

        public decimal Volume { get; set; }

        public long CloseTime { get; set; }

        public decimal QuoteAssetVolume { get; set; }

        public int NumberOfTrades { get; set; }

        public decimal TakerBuyBaseAssetVolume { get; set; }

        public decimal TakerBuyQuoteAssetVolume { get; set; }

        public decimal Ignore { get; set; }
    }

```

## GetExchangeInfo
Get current exchange trading rules and symbol information

### Example
```c#
var result = binanceClient.GetExchangeInfo(new List<string>() { "BTCUSDT", "BNBUSDT" }).Result;
```

### Method Signature
```c#
public async Task<ModelExchangeInfo> GetExchangeInfo(List<string> symbols)
```

### Model for ExchangeInfo
```c#
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

```


## GetCurrentAveragePrice
Gets average price for specified symbol.

### Example

```c#
    var averagePrice = binanceClient.GetCurrentAveragePrice("BTCUSDT").Result;
```
### Method Signature
```c#
    public async Task<ModelCurrentAveragePrice> GetCurrentAveragePrice(string symbol)
```

### Model of CurrentAveragePrice
```c#
 public class ModelCurrentAveragePrice
    {
        
        [JsonProperty("mins")]
        public int Mins { get; set;  }

        [JsonProperty("price")]
        public string Price { get; set; } 
    }
```
![Icon](https://github.com/Spelchure/Binance.API/blob/master/Binance.API.Client/BinanceLogo.png?raw=true)
# Binance API Implementation in C# 
### Basic implementation of Binance API in C#


[![GitHub license](https://img.shields.io/github/license/spelchure/Binance.API)](https://github.com/Spelchure/Binance.API/blob/master/LICENSE)
![GitHub last commit](https://img.shields.io/github/last-commit/Spelchure/Binance.API?style=flat-square)
![GitHub top language](https://img.shields.io/github/languages/top/Spelchure/Binance.API?style=flat-square)

## Getting Started
Firstly create instance of the APIClient
```c#
var apiClient = new ApiClient("@API-KEY","@API-SECRET");
```
Create an instance of BinanceClient
```c#
var binanceClient = new BinanceClient(apiClient);
```
### Signature of ApiClient and BinanceClient Methods
```c#
public ApiClient(string apiKey, string apiSecret, string apiUrl = @"https://api1.binance.com", bool addDefaultHeaders = true)
public BinanceClient(IApiClient apiClient) 
```
- **apiKey** - *Key used to authenticate within the API. (Not required for MarketData or unsigned calls.)*
- **apiSecret** - *API secret to be used in signed API calls. (Not required for MarketData or unsigned calls.)*
- **apiUrl** - *Binance API base URL. (Optional)*
- **addDefaultHeaders** - *Add default headers or not.*
- **apiClient** - *Instance of ApiClient.*


## Features
- Well documented.
- **Asynchronous** calls to Binance API.
- **Includes** unit tests and **example** application.
- Currently only supports *MARKET_DATA* API calls.

## Documentation
Documentation resides in [Documentation](https://github.com/Spelchure/Binance.API/blob/master/Documentation) folder.
- Documentation for API calls and information:
  - [MarketData API calls](https://github.com/Spelchure/Binance.API/blob/master/Documentation/MarketDataMethods.md)
- Documentation about Project
  - [Project](https://github.com/Spelchure/Binance.API/blob/master/Documentation/Project.md)
- Doxygen generated documentation
  - [Doxygen](https://github.com/Spelchure/Binance.API/blob/master/Documentation/doxygen)

## Dependencies
*Project Target Framework:* **4.6** <br/>
[*Microsoft.CSharp*](https://www.nuget.org/packages/Microsoft.CSharp/) **4.7.0** <br/>
[*Newtonsoft.Json*](https://www.nuget.org/packages/Newtonsoft.Json/) **13.0.1** <br/>
[*System.ComponentModel*](https://www.nuget.org/packages/System.ComponentModel/) **4.3.0** <br/>

## License
This project licensed under [GNU GPL v3](https://www.gnu.org/licenses/gpl-3.0.txt).

## Thanks
Thanks for **morpheums** for some advice on coding. [Check his repository](https://github.com/morpheums/Binance.API.Csharp.Client) 

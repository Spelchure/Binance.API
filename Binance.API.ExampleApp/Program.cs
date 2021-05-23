using Binance.API.Client;
using System;
using System.Collections.Generic;
using System.IO;
using Binance.API.Client.Utilities;

/// <summary>
/// Example application for testing API
/// </summary>
namespace Binance.API.ExampleApp
{
    
    class Program
    {
        // File to write 
        private static readonly string fileName = "BinanceAPI.logs";
        private static readonly string API_KEY = ""; // Not required for market data calls.
        private static readonly string API_SECRET = ""; // Not required for market data calls. see: https://binance-docs.github.io/apidocs/spot/en/#endpoint-security-type

        static async void StartApiCalls()
        {

            Console.WriteLine("Calling API don't press any key...\n");
            try
            {
                StreamWriter fileStream = new StreamWriter(fileName, true);
                ApiClient apiClient = new ApiClient(API_KEY,API_SECRET); // Initialize ApiClient
                BinanceClient binanceClient = new BinanceClient(apiClient); // Initialize BinanceClient
                
                // First write DateTime
                string message = DateTime.Now.ToString();
                Console.WriteLine("{0}\n", message);
                fileStream.WriteLine("{0}\n", message);

                // TestConnectivity
                message = "Calling: TestConnectivity()";
                Console.WriteLine(message);
                var result = await binanceClient.TestConnectivity();
                fileStream.WriteLine(message);
                fileStream.WriteLine("\tResult: OK\n");
                fileStream.Flush();

                // CheckServerTime
                message = "Calling: CheckServerTime()";
                Console.WriteLine(message);
                result = await binanceClient.CheckServerTime();
                fileStream.WriteLine(message);
                fileStream.WriteLine("\tResult: {0}\n", result.ServerTime);
                fileStream.Flush();

                // GetOrderBook
                message = "Calling: GetOrderBook(symbol='BTCUSDT', limit=100)";
                Console.WriteLine(message);
                result = await binanceClient.GetOrderBook("BTCUSDT");
                fileStream.WriteLine(message);
                fileStream.WriteLine("\tResult: {0}\n", result.ToString());
                fileStream.Flush();

                // GetRecentTradesList
                message = "Calling: GetRecentTradesList(symbol='BTCUSDT', limit=500)";
                Console.WriteLine(message);
                result = await binanceClient.GetRecentTradesList("BTCUSDT");
                fileStream.WriteLine(message);
                fileStream.WriteLine("\tResult: {0}\n", result.ToString());
                fileStream.Flush();


                // GetAggregateTrades
                message = "Calling: GetAggregateTrades(symbol='BTCUSDT', limit=500)";
                Console.WriteLine(message);
                result = await binanceClient.GetAggregateTrades("BTCUSDT");
                fileStream.WriteLine(message);
                fileStream.WriteLine("\tResult: {0}\n", result.ToString());
                fileStream.Flush();
               
                // GetCurrentAveragePrice 
                message = "Calling: GetCurrentAveragePrice(symbol='BTCUSDT')";
                Console.WriteLine(message);
                result = await binanceClient.GetCurrentAveragePrice("BTCUSDT");
                fileStream.WriteLine(message);
                fileStream.WriteLine("\tResult: {0}\n", result.ToString());
                fileStream.Flush();


                // GetSymbolPrice 
                message = "Calling: GetSymbolPrice(symbol='BTCUSDT')";
                Console.WriteLine(message);
                result = await binanceClient.GetSymbolPrice("BTCUSDT");
                fileStream.WriteLine(message);
                fileStream.WriteLine("\tResult: {0}\n", result.ToString());
                fileStream.Flush();


                // GetSymbolOrderBook
                message = "Calling: GetSymbolOrderBook(symbol='BTCUSDT')";
                Console.WriteLine(message);
                result = await binanceClient.GetSymbolOrderBook("BTCUSDT");
                fileStream.WriteLine(message);
                fileStream.WriteLine("\tResult: {0}\n", result.ToString());
                fileStream.Flush();


                // GetCandlestickData

                DateTime dateTimeStart = new DateTime(2021, 4, 10);
                DateTime dateTimeEnd = new DateTime(2021, 4, 12);
                message = "Calling: GetCandlestickData(symbol='BTCUSDT', 4h,(2021,4,10),(2021,4,12))";
                Console.WriteLine(message);
                result = await binanceClient.GetCandlestickData("BTCUSDT",Models.Enums.TimeInterval.Hours_4, dateTimeStart,dateTimeEnd);
                fileStream.WriteLine(message);
                fileStream.WriteLine("\tResult: {0}\n", result.ToString());
                fileStream.Flush();

                // GetExchangeInfo
                message = "Calling: GetExchangeInfo(BTCUSDT)";  
                Console.WriteLine(message);
                result = await binanceClient.GetExchangeInfo(new List<string>() { "BTCUSDT" });
                fileStream.WriteLine(message);
                fileStream.WriteLine("\tResult: {0}\n", result.ToString());
                fileStream.Flush();

                // ParseFilter
                var parsedFilters = Utilities.ParseFilter(result.Symbols[0].Filters);


                fileStream.Close();
            } catch (Exception ex)
            {
                Console.WriteLine("[*] Exception while calling API: {0}:{1}", ex.GetType().Name , ex.Message);
                Console.WriteLine("\t[*] Stacktrace :  {0}", ex.StackTrace);
                Console.WriteLine("Press any key to close application...");
                return;
            }
            Console.WriteLine("All operation successfull. Writed to file: {0}", fileName);
            Console.WriteLine("Press any key to close application...");
        }

        static void Main(string[] args)
        {

            StartApiCalls(); 
            Console.ReadKey();
            return;
        }
    }
}

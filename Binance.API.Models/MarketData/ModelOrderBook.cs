using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binance.API.Models.MarketData
{
    
    /// <summary>
    /// Model for Order Book Offer
    /// </summary>
    public class ModelOrderBookOffer
    {
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
    }
    
    /// <summary>
    /// Model for Order Book
    /// https://binance-docs.github.io/apidocs/spot/en/#order-book
    /// Weight: Adjusted based on the limit:
    /// 5,10,20,50,100 : 1
    /// 500 : 5
    /// 1000 : 10
    /// 5000 : 50
    /// </summary>    
    public class ModelOrderBook
    {
        public long LastUpdateId { get; set; }

        public IEnumerable<ModelOrderBookOffer> Bids { get; set; }

        public IEnumerable<ModelOrderBookOffer> Asks { get; set; }
    }
}

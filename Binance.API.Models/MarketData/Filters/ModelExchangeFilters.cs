using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binance.API.Models.MarketData.Filters
{

    /// <summary>
    /// This filter defines the maximum number of orders an account is allowed to have open on the exchange
    /// https://binance-docs.github.io/apidocs/spot/en/#filters
    /// </summary>
    public class ModelExchangeMaxNumOrders : ModelFilter
    {
        public string MaxNumOrders { get; set; }
    }

    /// <summary>
    /// This filter defines the maximum number of "algo" orders an account is allowed to have open on the exchange.
    /// "Algo" orders are STOP_LOSS, STOP_LOSS_LIMIT, TAKE_PROFIT, and TAKE_PROFIT_LIMIT orders.
    /// https://binance-docs.github.io/apidocs/spot/en/#filters
    /// </summary>
    public class ModelExchangeMaxNumAlgoOrders : ModelFilter
    {
        public string MaxNumAlgoOrders { get; set; }
    }
}

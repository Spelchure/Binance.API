using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// https://binance-docs.github.io/apidocs/spot/en/#filters
namespace Binance.API.Models.MarketData.Filters
{

    /// <summary>
    /// Model for price filter
    /// Defines the price rules for a symbol
    /// PRICE_FILTER
    /// To pass:
    ///     price >= minPrice
    ///     price <= maxPrice
    ///     (price-minPrice) % tickSize == 0
    /// </summary>
    public class ModelPriceFilter : ModelFilter
    {
        /// <summary>
        /// minimum price/stopPrice allowed
        /// </summary>
        public decimal MinPrice { get; set; }
       
        /// <summary>
        /// maximum price/stopPrice allowed
        /// </summary>
        public decimal MaxPrice { get; set; }

        /// <summary>
        /// defines the intervals that a price/stopPrice can be increased/decreased by 
        /// </summary>
        public decimal TickSize { get; set; }
    }


    /// <summary>
    /// Model for PERCENT_PRICE filter
    /// The PERCENT_PRICE filter defines valid range for a price based on the average of the previous trades. 
    /// avgPriceMins is the number of minutes the average price is calculated over. 0 means the last price is used.
    /// To pass:
    ///     price <= weightedAveragePrice * multiplierUp
    ///     price >= weightedAveragePrice* multiplierDown
    /// </summary>
    public class ModelPercentPriceFilter : ModelFilter
    {
        public decimal MultiplierUp { get; set; }

        public decimal MultiplierDown { get; set; }

        public int AvgPriceMins { get; set; }
    }

    /// <summary>
    /// The LOT_SIZE filter defines the quantity (aka "lots" in auction terms) rules for a symbol
    /// To pass:
    ///     quantity >= minQty
    ///     quantity <= maxQty
    ///     (quantity-minQty) % stepSize == 0
    /// </summary>
    public class ModelLotSizeFilter : ModelFilter
    {

        /// <summary>
        /// defines the minimum quantity/icebergQty allowed.
        /// </summary>
        public decimal MinQty { get; set; }

        /// <summary>
        /// defines the maximum quantity/icebergQty allowed.
        /// </summary>
        public decimal MaxQty { get; set; }

        /// <summary>
        /// defines the intervals that a quantity/icebergQty can be increased/decreased by
        /// </summary>
        public decimal StepSize { get; set; }
    }

    /// <summary>
    /// The MIN_NOTIONAL filter defines the minimum notional value allowed for an order on a symbol
    /// An order's notional value is the price * quantity. If the order is an Algo order (e.g. STOP_LOSS_LIMIT), 
    /// then the notional value of the stopPrice * quantity will also be evaluated
    /// </summary>
    public class ModelMinNotionalFilter : ModelFilter
    {
        /// <summary>
        /// 
        /// </summary>
        public decimal MinNotional { get; set; }

        /// <summary>
        /// Determines whether or not the MIN_NOTIONAL filter will also be applied to MARKET orders
        /// </summary>
        public bool ApplyToMarket { get; set; }

        /// <summary>
        /// The number of minutes the average price is calculated over
        /// </summary>
        public int AvgPriceMins { get; set; }
    }

    /// <summary>
    /// Defines the maximum parts an iceberg order can have. The number of ICEBERG_PARTS is defined as CEIL(qty / icebergQty). 
    /// </summary>
    public class ModelIcebergPartsFilter : ModelFilter
    {
        public int Limit { get; set; }
    }

    /// <summary>
    /// Defines the quantity (aka "lots" in auction terms) rules for MARKET orders on a symbol
    /// To pass:
    ///     quantity >= minQty
    ///     quantity <= maxQty
    ///     (quantity-minQty) % stepSize == 0
    /// </summary>
    public class ModelMarketLotSizeFilter : ModelFilter
    {
        /// <summary>
        /// Defines the minimum quantity allowed. 
        /// </summary>        
        public decimal MinQty { get; set; }

        /// <summary>
        /// Defines the maximum quantity allowed
        /// </summary>
        public decimal MaxQty { get; set; }

        /// <summary>
        /// Defines the intervals that a quantity can be increased/decreased by.
        /// </summary>
        public decimal StepSize { get; set; }
    }

    /// <summary>
    /// Defines the maximum number of orders an account is allowed to have open on a symbol. 
    /// Note that both "algo" orders and normal orders are counted for this filter.
    /// </summary>
    public class ModelMaxNumOrdersFilter : ModelFilter
    {
        public int MaxNumOrders { get; set; }
    }

    /// <summary>
    /// Defines the maximum number of "algo" orders an account is allowed to have open on a symbol
    /// </summary>
    public class ModelMaxNumAlgoOrdersFilter : ModelFilter
    {
        public int MaxNumAlgoOrders { get; set; }
    }

    /// <summary>
    /// Defines the maximum number of ICEBERG orders an account is allowed to have open on a symbol.
    /// An ICEBERG order is any order where the icebergQty is > 0
    /// </summary>
    public class ModelMaxNumIcebergOrders : ModelFilter
    {
        public int MaxNumIcebergOrders { get; set; }
    }

    /// <summary>
    /// Defines the allowed maximum position an account can have on the base asset of a symbol.
    /// BUY orders will be rejected if the account's position is greater than the maximum position allowed.
    /// An account's position defined as the sum of the account's:
    ///    1. free balance of the base asset
    ///    2. locked balance of the base asset
    ///    3. sum of the qty of all open BUY orders
    /// </summary>
    public class ModelMaxPositionFilter : ModelFilter
    {
        public decimal MaxPosition { get; set; }
    }
}

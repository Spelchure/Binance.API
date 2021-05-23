using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binance.API.Models.MarketData.Filters
{

    public enum FilterTypes
    {
        ExchangeFilter,
        SymbolFilter
    }
    
    /// <summary>
    /// Base class for all filters
    /// </summary>
    public class ModelFilter
    {
        public string FilterType { get; set; }
        
    }
}

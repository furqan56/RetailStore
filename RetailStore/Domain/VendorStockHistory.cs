using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailStore.Domain
{
    public class VendorStockHistory
    {
        public int VendorId { get; set; }
        public virtual Vendor Vendor { get; set; }
        public int StockHistoryId { get; set; }
        public virtual StockHistory StockHistory { get; set; }
    }
}

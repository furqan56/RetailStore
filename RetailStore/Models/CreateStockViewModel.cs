using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailStore.Models
{
    public class CreateStockViewModel
    {
        public int ProductId { get; set; }
        public int VendorId { get; set; }
        public double UnitCost { get; set; }
        public double QtyPurchased { get; set; }
    }
}

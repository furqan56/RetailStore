using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailStore.Domain
{
    public class StockHistory
    {

        public int Id { get; set; }
        public int VendorId { get; set; }
        public int ProductId { get; set; }
        public double UnitCost{ get; set; }
        public Product Product { get; set; }
        public virtual Vendor Vendor { get; set; }
        public double Quantity { get; set; }
        public DateTime Date { get; set; }
    }
}

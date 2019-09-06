using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailStore.Domain
{
    public class SaleOrderDetail
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int SaleOrderId { get; set; }
        public double Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double LineTotal { get; set; }
        public DateTime Stamp { get; set; }
        public Product Product { get; set; }
        public SaleOrder SaleOrder { get; set; }

    }
}

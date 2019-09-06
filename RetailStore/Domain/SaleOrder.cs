using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailStore.Domain
{
    public class SaleOrder
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public double GrossTotal { get; set; }
        public double SubTotal { get; set; }
        public double BalanceDue { get; set; }
        public double Tax { get; set; }
        public double Discount { get; set; }
        public DateTime Stamp { get; set; }
        public virtual List<SaleOrderDetail> OderDetails{ get; set; }
    }
}

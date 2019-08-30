using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailStore.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double SalePrice  { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public double AverageUnitCost { get; set; }
        public double  Quantity { get; set; }


    }
}

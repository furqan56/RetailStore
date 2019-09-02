using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RetailStore.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string CategoryName { get; set; }
        [Range(1, Int32.MaxValue)]
        public double SalePrice { get; set; }
        public string Description { get; set; }
        [Required]
        public int CategoryId { get; set; }

        public double QtyAvailable { get; set; }
        public double UnitCost { get; set; }
    }
}

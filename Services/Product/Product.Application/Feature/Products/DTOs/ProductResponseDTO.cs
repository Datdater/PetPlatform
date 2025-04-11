using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Feature.Products.DTOs
{
    public class ProductResponseDTO 
    {
        public string ProductVariationId { get; set; }
        public decimal Price { get; set; }
        public int Inventory { get; set; }
    }
}

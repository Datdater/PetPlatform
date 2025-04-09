using Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Feature.Products.DTOs
{
    public class ProductDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Guid StoreId { get; set; }
        public string CategoryId { get; set; }
        public decimal Price { get; set; }
        public string ProductImage { get; set; }
    }
}

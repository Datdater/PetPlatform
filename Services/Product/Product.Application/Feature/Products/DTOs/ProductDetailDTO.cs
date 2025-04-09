using Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Feature.Products.DTOs
{
    public class ProductDetailDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Guid StoreId { get; set; }
        public string CategoryId { get; set; }
        public decimal Weight { get; set; }

        public decimal Length { get; set; }

        public decimal Height { get; set; }

        public decimal Width { get; set; }

        public List<Variation> Variations { get; set; }

        public List<VariantCombination> VariantCombinations { get; set; }
        public List<ProductImage> ProductImages { get; set; }
    }
}

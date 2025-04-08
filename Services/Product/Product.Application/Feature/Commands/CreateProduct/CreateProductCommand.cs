using MediatR;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Feature.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest
    {
        public string Name { get; set; }

        public Guid BrandId { get; set; }

        public Guid StoreId { get; set; }

        public Guid CategoryId { get; set; }

        public decimal BasePrice { get; set; }

        public decimal Weight { get; set; }

        public decimal Length { get; set; }

        public decimal Height { get; set; }

        public decimal Width { get; set; }

        public List<Variation> Variations { get; set; }

        public List<VariantCombination> VariantCombinations { get; set; }
        public List<ProductImage> ProductImages { get; set; }
    }
}

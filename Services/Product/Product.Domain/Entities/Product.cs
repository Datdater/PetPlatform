using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Product.Domain.Entities
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("isActive")]
        public bool IsActive { get; set; } = true;

        [BsonElement("storeId")]
        [BsonRepresentation(BsonType.String)]
        public Guid StoreId { get; set; }

        [BsonElement("categoryId")]
        [BsonRepresentation(BsonType.String)]
        public string CategoryId { get; set; }

        [BsonElement("weight")]
        public decimal Weight { get; set; }

        [BsonElement("length")]
        public decimal Length { get; set; }

        [BsonElement("height")]
        public decimal Height { get; set; }

        [BsonElement("width")]
        public decimal Width { get; set; }

        [BsonElement("views")]
        public int Views { get; set; } = 0;
        [BsonElement("price")]
        public decimal Price { get; set; }

        [BsonElement("inventory")]
        public int Inventory { get; set; }

        // Product variations (like color, size, etc.)
        [BsonElement("variations")]
        public List<Variation> Variations { get; set; }

        // Actual product variants with combinations of options
        [BsonElement("variantCombinations")]
        public List<VariantCombination> VariantCombinations { get; set; }

        // Product images
        [BsonElement("productImages")]
        public List<ProductImage> ProductImages { get; set; } = new List<ProductImage>();

        // Timestamps
        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [BsonElement("updatedAt")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }

    // Represents a variation type like "Color" or "Size"
    public class Variation
    {
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("options")]
        public List<VariationOption> Options { get; set; } = new List<VariationOption>();
    }

    public class VariationOption
    {
        [BsonElement("id")]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("image")]
        public string Image { get; set; }
    }

    public class VariantCombination
    {
        [BsonElement("id")]
        public string Id { get; set; }

        [BsonElement("options")]
        public List<SelectedOption> Options { get; set; } = new List<SelectedOption>();

        [BsonElement("price")]
        public decimal Price { get; set; }

        [BsonElement("inventory")]
        public int Inventory { get; set; }
        public string Image { get; set; } // URL to the image for this variant

    }

    public class SelectedOption
    {
        [BsonElement("variationName")]
        public string VariationName { get; set; }

        [BsonElement("optionId")]
        public string OptionId { get; set; }

        [BsonElement("optionName")]
        public string OptionName { get; set; }
    }

    public class ProductImage
    {
        [BsonElement("url")]
        public string Url { get; set; }

        [BsonElement("isMain")]
        public bool IsMain { get; set; }
    }
}

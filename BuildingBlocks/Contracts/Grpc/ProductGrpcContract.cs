using MagicOnion;
using MessagePack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Contracts.Grpc
{
    public interface IProductGrpcService : IService<IProductGrpcService>
    {
        UnaryResult<ProductResponse> GetProductByVariationIdAsync(string productVariationId);
    }

    [MessagePackObject]
    public record ProductResponse
    {
        [Key(0)]
        public string ProductVariationId { get; set; }
        [Key(1)]
        public string Name { get; set; }
        [Key(2)]
        public decimal Price { get; set; }
        [Key(3)]
        public int Inventory { get; set; }  
    }
}

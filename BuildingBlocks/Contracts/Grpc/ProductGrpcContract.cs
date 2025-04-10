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
        UnaryResult<ProductResponse> GetProductAsync(string id, string? productVariationId = null);
    }

    [MessagePackObject]
    public record ProductResponse
    {
        [Key(0)]
        public string Id { get; set; }
        [Key(1)]
        public string Name { get; set; }
        [Key(2)]
        public decimal Price { get; set; }
        [Key(3)]
        public int Inventory { get; set; }  
    }
}

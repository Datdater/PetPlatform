using BuildingBlocks.Contracts.Grpc;
using BuildingBlocks.Exception;
using MagicOnion;
using MagicOnion.Server;
using Mapster;
using MediatR;
using Product.Application.Feature.Products.Queries.GetProductById;
using Product.Domain.Entities;
using Product.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.GrpcServer
{
    public class ProductGrpcService : ServiceBase<IProductGrpcService>, IProductGrpcService
    {
        private IMediator _mediator;
        public ProductGrpcService(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async UnaryResult<ProductResponse> GetProductByVariationIdAsync(string productVariationId)
        {
            var product = await _mediator.Send(new GetProductByIdQuery() { ProductVariationId = productVariationId });
            ProductResponse productResponse = new ProductResponse()
            {
                ProductVariationId = product.ProductVariationId,
                Price = product.Price,
                Inventory = product.Inventory
            };
            return productResponse;
        }

    }
}

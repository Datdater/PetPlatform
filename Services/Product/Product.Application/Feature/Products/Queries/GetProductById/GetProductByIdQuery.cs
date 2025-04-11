using BuildingBlocks.Contracts.Grpc;
using MediatR;
using Product.Application.Feature.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Feature.Products.Queries.GetProductById
{
    public class GetProductByIdQuery : IRequest<ProductResponseDTO>
    {
        public string ProductVariationId { get; set; }
    }
    
}

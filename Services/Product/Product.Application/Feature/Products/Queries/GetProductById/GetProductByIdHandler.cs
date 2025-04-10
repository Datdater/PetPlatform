using BuildingBlocks.Contracts.Grpc;
using BuildingBlocks.Exception;
using MediatR;
using Product.Application.Feature.Products.DTOs;
using Product.Domain.Entities;
using Product.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Feature.Products.Queries.GetProductById
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductResponseDTO>
    {
        private readonly IProductRepository _productRepository;
        public GetProductByIdHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<ProductResponseDTO> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);
            if (product == null)
            {
                throw new NotFoundException(nameof(Product), request.Id);
            }
            if (request.ProductVariationId != null)
            {
                var productVariation = product.VariantCombinations.FirstOrDefault(x => x.Id == request.ProductVariationId);
                if (productVariation == null)
                {
                    throw new NotFoundException(nameof(VariantCombination), request.ProductVariationId);
                }
                return new ProductResponseDTO
                {
                    Id = product.Id.ToString(),
                    Name = product.Name,
                    Price = productVariation.Price,
                    Inventory = productVariation.Inventory
                };
            }
            else
            {
                return new ProductResponseDTO
                {
                    Id = product.Id.ToString(),
                    Name = product.Name,
                    Price = product.Price,
                    Inventory = product.Inventory
                };
            }
        }
    }
    
}

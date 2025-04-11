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
        private readonly IVariantProductRepository _variantProductRepository;
        public GetProductByIdHandler(IProductRepository productRepository, IVariantProductRepository variantProductRepository)
        {
            _variantProductRepository = variantProductRepository;
            _productRepository = productRepository;
        }
        public async Task<ProductResponseDTO> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var productVariation = await _variantProductRepository.GetByIdAsync(request.ProductVariationId);
            if (productVariation == null)
            {
                throw new NotFoundException(nameof(VariantCombination), request.ProductVariationId);
            }
            return new ProductResponseDTO
            {
                ProductVariationId = productVariation.Id.ToString(),
                Price = productVariation.Price,
                Inventory = productVariation.Inventory
            };

        }
    }

}

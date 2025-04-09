using AutoMapper;
using BuildingBlocks.Core;
using MediatR;
using Product.Application.Feature.Products.DTOs;
using Product.Application.Feature.Products.Queries.Specifications;
using Product.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Feature.Products.Queries.GetAllProduct
{
    public class GetAllProductHandler : IRequestHandler<GetAllProductQuery, Pagination<ProductDTO>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetAllProductHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<Pagination<ProductDTO>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var specification = new ProductSpecification(request);
            var productsRaw = await _productRepository.GetPagedWithSpecAsync(specification);
            var products = productsRaw.Items.Select(x => new ProductDTO()
            {
                Id = x.Id,
                Name = x.Name,
                ProductImage = x.ProductImages.FirstOrDefault(x => x.IsMain).ToString(),
                Price = x.VariantCombinations.MinBy(x => x.Price).Price,
                StoreId = x.StoreId,

            }).ToList();
            return new Pagination<ProductDTO>()
            {
                PageIndex = productsRaw.PageIndex,
                PageSize = productsRaw.PageSize,
                TotalItemsCount = productsRaw.TotalItemsCount,
                Items = products
            };
        }
    }
    
}

using AutoMapper;
using BuildingBlocks.Exception;
using MediatR;
using Product.Application.Feature.Products.DTOs;
using Product.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Feature.Products.Queries.GetProductDetail
{
    public class GetProductDetailHandler : IRequestHandler<GetProductSpecificQuery, ProductDetailDTO>
    {
        public readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public GetProductDetailHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }


        public async Task<ProductDetailDTO> Handle(GetProductSpecificQuery request, CancellationToken cancellationToken)
        {
            var productList = await _productRepository.GetAllAsync();
            var product = await _productRepository.GetByIdAsync(request.Id);
            
            if (product == null)
            {
                throw new NotFoundException(nameof(Product), request.Id);
            }
            var productDetail = _mapper.Map<ProductDetailDTO>(product);
            return productDetail;
        }
    }
}

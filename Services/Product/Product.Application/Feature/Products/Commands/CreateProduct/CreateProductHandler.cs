using AutoMapper;
using BuildingBlocks.Exception;
using MediatR;
using Product.Domain.Entities;
using Product.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Feature.Products.Commands.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly IProductRepository _productRepository;
        //private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly IVariantProductRepository _variantProductRepository;
        public CreateProductHandler(IProductRepository productRepository, IVariantProductRepository variantProductRepository , IMapper mapper)
        {
            _productRepository = productRepository;
            //_categoryRepository = categoryRepository;
            _mapper = mapper;
            _variantProductRepository = variantProductRepository;
        }
        public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            //var category = await _categoryRepository.GetByIdAsync(request.CategoryId);
            //if (category == null)
            //{
            //    throw new NotFoundException(nameof(Category), request.CategoryId);
            //}
            //var store;
            var product = _mapper.Map<Domain.Entities.Product>(request);
            await _productRepository.AddAsync(product);
            await _variantProductRepository.AddRangeAsync(request.VariantCombinations);
        }
    }
}

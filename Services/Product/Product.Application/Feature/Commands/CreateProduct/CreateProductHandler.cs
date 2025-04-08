using MediatR;
using Product.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Feature.Commands.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            _productRepository.AddAsync(request.VariantCombinations);
            throw new NotImplementedException();
        }
    }
}

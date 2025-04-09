using MediatR;
using Product.Application.Feature.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Feature.Products.Queries.GetProductDetail
{
    public class GetProductSpecificQuery : IRequest<ProductDetailDTO>
    {
        public string Id { get; set; }
    }
}

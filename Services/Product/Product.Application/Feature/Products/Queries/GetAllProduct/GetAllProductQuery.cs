using BuildingBlocks.Core;
using MediatR;
using Product.Application.Feature.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Feature.Products.Queries.GetAllProduct
{
    public class GetAllProductQuery : IRequest<Pagination<ProductDTO>>
    {
        public string? SearchTerm { get; set; }
        public string? Category { get; set; }
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}

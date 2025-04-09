using BuildingBlocks.Data.Specifications;
using Product.Application.Feature.Products.Queries.GetAllProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Feature.Products.Queries.Specifications
{
    public class ProductSpecification : BaseSpecification<Domain.Entities.Product>
    {
        public ProductSpecification(GetAllProductQuery query) : base(p => ( string.IsNullOrEmpty(query.SearchTerm) || p.Name.Contains(query.SearchTerm)))
        {
                AddOrderBy(p => p.Name);
                ApplyPaging((query.PageIndex - 1) * query.PageSize, query.PageSize);
        }
    }
}

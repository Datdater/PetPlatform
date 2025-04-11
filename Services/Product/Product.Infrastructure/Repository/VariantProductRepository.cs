using BuildingBlocks.Data.Repository;
using Product.Domain.Entities;
using Product.Domain.Repository;
using Product.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Infrastructure.Repository
{
    public class VariantProductRepository : MongoRepository<VariantCombination, ProductContext>, IVariantProductRepository
    {
        public VariantProductRepository(ProductContext mongoDBContext) : base(mongoDBContext)
        {
        }
    }
    
}

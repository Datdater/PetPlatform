using BuildingBlocks.Data.Repository;
using Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain.Repository
{
    public interface IVariantProductRepository : IRepository<VariantCombination>
    {
    }
    
}

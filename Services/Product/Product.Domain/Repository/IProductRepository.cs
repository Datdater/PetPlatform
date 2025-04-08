using BuildingBlocks.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain.Repository
{
    public interface IProductRepository : IRepository<Domain.Entities.Product>
    {
        
    }
}

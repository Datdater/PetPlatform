using BuildingBlocks.Data.Repository;
using MongoDB.Driver;
using Product.Domain.Repository;
using Product.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Infrastructure.Repository
{
    public class ProductRepository : MongoRepository<Domain.Entities.Product, ProductContext>, IProductRepository
    {
        public ProductRepository(ProductContext mongoDBContext) : base(mongoDBContext)
        {
        }
    }

}

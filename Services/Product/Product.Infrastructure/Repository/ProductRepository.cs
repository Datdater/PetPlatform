using BuildingBlocks.Data.Repository;
using MongoDB.Driver;
using Product.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Infrastructure.Repository
{
    public class ProductRepository : MongoRepository<Domain.Entities.Product>, Domain.Repository.IProductRepository
    {
        public ProductRepository(IMongoDatabase database) : base(database)
        {
            
        }
    }

}

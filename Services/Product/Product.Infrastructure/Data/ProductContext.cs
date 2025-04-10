using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MongoDB.Driver;
using MongoDB.Driver.Core.Misc;
using Microsoft.Extensions.Configuration;
using Product.Domain.Entities;
using BuildingBlocks.Data.Repository;
namespace Product.Infrastructure.Data
{
    public class ProductContext : MongoDBContext
    {
        public ProductContext(IConfiguration configuration) : base(configuration)
        {
        }

        public IMongoCollection<Domain.Entities.Product> Products { get; }
        public IMongoCollection<Category> Categories { get; }
    }

}

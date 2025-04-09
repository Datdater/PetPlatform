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
namespace Product.Infrastructure.Data
{
    public class ProductContext
    {
        public IMongoDatabase _database;

        public ProductContext(IConfiguration configuration)
        {
            var connectionString = configuration.GetSection("DatabaseSettings:ConnectionString").Value;
            var databaseName = configuration.GetSection("DatabaseSettings:DatabaseName").Value;

            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);

            Products = _database.GetCollection<Domain.Entities.Product>("Products");
            Categories = _database.GetCollection<Category>("Categories");
        }

        public IMongoCollection<Domain.Entities.Product> Products { get; }
        public IMongoCollection<Category> Categories { get; }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
namespace Product.Infrastructure.Data
{
    public class ProductContext
    {
        private readonly IMongoDatabase _database;

        public ProductContext(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);

            Products = _database.GetCollection<Domain.Entities.Product>("Products");
            VariantCombinations = _database.GetCollection<Domain.Entities.VariantCombination>("VariantCombinations");
        }

        public IMongoCollection<Domain.Entities.Product> Products { get; }
        public IMongoCollection<Domain.Entities.VariantCombination> VariantCombinations { get; }
        public IMongoCollection<Domain.Entities.Variation> Variations { get; }
    }
}

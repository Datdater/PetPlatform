using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Data.Repository
{
    public class MongoDBContext
    {
        public IMongoDatabase Database;
        public IMongoCollection<T> GetCollection<T>(string? name = null)
        {
            return Database.GetCollection<T>(name ?? typeof(T).Name.ToLower());
        }
        public MongoDBContext(IConfiguration configuration)
        {
            var connectionString = configuration.GetSection("DatabaseSettings:ConnectionString").Value;
            var databaseName = configuration.GetSection("DatabaseSettings:DatabaseName").Value;

            var client = new MongoClient(connectionString);
            Database = client.GetDatabase(databaseName);
            
        }
    }
}

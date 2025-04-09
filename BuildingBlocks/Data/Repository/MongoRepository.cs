using BuildingBlocks.Core;
using BuildingBlocks.Data.Specifications;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Data.Repository
{
    public class MongoRepository<T> : IRepository<T> where T : class
    {
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<T> _collection;

        public MongoRepository(IMongoDatabase database)
        {
            _database = database;
            _collection = database.GetCollection<T>(typeof(T).Name + "s");
        }

        public async Task<T> GetByIdAsync(string id)
        {
            if (!ObjectId.TryParse(id, out var objectId))
            {
                throw new ArgumentException("Invalid ID format", nameof(id));
            }
            var filter = Builders<T>.Filter.Eq("_id", objectId);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _collection.Find(predicate).ToListAsync();
        }

        public async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await _collection.Find(predicate).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<T> GetBySpecAsync(ISpecification<T> spec)
        {
            var query = ApplySpecification(spec);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Pagination<T>> GetPagedWithSpecAsync(ISpecification<T> spec)
        {
            var query = ApplySpecification(spec);
            var count = await query.CountDocumentsAsync();
            var items = await query.ToListAsync();

            return new Pagination<T>
            {
                PageIndex = spec.Skip / spec.Take + 1,
                PageSize = spec.Take,
                Items = items,
                TotalItemsCount = (int)count
            };
        }

        public async Task<Pagination<T>> GetPagedAsync(int pageIndex, int pageSize)
        {
            var count = await _collection.CountDocumentsAsync(_ => true);
            var items = await _collection.Find(_ => true)
                .Skip((pageIndex - 1) * pageSize)
                .Limit(pageSize)
                .ToListAsync();

            return new Pagination<T>
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Items = items,
                TotalItemsCount = (int)count
            };
        }

        public async Task<Pagination<T>> GetPagedAsync(
            Expression<Func<T, bool>> predicate,
            int pageIndex,
            int pageSize,
            Expression<Func<T, object>> orderBy = null,
            bool ascending = true)
        {
            var query = _collection.Find(predicate);

            if (orderBy != null)
            {
                var sort = ascending
                    ? Builders<T>.Sort.Ascending(orderBy)
                    : Builders<T>.Sort.Descending(orderBy);
                query = query.Sort(sort);
            }

            var count = await query.CountDocumentsAsync();
            var items = await query
                .Skip((pageIndex - 1) * pageSize)
                .Limit(pageSize)
                .ToListAsync();

            return new Pagination<T>
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Items = items,
                TotalItemsCount = (int)count
            };
        }

        public async Task AddAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _collection.InsertManyAsync(entities);
        }

        public async Task UpdateAsync(T entity)
        {
            var id = entity.GetType().GetProperty("Id")?.GetValue(entity)?.ToString();
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("Entity must have an Id property");

            var filter = Builders<T>.Filter.Eq("_id", id);
            await _collection.ReplaceOneAsync(filter, entity);
        }

        public async Task DeleteAsync(string id)
        {
            var filter = Builders<T>.Filter.Eq("_id", id);
            await _collection.DeleteOneAsync(filter);
        }

        public async Task DeleteAsync(T entity)
        {
            var id = entity.GetType().GetProperty("Id")?.GetValue(entity)?.ToString();
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("Entity must have an Id property");

            await DeleteAsync(id);
        }

        private IFindFluent<T, T> ApplySpecification(ISpecification<T> spec)
        {
            var query = _collection.Find(spec.Criteria ?? (_ => true));

            if (spec.OrderBy != null)
                query = query.Sort(Builders<T>.Sort.Ascending(spec.OrderBy));

            if (spec.OrderByDescending != null)
                query = query.Sort(Builders<T>.Sort.Descending(spec.OrderByDescending));

            if (spec.IsPagingEnabled)
                query = query.Skip(spec.Skip).Limit(spec.Take);

            return query;
        }
    }
}

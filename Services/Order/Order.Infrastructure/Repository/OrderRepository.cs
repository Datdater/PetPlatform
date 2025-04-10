using BuildingBlocks.Core;
using BuildingBlocks.Data.Specifications;
using Order.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Order.Infrastructure.Repository
{
    public class OrderRepository : IOrderRepository
    {
        //private readonly OrderContext _orderContext;
        //private readonly IMongoCollection<Order> _collection;
        //private IClientSessionHandle _session;
        //public OrderRepository(OrderContext orderContext)
        //{
        //    _orderContext = orderContext;
        //    _collection = _orderContext.GetCollection<Order>(typeof(Order).Name.ToLower());
        //}
        public OrderRepository()
        {
        }

        public Task AddAsync(Domain.Entities.Order entity)
        {
            throw new NotImplementedException();
        }

        public Task AddRangeAsync(IEnumerable<Domain.Entities.Order> entities)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Domain.Entities.Order entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Domain.Entities.Order>> FindAsync(Expression<Func<Domain.Entities.Order, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Domain.Entities.Order>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Entities.Order> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Entities.Order> GetBySpecAsync(ISpecification<Domain.Entities.Order> spec)
        {
            throw new NotImplementedException();
        }

        public Task<Pagination<Domain.Entities.Order>> GetPagedAsync(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<Pagination<Domain.Entities.Order>> GetPagedAsync(Expression<Func<Domain.Entities.Order, bool>> predicate, int pageIndex, int pageSize, Expression<Func<Domain.Entities.Order, object>> orderBy = null, bool ascending = true)
        {
            throw new NotImplementedException();
        }

        public Task<Pagination<Domain.Entities.Order>> GetPagedWithSpecAsync(ISpecification<Domain.Entities.Order> spec)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Entities.Order> SingleOrDefaultAsync(Expression<Func<Domain.Entities.Order, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Domain.Entities.Order entity)
        {
            throw new NotImplementedException();
        }
    }
}

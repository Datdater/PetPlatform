using BuildingBlocks.Core;
using BuildingBlocks.Data.Specifications;
using Order.Domain.Entities;
using Order.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Order.Infrastructure.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public Task AddAsync(OrderDetail entity)
        {
            throw new NotImplementedException();
        }

        public Task AddRangeAsync(IEnumerable<OrderDetail> entities)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(OrderDetail entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderDetail>> FindAsync(Expression<Func<OrderDetail, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderDetail>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OrderDetail> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<OrderDetail> GetBySpecAsync(ISpecification<OrderDetail> spec)
        {
            throw new NotImplementedException();
        }

        public Task<Pagination<OrderDetail>> GetPagedAsync(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<Pagination<OrderDetail>> GetPagedAsync(Expression<Func<OrderDetail, bool>> predicate, int pageIndex, int pageSize, Expression<Func<OrderDetail, object>> orderBy = null, bool ascending = true)
        {
            throw new NotImplementedException();
        }

        public Task<Pagination<OrderDetail>> GetPagedWithSpecAsync(ISpecification<OrderDetail> spec)
        {
            throw new NotImplementedException();
        }

        public Task<OrderDetail> SingleOrDefaultAsync(Expression<Func<OrderDetail, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(OrderDetail entity)
        {
            throw new NotImplementedException();
        }
    }
}

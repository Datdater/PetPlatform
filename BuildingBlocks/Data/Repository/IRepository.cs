using BuildingBlocks.Core;
using BuildingBlocks.Data.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Data.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(string id);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetBySpecAsync(ISpecification<T> spec);
        Task<Pagination<T>> GetPagedWithSpecAsync(ISpecification<T> spec);
        // New pagination methods
        Task<Pagination<T>> GetPagedAsync(int pageIndex, int pageSize);
        Task<Pagination<T>> GetPagedAsync(
            Expression<Func<T, bool>> predicate,
            int pageIndex,
            int pageSize,
            Expression<Func<T, object>> orderBy = null,
            bool ascending = true);

        // Existing methods
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        Task UpdateAsync(T entity);
        Task DeleteAsync(string id);
        Task DeleteAsync(T entity);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace aYo.Database.Abstract
{
    public interface IRepository<T> where T : class, new()
    {
        Task<T> GetByIdAsync(int id);
        Task<T> GetByFirstOrDefaultAsync(Expression<Func<T, bool>> exp, Expression<Func<T, object>> include = null);
        Task<IEnumerable<T>> GetByExpressionAsync(Expression<Func<T, bool>> exp, Expression<Func<T, object>> include = null);
        Task<IQueryable<T>> GetByQueryAsync(Expression<Func<T, bool>> filter, Func<IQueryable<T>,
            IOrderedQueryable<T>> orderBy = null, List<Expression<Func<T, object>>> include = null,
            int? page = null, int? size = null);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task RemoveAsync(int id);
    }
}

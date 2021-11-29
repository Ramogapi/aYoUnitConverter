using aYo.Database.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace aYo.Database.Definitions
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        internal DbSet<T> _entity;
        internal IDbContext _context;
        public Repository(IDbContext context)
        {
            _context = context;
            _entity = context.GetEntity<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _entity.AddAsync(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entity.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetByExpressionAsync(Expression<Func<T, bool>> exp, Expression<Func<T, object>> include = null)
        {
            if (include != null)
                return await _entity.Include(include).Where(exp).ToListAsync();
            return await _entity.Where(exp).ToListAsync();
        }

        public async Task<IQueryable<T>> GetByQueryAsync(Expression<Func<T, bool>> filter, Func<IQueryable<T>,
            IOrderedQueryable<T>> orderBy = null, List<Expression<Func<T, object>>> includeProperties = null,
            int? page = null, int? size = null)
        {
            IQueryable<T> query = _entity;
            if (includeProperties != null)
                includeProperties.ForEach(i => { query = query.Include(i); });
            if (filter != null)
                query = query.Where(filter);
            if (orderBy != null)
                query = orderBy(query);
            if (page != null && size != null)
                query = query
                    .Skip((page.Value - 1) * size.Value)
                    .Take(size.Value);
            return await Task.FromResult(query);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _entity.FindAsync(id);
        }

        public async Task<T> GetByFirstOrDefaultAsync(Expression<Func<T, bool>> exp, Expression<Func<T, object>> include = null)
        {
            if (include != null)
                return await _entity.Include(include).FirstOrDefaultAsync(exp);
            return await _entity.FirstOrDefaultAsync(exp);
        }

        public async Task RemoveAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity is null)
                return;
            _entity.Remove(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            _entity.Update(entity);
            await Task.CompletedTask;
        }
    }
}

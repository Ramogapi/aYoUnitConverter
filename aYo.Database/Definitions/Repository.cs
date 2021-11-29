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
    }
}

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
    }
}

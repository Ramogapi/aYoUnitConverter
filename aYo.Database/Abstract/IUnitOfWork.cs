using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace aYo.Database.Abstract
{
    public interface IUnitOfWork
    {
        IRepository<T> Repository<T>() where T : class, new();
        IDbContext Context();
    }
}

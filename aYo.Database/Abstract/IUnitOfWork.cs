using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace aYo.Database.Abstract
{
    public interface IUnitOfWork
    {
        Task RollBackAsync();
        Task<int> CommitAsync();
        IRepository<T> Repository<T>() where T : class, new();
        Task DisposeAsync();
        IDbContext Context();
        bool HasChanges();
    }
}

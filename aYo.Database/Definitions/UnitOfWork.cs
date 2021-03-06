using aYo.Database.Abstract;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace aYo.Database.Definitions
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbContext _context;
        private Hashtable _repository;
        public UnitOfWork(IDbContext context)
        {
            _context = context;
        }

        public IDbContext Context()
        {
            return _context;
        }

        public IRepository<T> Repository<T>() where T : class, new()
        {
            if (_repository == null)
                _repository = new Hashtable();
            var name = typeof(T).Name;
            if (!_repository.ContainsKey(name))
            {
                var type = typeof(Repository<>);
                var instance = Activator.CreateInstance(type.MakeGenericType(typeof(T)), _context);
                _repository.Add(name, instance);
            }
            return (IRepository<T>)_repository[name];
        }
    }
}

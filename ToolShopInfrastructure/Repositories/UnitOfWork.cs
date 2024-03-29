using Ardalis.Specification;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolShopApplication.DataBase;
using ToolShopDomainCore.Domain;

namespace ToolShopInfrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ToolShopDbContext _dbContext;

        private readonly Hashtable _repositories = new();
        private bool _disposed;

        public UnitOfWork(ToolShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public IRepository<T> Repository<T>() where T : Entity<int>
        {
            var type = typeof(T).Name;
            if (_repositories.ContainsKey(type)) return (IRepository<T>)_repositories[type]!;

            var repositoryType = typeof(Repository<>);
            var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _dbContext);
            _repositories.Add(type, repositoryInstance);

            return (IRepository<T>)_repositories[type]!;
        }




         void IDisposable.Dispose() 
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
           
        }
        public async Task<int> SaveChangesAsync()
        {
            var res = await _dbContext.SaveChangesAsync();
            return res;
        }
    }
}

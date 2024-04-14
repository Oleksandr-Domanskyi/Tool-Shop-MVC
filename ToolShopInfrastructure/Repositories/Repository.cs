using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToolShopDomainCore.Domain;

namespace ToolShopInfrastructure.Repositories
{
    public class Repository<T> : RepositoryBase<T>,IRepository<T> where T : Entity<int>
    {
        private readonly DbContext _dbContext;

        public Repository(DbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            return await _dbContext.SaveChangesAsync(cancellationToken); 
        }

        public override async Task<T> AddAsync(T entity, CancellationToken cancellationToken = new())
        {
            await _dbContext.Set<T>().AddAsync(entity);
            return entity;
        }
        public override async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            _dbContext.Set<T>().Update(entity);
        }

        public override async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            _dbContext.Set<T>().Remove(entity);

            await SaveChangesAsync(cancellationToken);
        }
        public override async Task<T?> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken = default)
                => await _dbContext.Set<T>().FindAsync(new object[] { id }, cancellationToken: cancellationToken);
        
        public override async Task<List<T>> ListAsync(CancellationToken cancellationToken = default)
                => await _dbContext.Set<T>().ToListAsync(cancellationToken);



    }
}

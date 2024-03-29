using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            throw new NotImplementedException("SaveChangesAsync can be only used by UnitOfWork.");
        }

        public override async Task<T> AddAsync(T entity, CancellationToken cancellationToken = new())
        {
            await _dbContext.Set<T>().AddAsync(entity, cancellationToken);
            return entity;
        }
        public override async Task<List<T>> ListAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<T>().ToListAsync(cancellationToken);
        }
    }
}

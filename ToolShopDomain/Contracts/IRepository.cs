using ToolShopDomainCore.Domain;

namespace ToolShopInfrastructure.Repositories
{
    public interface IRepository<T> where T : Entity<int>
    {
        Task<List<T>> ListAsync(CancellationToken cancellationToken = default);
        Task<T> AddAsync(T entity, CancellationToken cancellationToken = new());
    }
}
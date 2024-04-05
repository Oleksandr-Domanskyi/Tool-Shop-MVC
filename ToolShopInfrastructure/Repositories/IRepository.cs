using ToolShopDomainCore.Domain;

namespace ToolShopInfrastructure.Repositories
{
    public interface IRepository<T> where T : Entity<int>
    {
        Task<List<T>> ListAsync(CancellationToken cancellationToken = default);
        Task<T> AddAsync(T entity, CancellationToken cancellationToken = new());
        Task<T?> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken = default);
        Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
    }
}
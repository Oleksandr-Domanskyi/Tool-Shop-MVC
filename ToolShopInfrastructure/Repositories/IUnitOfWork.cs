using ToolShopDomainCore.Domain;

namespace ToolShopInfrastructure.Repositories
{
    public interface IUnitOfWork:IDisposable
    {
        Task<int> SaveChangesAsync();
        IRepository<T> Repository<T>() where T : Entity<int>;
    }
}
using FluentResults;
using ToolShopDomainCore.Domain;

namespace ToolShopInfrastructure.Services
{
    public interface IEntityService<EntityType> where EntityType : Entity<int>
    {
        Task<Result<List<EntityType>>> GetListAsync();
    }
}
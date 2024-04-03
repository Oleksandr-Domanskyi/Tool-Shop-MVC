using FluentResults;
using ToolShopDomainCore.Domain;

namespace ToolShopInfrastructure.Services
{
    public interface IEntityService<EntityType> where EntityType : Entity<int>
    {
        Task<Result<List<EntityType>>> GetListAsync();
        Task<Result<EntityType>> GetByIdAsync(int id);
        Task<Result<EntityType>> AddEntityAsync(EntityType entity);
    }
}
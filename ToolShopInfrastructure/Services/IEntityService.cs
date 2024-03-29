using ToolShopDomainCore.Domain;

namespace ToolShopInfrastructure.Services
{
    public interface IEntityService<EntityType> where EntityType : Entity<int>
    {
    }
}
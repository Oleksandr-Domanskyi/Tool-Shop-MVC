using Ardalis.Specification;
using ToolShopDomainCore.Domain;

namespace ToolShopInfrastructure.Services
{
    public interface IDictionaryService<EntityType, EntityCreate, EntityUpdate>:
        IEntityService<EntityType>,IService where EntityType : Entity<int>
    {
    }
}
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolShopDomainCore.Domain;

namespace ToolShopInfrastructure.Services
{
    public class DictionaryService<EntityType, EntityCreate,EntityUpdate>:EntityService<EntityType>, IDictionaryService<EntityType, EntityCreate, EntityUpdate> where EntityType:Entity<int>
    {
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolShopDomainCore.Domain
{
    public class Entity<TId>:IEntity<TId>
    {
        protected TId _id;
        public TId Id { get=>_id; set=>_id=value;}
    }
}

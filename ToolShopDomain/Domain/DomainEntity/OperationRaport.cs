using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolShopDomainCore.Domain.Entity
{
    public class OperationRaport:Entity<int>
    {
        public string Operation { get; set; } = default!;
        public string UserName { get; set; } = default!;
        public DateTime DateOfRealising { get; set; } = DateTime.Now;
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolShopDomainCore.Domain.Enums;

namespace ToolShopDomainCore.Domain.Entity
{
    public class ToolProfile: Entity<int>
    {
        public string Name { get; set; } = default!;
        public decimal Price { get; set; } = default!;
        public string? Description { get; set; }
        public ImageModel? image { get; set; }

        public string Category { get; set; } = default!;
    }
  
}

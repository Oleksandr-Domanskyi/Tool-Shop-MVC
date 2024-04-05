using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolShopDomainCore.Domain.Entity;

namespace ToolShopApplication.DataTransferObject
{
    public class ToolProfileDto
    {
        public int Id { get; set; } = default!;
        public string Name { get; set; } = default!;
        public decimal Price { get; set; } = default!;
        public string? Description { get; set; }
        public ImageModel? image { get; set; }

        public string Category { get; set; } = default!;
    }
}

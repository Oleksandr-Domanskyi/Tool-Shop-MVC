using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using ToolShopDomainCore.Domain.Entity;
using ToolShopDomainCore.Domain.Enums;

namespace ToolShopApplication.DataTransferObject
{
    public class ToolProfileRequest:OperationRaport
    {
        public int? Id { get; set; } = 0;
        public string Name { get; set; } = default!;
        public decimal Price { get; set; } = default!;
        public string? Description { get; set; }
        public IFormFile Image { get; set; } = default!;
        public Category Category { get; set; }

       

      
    }
}

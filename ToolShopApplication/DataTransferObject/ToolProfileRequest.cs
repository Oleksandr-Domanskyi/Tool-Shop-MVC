using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using ToolShopDomainCore.Domain.Entity;
using ToolShopDomainCore.Domain.Enums;

namespace ToolShopApplication.DataTransferObject
{
    public class ToolProfileRequest
    {
        public int? Id { get; set; } = 0;
        public string Name { get; set; } = default!;
        public decimal Price { get; set; } = default!;
        public string? Description { get; set; }
        public IFormFile Image { get; set; } = default!;
        public Category Category { get; set; }

        public static ToolProfile ToDomain(ToolProfileRequest request)
        {
            return new ToolProfile()
            {
                Name = request.Name,
                Price = request.Price,
                Description = request.Description,
                Category = Convert.ToString(request.Category),
                image = new ImageModel()
                {
                    ImageName = request.Image!.FileName,
                    FileType = request.Image.ContentType,
                    DataFile = GetBytes(request.Image)
                }
            };
        }

        private static byte[] GetBytes(IFormFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}

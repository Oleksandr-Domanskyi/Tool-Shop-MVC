using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolShopDomainCore.Domain.Entity;

namespace ToolShopApplication.Helpers
{
    public static class ImageHandler
    {
        public static ImageModel ImageToByteParse(IFormFile file)
               => new ImageModel
               {
                   ImageName = file.FileName,
                   FileType = file.ContentType,
                   DataFile = GetBytes(file)
               };
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

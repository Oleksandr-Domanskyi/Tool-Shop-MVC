using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ToolShopDomainCore.Domain.Entity
{
    public class ImageModel
    {
        public string? ImageName { get; set; }
        public string? FileType { get; set; }
        public byte[]? DataFile { get; set; }
    }
}

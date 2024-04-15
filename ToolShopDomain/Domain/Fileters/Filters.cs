using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolShopDomainCore.Domain.Fileters
{
    public enum Perpage
    {
       InPage5 = 5,
       InPage10 = 10,
       InPage25 = 25,
       InPage50 = 50
    }
    public class Filters
    {
        public string? SortBy { get; set; }
        public Perpage perPage { get; set; } = Perpage.InPage10;
        public string? OrderBy { get; set; }
        public bool IsOn { get; set; }
    }

   
}

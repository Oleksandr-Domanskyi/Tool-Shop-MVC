using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolShopApplication.Services.Filter;

namespace ToolShopDomainCore.Domain.Fileters
{
    public enum Perpage
    {
       InPage5 = 5,
       InPage10 = 10,
       InPage25 = 25,
       InPage50 = 50
    }
    public class Filters<TReq> where TReq : class
    {
        public Result<List<TReq>>? entity { get; set; }
        public string? SortBy { get; set; }
        public string? SortDirection { get; set; } 
        public Perpage perPage { get; set; } = Perpage.InPage10;
        public string? OrderBy { get; set; }



       
    }

   
}

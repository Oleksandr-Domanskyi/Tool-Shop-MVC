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


        public int? StartPage { get; set; }
        public int? LastPage { get; set; }
        public int CurrentPage { get; set; }
        public int perPage { get; set; } = (int)Perpage.InPage5;

        public int TotalPages => GetTotalPages(entity, perPage);

        public int GetTotalPages(Result<List<TReq>>? entity, int perPage)
        {
            if (entity == null || entity.Value == null)
            {
                return 0;
            }

            return (int)Math.Ceiling(entity.Value.Count() / (decimal)perPage);
        }


        

       
    }
}

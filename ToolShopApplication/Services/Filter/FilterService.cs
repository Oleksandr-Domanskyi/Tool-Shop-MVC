using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ToolShopDomainCore.Domain;
using ToolShopDomainCore.Domain.Fileters;

namespace ToolShopApplication.Services.Filter
{
    public class FilterService<TDomain> : IFilterService<TDomain> where TDomain : class
    {
        

        public Task<Filters<TDomain>> AddFilters(Filters<TDomain> domain)
        {
            if (domain.SortBy == null || domain.SortDirection == null)
            {
                domain.entity = Result.Try(() => domain.entity!.Value.Reverse<TDomain>().ToList());
                return Task.FromResult(Pager(domain));
            }

            PropertyInfo? property = typeof(TDomain).GetProperty(domain.SortBy);

            if (property == null)
            {
                throw new ArgumentException($"Property {domain.SortBy} not found in type {typeof(TDomain).Name}");
            }

            //IEnumerable<TDomain> sortedDomain;

            if (domain.SortDirection == "ascending")
            {
                domain.entity = Result.Try(()=>domain.entity!.Value.OrderBy(x => property.GetValue(x)).ToList());
            }
            else
            {
                domain.entity = Result.Try(() => domain.entity!.Value.OrderByDescending(x => property.GetValue(x)).ToList());
            }
            
            return Task.FromResult(Pager(domain));
        }

        private Filters<TDomain> Pager(Filters<TDomain> domain)
        {
            int reSkip = (domain.CurrentPage - 1) * domain.perPage;

            domain.GetTotalPages(domain.entity, domain.perPage);

            domain.StartPage = domain.CurrentPage - 5;
            domain.LastPage = domain.CurrentPage + 4;

            if (domain.StartPage <= 0)
            {
                domain.LastPage = domain.LastPage - (domain.StartPage - 1);
                domain.StartPage = 1;
            }
            if (domain.LastPage > domain.TotalPages)
            {
                domain.LastPage = domain.TotalPages;
                if(domain.LastPage > 10)
                {
                    domain.StartPage = domain.LastPage - 9;
                }
            }
            domain.entity = Result.Try(() => domain.entity!.Value.Skip(reSkip).Take(domain.perPage).ToList()); 
            
            return domain;
        }
    }
}

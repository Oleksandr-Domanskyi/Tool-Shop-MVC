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
        

        public Task<IEnumerable<TDomain>> AddFilters(Filters<TDomain> domain)
        {
            if (domain.SortBy == null || domain.SortDirection == null)
            {
                var domains = domain.entity!.Value.Reverse<TDomain>().ToList();
                return Task.FromResult<IEnumerable<TDomain>>(domains);
            }

            PropertyInfo? property = typeof(TDomain).GetProperty(domain.SortBy);

            if (property == null)
            {
                throw new ArgumentException($"Property {domain.SortBy} not found in type {typeof(TDomain).Name}");
            }

            IEnumerable<TDomain> sortedDomain;

            if (domain.SortDirection == "ascending")
            {
                sortedDomain = domain.entity!.Value.OrderBy(x => property.GetValue(x));
            }
            else
            {
                sortedDomain = domain.entity!.Value.OrderByDescending(x => property.GetValue(x));
            }
            return Task.FromResult(sortedDomain);
        }
    }
}

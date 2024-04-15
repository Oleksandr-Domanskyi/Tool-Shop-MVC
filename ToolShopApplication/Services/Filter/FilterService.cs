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
    public class FilterService<TDomain> : IFilterService<TDomain> where TDomain : Entity<int>
    {
        
        public Task<IEnumerable<TDomain>> AddFilters(IEnumerable<TDomain> domain, Filters filters)
        {
            if (filters.SortBy == null)
            {
                var sortedDomain = domain.Reverse().ToList();
                return Task.FromResult<IEnumerable<TDomain>>(sortedDomain);
            }
            PropertyInfo? property = typeof(TDomain).GetProperty(filters.SortBy);
            if (filters.IsOn)
            {

                var sortedDomain = domain.OrderBy(x => property.GetValue(x)); 
                return Task.FromResult<IEnumerable<TDomain>>(sortedDomain);
                
            }
            else
            {
                var sortedDomain = domain.OrderByDescending(x => property.GetValue(x));
                return Task.FromResult<IEnumerable<TDomain>>(sortedDomain);
            }
            
            
           
        }

      
    }
    
}

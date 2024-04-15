using ToolShopDomainCore.Contracts;
using ToolShopDomainCore.Domain;
using ToolShopDomainCore.Domain.Fileters;

namespace ToolShopApplication.Services.Filter
{
    public interface IFilterService<TDomain>:IService where TDomain : Entity<int>
    {
        Task<IEnumerable<TDomain>> AddFilters(IEnumerable<TDomain> domain, Filters filters);
    }
}
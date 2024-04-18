using ToolShopDomainCore.Contracts;
using ToolShopDomainCore.Domain;
using ToolShopDomainCore.Domain.Fileters;

namespace ToolShopApplication.Services.Filter
{
    public interface IFilterService<TDomain> : IService where TDomain : class
    {
        Task<Filters<TDomain>> AddFilters(Filters<TDomain> domain);
       
    }
}
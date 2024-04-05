using MediatR;
using ToolShopDomainCore.Domain;

namespace ToolShopApplication.CQRS.Queries.GetAll
{
    public class GetAllQuery<TDomain, TDto> : IRequest<IEnumerable<TDto>>
        where TDto : class
        where TDomain : Entity<int>
    {
    }
}

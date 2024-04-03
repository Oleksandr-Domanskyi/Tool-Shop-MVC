using MediatR;
using Microsoft.AspNetCore.Http.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolShopApplication.DataTransferObject;
using ToolShopDomainCore.Domain;

namespace ToolShopApplication.CQRS.Queries.GetAll
{
    public class GetAllQuery<TDomain, TDto> : IRequest<IEnumerable<TDto>>
        where TDto : class
        where TDomain : Entity<int>
    {
    }
}

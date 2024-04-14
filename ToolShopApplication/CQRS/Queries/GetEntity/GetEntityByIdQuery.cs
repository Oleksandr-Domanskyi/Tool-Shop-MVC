using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolShopDomainCore.Domain;

namespace ToolShopApplication.CQRS.Queries.GetEntity
{
    public class GetEntityByIdQuery<TDomain, TDto> :IRequest<TDto>
        where TDomain : Entity<int>
        where TDto : class
    {
        public int _id { get; set; }

        public GetEntityByIdQuery(int id)
        {
            _id = id;
        }
    }
}

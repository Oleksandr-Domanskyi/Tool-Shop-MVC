using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolShopDomainCore.Domain;
using ToolShopInfrastructure.Services;

namespace ToolShopApplication.CQRS.Queries.GetEntity
{
    public class GetEntityByIdQueryHandler<TDomain, TReq> : IRequestHandler<GetEntityByIdQuery<TDomain, TReq>,TReq>
        where TDomain : Entity<int>
        where TReq : class
    {
        private readonly IEntityService<TDomain> _service;
        private readonly IMapper _mapper;

        public GetEntityByIdQueryHandler(IEntityService<TDomain> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public async Task<TReq> Handle(GetEntityByIdQuery<TDomain, TReq> request, CancellationToken cancellationToken)
        {
            var model = await _service.GetByIdAsync(request._id);
            var mapped = _mapper.Map<TReq>(model.Value);
            return mapped;
        }
    }
}

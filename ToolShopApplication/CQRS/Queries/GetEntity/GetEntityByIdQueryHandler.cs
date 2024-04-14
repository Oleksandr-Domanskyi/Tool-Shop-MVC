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
    public class GetEntityByIdQueryHandler<TDomain, TDto> : IRequestHandler<GetEntityByIdQuery<TDomain, TDto>, TDto>
        where TDomain : Entity<int>
        where TDto : class
    {
        private readonly IEntityService<TDomain> _service;
        private readonly IMapper _mapper;

        public GetEntityByIdQueryHandler(IEntityService<TDomain> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public async Task<TDto> Handle(GetEntityByIdQuery<TDomain, TDto> request, CancellationToken cancellationToken)
        {
            var model = await _service.GetByIdAsync(request._id);
            var mapped = _mapper.Map<TDto>(model.Value);
            return mapped;
        }
    }
}

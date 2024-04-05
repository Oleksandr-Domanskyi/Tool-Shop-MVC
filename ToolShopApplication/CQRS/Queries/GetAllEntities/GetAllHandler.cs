﻿using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ToolShopApplication.CQRS.Queries.GetAll;
using ToolShopDomainCore.Domain;
using ToolShopInfrastructure.Services;

namespace ToolShopApplication.CQRS.Handlers
{
    public class GetAllHandler<TDomain, TDto> : IRequestHandler<GetAllQuery<TDomain, TDto>, IEnumerable<TDto>>
        where TDto : class
        where TDomain : Entity<int>
    {
        private readonly IEntityService<TDomain> _service;
        private readonly IMapper _mapper;

        public GetAllHandler(IEntityService<TDomain> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TDto>> Handle(GetAllQuery<TDomain, TDto> request, CancellationToken cancellationToken)
        {
            var model = await _service.GetListAsync();
            return _mapper.Map<IEnumerable<TDto>>(model.Value);
        }
    }
}
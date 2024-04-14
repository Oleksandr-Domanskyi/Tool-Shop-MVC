using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolShopDomainCore.Domain;
using ToolShopDomainCore.Domain.Entity;
using ToolShopInfrastructure.Services;

namespace ToolShopApplication.CQRS.Command.CreateEntity
{
    public class CreateEntityCommandHandler<TDomain, TReq> : IRequestHandler<CreateEntityCommand<TDomain, TReq>>
        where TDomain : Entity<int>
        where TReq : class
    {
        private readonly IEntityService<TDomain> _service;
        private readonly IRaportOperationServices _raportServices;
        private readonly IMapper _mapper;

        public CreateEntityCommandHandler(IEntityService<TDomain> service,IRaportOperationServices raportServices, IMapper mapper)
        {
            _service = service;
            _raportServices = raportServices;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateEntityCommand<TDomain, TReq> request, CancellationToken cancellationToken)
        {
            await _service.AddEntityAsync(_mapper.Map<TDomain>(request));
            await _raportServices.AddRaportAsync(new OperationRaport()
            {
                Operation = "CREATE",
                UserName = "Administrator"
            });
            return Unit.Value;
        }
    }
}

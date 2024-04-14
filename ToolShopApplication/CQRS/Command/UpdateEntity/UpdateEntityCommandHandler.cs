using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ToolShopDomainCore.Domain;
using ToolShopInfrastructure.Services;

namespace ToolShopApplication.CQRS.Command.UpdateEntity
{
    public class UpdateEntityCommandHandler<TDomain, TReq> : IRequestHandler<UpdateEntityCommand<TDomain, TReq>>
        where TDomain : Entity<int>
        where TReq : class
    {
        private readonly IEntityService<TDomain> _service;
        private readonly IMapper _mapper;

        public UpdateEntityCommandHandler(IEntityService<TDomain> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateEntityCommand<TDomain, TReq> request, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<TDomain>(request);

            await _service.UpdateAsync(model);

            return Unit.Value;
        }
    }
}

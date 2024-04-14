using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolShopDomainCore.Domain;
using ToolShopDomainCore.Domain.Entity;
using ToolShopInfrastructure.Services;

namespace ToolShopApplication.CQRS.Command.Delete
{
    public class DeleteEntityCommandHandler<TDomain> : IRequestHandler<DeleteEntityCommand<TDomain>> where TDomain : Entity<int>
    {
        private readonly IEntityService<TDomain> _service;
        private readonly IRaportOperationServices _raportServices;

        public DeleteEntityCommandHandler(IEntityService<TDomain> service, IRaportOperationServices raportServices)
        {
            _service = service;
            _raportServices = raportServices;
        }
        public async Task<Unit> Handle(DeleteEntityCommand<TDomain> request, CancellationToken cancellationToken)
        {
            await _service.DeleteAsync(request._entity);
            await _raportServices.AddRaportAsync(new OperationRaport()
            {
                Operation = "DELETE",
                UserName = "Administrator"
            });
            return Unit.Value;
        }
    }
}

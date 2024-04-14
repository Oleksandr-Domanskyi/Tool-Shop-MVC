using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolShopDomainCore.Domain;
using ToolShopInfrastructure.Services;

namespace ToolShopApplication.CQRS.Command.Delete
{
    public class DeleteEntityCommandHandler<TDomain> : IRequestHandler<DeleteEntityCommand<TDomain>> where TDomain : Entity<int>
    {
        private readonly IEntityService<TDomain> _service;

        public DeleteEntityCommandHandler(IEntityService<TDomain> service)
        {
            _service = service;
        }
        public async Task<Unit> Handle(DeleteEntityCommand<TDomain> request, CancellationToken cancellationToken)
        {
            await _service.DeleteAsync(request._entity);
            return Unit.Value;
        }
    }
}

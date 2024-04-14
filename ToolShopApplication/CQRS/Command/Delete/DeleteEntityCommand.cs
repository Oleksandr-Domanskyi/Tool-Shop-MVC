using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolShopDomainCore.Domain;
using ToolShopDomainCore.Domain.Entity;

namespace ToolShopApplication.CQRS.Command.Delete
{
    public class DeleteEntityCommand<TDomain>:IRequest<Unit> where TDomain : Entity<int>
    {
        public TDomain _entity { get; set; }
        public OperationRaport _raport { get; set; }
        public DeleteEntityCommand(TDomain entity,OperationRaport raport )
        {
            _entity = entity;
            _raport = raport;
        }
    }
}

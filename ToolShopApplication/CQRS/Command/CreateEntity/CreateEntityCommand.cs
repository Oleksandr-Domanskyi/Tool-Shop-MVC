using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolShopDomainCore.Domain;
using ToolShopDomainCore.Domain.Entity;

namespace ToolShopApplication.CQRS.Command.CreateEntity
{
    public class CreateEntityCommand<TDomain,TReq>:IRequest
        where TDomain : Entity<int>
        where TReq : class
    {
        public TReq _request { get; set; }
        public OperationRaport _raport { get; set; }

        public CreateEntityCommand(TReq request,OperationRaport raport)
        {
            _request = request;
            _raport = raport;
        }
    }
}

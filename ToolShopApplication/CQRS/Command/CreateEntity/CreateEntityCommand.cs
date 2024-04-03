using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolShopDomainCore.Domain;

namespace ToolShopApplication.CQRS.Command.CreateEntity
{
    public class CreateEntityCommand<TDomain,TReq>:IRequest
        where TDomain : Entity<int>
        where TReq : class
    {
        public TReq Request { get; set; }

        public CreateEntityCommand(TReq request)
        {
            Request = request;
        }
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolShopDomainCore.Domain;

namespace ToolShopApplication.CQRS.Command.UpdateEntity
{
    public class UpdateEntityCommand<TDomain, TReq>:IRequest
        where TDomain : Entity<int>
        where TReq : class
    {
        public TReq _request { get; set; }

        public UpdateEntityCommand(TReq request)
        {
            _request = request;

        }
    }
}

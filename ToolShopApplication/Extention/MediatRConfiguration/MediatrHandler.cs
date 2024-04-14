using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolShopApplication.CQRS.Command.CreateEntity;
using ToolShopApplication.CQRS.Command.Delete;
using ToolShopApplication.CQRS.Command.UpdateEntity;
using ToolShopApplication.CQRS.Handlers;
using ToolShopApplication.CQRS.Queries.GetAll;
using ToolShopApplication.CQRS.Queries.GetEntity;
using ToolShopDomainCore.Domain;

namespace ToolShopApplication.Extention.MediatRConfiguration
{
    public class MediatrHandler
    {
        public static void MediatrRegisterHandler<TDomain, TDto, TReq>(IServiceCollection services)
           where TDomain : Entity<int>
           where TDto : class
           where TReq : class
        {
            services.AddTransient(
                typeof(IRequestHandler<GetAllQuery<TDomain, TDto>, IEnumerable<TDto>>),
                typeof(GetAllHandler<TDomain, TDto>)
            );

            services.AddTransient(
                typeof(IRequestHandler<CreateEntityCommand<TDomain, TReq>, Unit>),
                typeof(CreateEntityCommandHandler<TDomain, TReq>)
            );

            services.AddTransient(
                typeof(IRequestHandler<GetEntityByIdQuery<TDomain, TDto>, TDto>),
                typeof(GetEntityByIdQueryHandler<TDomain, TDto>)
            );

            services.AddTransient(
                typeof(IRequestHandler<UpdateEntityCommand<TDomain, TReq>, Unit>),
                typeof(UpdateEntityCommandHandler<TDomain, TReq>)
            );

            services.AddTransient(
                typeof(IRequestHandler<DeleteEntityCommand<TDomain>, Unit>),
                typeof(DeleteEntityCommandHandler<TDomain>)
            );
        }
    }
}

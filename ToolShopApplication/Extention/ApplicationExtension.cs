using Ardalis.Specification;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ToolShopApplication.CQRS.Command.CreateEntity;
using ToolShopApplication.CQRS.Command.Delete;
using ToolShopApplication.CQRS.Command.UpdateEntity;
using ToolShopApplication.CQRS.Handlers;
using ToolShopApplication.CQRS.Queries.GetAll;
using ToolShopApplication.CQRS.Queries.GetEntity;
using ToolShopApplication.DataTransferObject;
using ToolShopApplication.Extention.MediatRConfiguration;
using ToolShopApplication.Mapping;
using ToolShopDomainCore.Domain;
using ToolShopDomainCore.Domain.Entity;

namespace ToolShopApplication.Extention
{
    public static class ApplicationExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            MediatrServices(services);
            services.AddAutoMapper(typeof(ToolsMappingProfile));
        }
       
        private static void MediatrServices(IServiceCollection services)
        {
            services.AddMediatR(typeof(Mediator));
            MediatrHandler.MediatrRegisterHandler<ToolProfile, ToolProfileDto, ToolProfileRequest>(services);
        }
    }
}

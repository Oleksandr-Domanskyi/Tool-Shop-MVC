using Ardalis.Specification;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using ToolShopApplication.Services.Filter;
using ToolShopDomainCore.Contracts;
using ToolShopDomainCore.Domain;
using ToolShopDomainCore.Domain.Entity;
using ToolShopDomainCore.Domain.Fileters;
using ToolShopInfrastructure.Services;

namespace ToolShopApplication.Extention
{
    public static class ApplicationExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            
            ConfigureServices(services);
            MediatrServices(services);
            
            services.AddAutoMapper(typeof(ToolsMappingProfile));
        }
       
        private static void MediatrServices(IServiceCollection services)
        {
            services.AddMediatR(typeof(Mediator));
            MediatrHandler.MediatrRegisterHandler<ToolProfile, ToolProfileDto, ToolProfileRequest>(services);
        }
        private static void ConfigureServices(IServiceCollection services)
        {
            var serviceTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(t => t.GetInterfaces().Contains(typeof(IService)) && !t.IsInterface && t.Namespace == "ToolShopInfrastructure.Services")
                .ToList();
            foreach (var type in serviceTypes)
            { 
                var interfaceType = type.GetInterfaces().FirstOrDefault(t => t.Name == $"I{type.Name}");
                if (interfaceType != null)
                { 
                    services.AddTransient(interfaceType, type);
                }
            }
            services.AddTransient(typeof(IFilterService<>), typeof(FilterService<>));
            services.AddTransient(typeof(Filters<>));
        }


    }
}

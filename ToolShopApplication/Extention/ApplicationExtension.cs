using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ToolShopApplication.CQRS.Command.CreateEntity;
using ToolShopApplication.CQRS.Handlers;
using ToolShopApplication.CQRS.Queries.GetAll;
using ToolShopApplication.DataTransferObject;
using ToolShopApplication.Mapping;
using ToolShopDomainCore.Domain.Entity;

namespace ToolShopApplication.Extention
{
    public static class ApplicationExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(GetAllQuery<,>));
            services.AddAutoMapper(typeof(ToolsMappingProfile));
            services.AddTransient<IRequestHandler<GetAllQuery<ToolProfile, ToolProfileDto>, IEnumerable<ToolProfileDto>>, GetAllHandler<ToolProfile, ToolProfileDto>>();
            services.AddTransient<IRequestHandler<CreateEntityCommand<ToolProfile, ToolProfileRequest>, Unit>, CreateEntityCommandHandler<ToolProfile,ToolProfileRequest>>();

            
        }
    }
}

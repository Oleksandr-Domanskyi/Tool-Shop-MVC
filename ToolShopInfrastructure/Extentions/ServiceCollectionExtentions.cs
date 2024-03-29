using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ToolShopApplication.DataBase;
using ToolShopInfrastructure.Repositories;
using ToolShopInfrastructure.Services;

namespace ToolShopInfrastructure.Extentions
{
    public static class ServiceCollectionExtentions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ToolShopDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("ToolShopConnectionString")));

            // Add unit of work
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            // Add api services
            services.AddScoped(typeof(IEntityService<>), typeof(EntityService<>));
        }
    }
}

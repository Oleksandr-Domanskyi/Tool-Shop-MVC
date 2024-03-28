using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ToolShopDomainCore.Domain.Entity;

namespace ToolShopApplication.DataBase
{
    public class ToolShopDbContext:DbContext
    {
        public ToolShopDbContext(DbContextOptions<ToolShopDbContext> options):base(options)
        {
        }
        public DbSet<ToolProfileModel> ToolProfileModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    property.SetPropertyAccessMode(PropertyAccessMode.Field);
                }
            }
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //modelBuilder.HasDbFunction(()=>CustomS)

            base.OnModelCreating(modelBuilder);
        }
    }
}

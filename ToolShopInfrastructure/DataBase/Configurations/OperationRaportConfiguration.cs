using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolShopDomainCore.Domain.Entity;

namespace ToolShopInfrastructure.DataBase.Configurations
{
    public class OperationRaportConfiguration : IEntityTypeConfiguration<OperationRaport>
    {
        public void Configure(EntityTypeBuilder<ToolShopDomainCore.Domain.Entity.OperationRaport> builder)
        {
            builder.ToTable("Operation_Raport");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasField("_id").HasColumnName("Id").ValueGeneratedOnAdd();

            builder.Property(x => x.Operation).UsePropertyAccessMode(PropertyAccessMode.Field).HasColumnName("Operation");
            builder.Property(x => x.UserName).UsePropertyAccessMode(PropertyAccessMode.Field).HasColumnName("username");
            builder.Property(x => x.DateOfRealising).UsePropertyAccessMode(PropertyAccessMode.Field).HasColumnName("DateofRealising");
        }
    }
}

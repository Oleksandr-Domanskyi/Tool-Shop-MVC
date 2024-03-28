using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolShopDomainCore.Domain.Entity;

namespace ToolShopApplication.DataBase.Extentions
{
    public class ToolProfileConfiguration : IEntityTypeConfiguration<ToolProfileModel>
    {
        public void Configure(EntityTypeBuilder<ToolProfileModel> builder)
        {
            builder.ToTable("ToolProfile");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasField("_id").HasColumnName("Id").ValueGeneratedOnAdd();

            builder.Property(x => x.Name).UsePropertyAccessMode(PropertyAccessMode.Field).HasColumnName("Name");
            builder.Property(x => x.Price).UsePropertyAccessMode(PropertyAccessMode.Field).HasColumnName("Price");
            builder.Property(x => x.Description).UsePropertyAccessMode(PropertyAccessMode.Field).HasColumnName("Description");

            
            builder.OwnsOne(x => x.image, img =>
            {
                img.Property(im => im.ImageName).HasColumnName("ImageName");
                img.Property(im => im.FileType).HasColumnName("FileType");
                img.Property(im => im.DataFile).HasColumnName("DataFile");
            });

            builder.Property(x => x.Category).HasColumnName("Category");
        }
    }

}

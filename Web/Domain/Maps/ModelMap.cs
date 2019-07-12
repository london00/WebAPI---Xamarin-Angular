using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UdemyDotNetCoreAngular.Domain.Models;

namespace UdemyDotNetCoreAngular.Domain.Maps
{
    public class ModelMap : IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> builder)
        {
            builder.Property(x => x.Name).IsRequired(true).HasMaxLength(255);
            builder.HasOne(x => x.Make).WithMany(x => x.Models).HasForeignKey(x=>x.MakeId);
            builder.HasMany(x => x.Vehicles).WithOne(x => x.Model).HasForeignKey(x=>x.ModelId);
        }
    }
}

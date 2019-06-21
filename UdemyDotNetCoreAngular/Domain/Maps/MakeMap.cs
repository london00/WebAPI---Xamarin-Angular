using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UdemyDotNetCoreAngular.Domain.Models;

namespace UdemyDotNetCoreAngular.Domain.Maps
{
    public class MakeMap : IEntityTypeConfiguration<Make>
    {
        public void Configure(EntityTypeBuilder<Make> builder)
        {
            builder.Property(x => x.Name).IsRequired(true).HasMaxLength(255);
            builder.HasMany(x => x.Models).WithOne(x=>x.Make);
        }
    }
}

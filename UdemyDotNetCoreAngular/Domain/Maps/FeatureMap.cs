using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UdemyDotNetCoreAngular.Domain.Models;

namespace UdemyDotNetCoreAngular.Domain.Maps
{
    public class FeatureMap : IEntityTypeConfiguration<Feature>
    {
        public void Configure(EntityTypeBuilder<Feature> builder)
        {
            builder.Property(x => x.Name).IsRequired(true).HasMaxLength(255);
            builder.HasOne(x => x.Model).WithMany(x => x.Features).HasForeignKey(x => x.ModelId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
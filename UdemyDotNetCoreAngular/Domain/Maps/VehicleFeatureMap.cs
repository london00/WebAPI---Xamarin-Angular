using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UdemyDotNetCoreAngular.Domain.Models;

namespace UdemyDotNetCoreAngular.Domain.Maps
{
    public class VehicleFeaturesMap : IEntityTypeConfiguration<VehicleFeature>
    {
        public void Configure(EntityTypeBuilder<VehicleFeature> builder)
        {
            builder.ToTable("VehicleFeatures");
            builder.HasOne(x => x.Feature).WithMany(x=> x.VehicleFeatures).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Vehicle).WithMany(x=> x.VehicleFeatures).OnDelete(DeleteBehavior.Restrict);
        }
    }
}

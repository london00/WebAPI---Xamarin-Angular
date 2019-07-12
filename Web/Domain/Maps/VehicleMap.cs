using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UdemyDotNetCoreAngular.Domain.Models;

namespace UdemyDotNetCoreAngular.Domain.Maps
{
    public class VehicleMap : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable("Vehicles");
            builder.Property(x => x.IsRegistered).IsRequired();
            builder.Property(x => x.ContactName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.ContactMail).HasMaxLength(50).IsRequired();
            builder.Property(x => x.ContactPhone).HasMaxLength(10).IsRequired();
            builder.HasOne(x => x.Model).WithMany(x => x.Vehicles).HasForeignKey(x=> x.ModelId);
            builder.HasMany(x => x.VehicleFeatures).WithOne(x => x.Vehicle).HasForeignKey(x => x.VehicleId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.Photos).WithOne(x => x.Vehicle).HasForeignKey(x=> x.VehicleId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}

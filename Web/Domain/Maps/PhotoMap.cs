using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UdemyDotNetCoreAngular.Domain.Models;

namespace UdemyDotNetCoreAngular.Domain.Maps
{
    public class PhotoMap : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
        {
            builder.ToTable("Photos");
            builder.Property(x => x.FileName).HasMaxLength(255).IsRequired();
            builder.HasOne(x => x.Vehicle).WithMany(x => x.Photos).HasForeignKey(x=> x.VehicleId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using UdemyDotNetCoreAngular.Domain.Maps;
using UdemyDotNetCoreAngular.Domain.Models;

namespace UdemyDotNetCoreAngular.Domain
{
    public class VegaDBContext : DbContext
    {
        #region DBSet
        public DbSet<Make> Makes { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleFeature> VehicleFeatures { get; set; }
        #endregion

        public VegaDBContext(DbContextOptions<VegaDBContext> dbContext): base(dbContext)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new FeatureMap());
            modelBuilder.ApplyConfiguration(new MakeMap());
            modelBuilder.ApplyConfiguration(new ModelMap());
            modelBuilder.ApplyConfiguration(new VehicleMap());
            modelBuilder.ApplyConfiguration(new VehicleFeaturesMap());
        }
    }
}
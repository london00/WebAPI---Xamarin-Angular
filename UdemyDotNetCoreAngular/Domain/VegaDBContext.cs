using Microsoft.EntityFrameworkCore;
using UdemyDotNetCoreAngular.Domain.Models;

namespace UdemyDotNetCoreAngular.Domain
{
    public class VegaDBContext : DbContext
    {
        public VegaDBContext(DbContextOptions<VegaDBContext> dbContext): base(dbContext)
        {

        }

        public DbSet<Make> Makes { get; set; }
        public DbSet<Model> Models { get; set; }
    }
}
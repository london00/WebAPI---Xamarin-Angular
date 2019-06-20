using Microsoft.EntityFrameworkCore;

namespace UdemyDotNetCoreAngular.Domain
{
    public class VegaDBContext : DbContext
    {
        public VegaDBContext(DbContextOptions<VegaDBContext> dbContext): base(dbContext)
        {

        }
    }
}
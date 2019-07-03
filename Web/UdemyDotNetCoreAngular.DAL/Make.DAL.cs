using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using UdemyDotNetCoreAngular.Domain;
using UdemyDotNetCoreAngular.Domain.Models;

namespace UdemyDotNetCoreAngular.DAL
{
    public class MakeDAL: IMakeDAL
    {
        private readonly VegaDBContext db;

        public MakeDAL(VegaDBContext db)
        {
            this.db = db;
        }

        public async Task<List<Make>> GetMakes()
        {
            return await db.Makes.Include(m => m.Models).ToListAsync();
        }
    }
}

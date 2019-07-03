using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyDotNetCoreAngular.Domain;
using UdemyDotNetCoreAngular.Domain.Models;

namespace UdemyDotNetCoreAngular.DAL
{
    public class FeatureDAL : IFeatureDAL
    {
        private readonly VegaDBContext db;

        public FeatureDAL(VegaDBContext db)
        {
            this.db = db;
        }

        public async Task<List<Feature>> GetFeaturesByModel(int ModelId)
        {
            return await db.Features.Include(x => x.Model).Where(f => f.ModelId == ModelId).ToListAsync();
        }
    }
}
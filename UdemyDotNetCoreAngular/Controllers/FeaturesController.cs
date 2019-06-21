using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UdemyDotNetCoreAngular.Domain;
using UdemyDotNetCoreAngular.Domain.Models;
using UdemyDotNetCoreAngular.DTO;

namespace UdemyDotNetCoreAngular.Controllers
{
    public class FeaturesController : BaseController
    {
        public FeaturesController(VegaDBContext db, IMapper mapper) : base(db, mapper)
        {
        }

        [HttpGet]
        public async Task<ICollection<FeatureDTO>> GetFeaturesByModel(int ModelId) {
            var features = await db.Features.Include(x=>x.Model).Where(f => f.ModelId == ModelId).ToListAsync();
            var faturesDTO = mapper.Map<ICollection<Feature>, ICollection<FeatureDTO>>(features);
            return faturesDTO;
        }
    }
}
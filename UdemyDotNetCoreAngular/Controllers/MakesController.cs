using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UdemyDotNetCoreAngular.Domain;
using UdemyDotNetCoreAngular.Domain.Models;
using UdemyDotNetCoreAngular.DTO;

namespace UdemyDotNetCoreAngular.Controllers
{
    public class MakesController : BaseController
    {
        public MakesController(VegaDBContext db, IMapper mapper): base(db, mapper)
        {
        }

        [HttpGet]
        public async Task<IEnumerable<MakeDTO>> GetMakes()
        {
            var makes = await db.Makes.Include(m => m.Models).ToListAsync();
            return mapper.Map<IEnumerable<Make>, IEnumerable<MakeDTO>>(makes);
        }
    }
}
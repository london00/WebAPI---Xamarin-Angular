using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UdemyDotNetCoreAngular.Domain;
using UdemyDotNetCoreAngular.Models;
using UdemyDotNetCoreAngular.Models.DTO;

namespace UdemyDotNetCoreAngular.Controllers
{
    [Route("api/[controller]")]
    public class MakesController : Controller
    {
        private readonly VegaDBContext db;
        private readonly IMapper mapper;

        public MakesController(VegaDBContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<MakeDTO>> GetMakes()
        {
            var makes = await this.db.Makes.Include(m => m.Models).ToListAsync();
            return mapper.Map<IEnumerable<Make>, IEnumerable<MakeDTO>>(makes);
        }
    }
}
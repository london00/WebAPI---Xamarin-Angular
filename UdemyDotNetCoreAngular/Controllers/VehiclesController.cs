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
    public class VehiclesController : BaseController
    {
        public VehiclesController(VegaDBContext db, IMapper mapper) : base(db, mapper)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] VehicleDTO model)
        {
            var vehicle = mapper.Map<VehicleDTO, Vehicle>(model);
            return Ok(vehicle);
        }
    }
}
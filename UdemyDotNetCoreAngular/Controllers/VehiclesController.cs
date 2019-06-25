using System;
using System.Collections.Generic;
using System.Linq;
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
            if (model.Id != 0)
            {
                ModelState.AddModelError("id", "Id can´t be assigned manually");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vehicle = mapper.Map<VehicleDTO, Vehicle>(model);
            vehicle.LastUpdate = DateTime.Now;
            db.Vehicles.Add(vehicle);
            await db.SaveChangesAsync();
            var vehicleDTO = mapper.Map<Vehicle, VehicleDTO>(vehicle);
            return Ok(vehicleDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] VehicleDTO model)
        {
            if (model.Id != id)
            {
                ModelState.AddModelError("Id", $"Vehicle id doesn´t match: {id} != {model.Id}");
            }
            if (model.VehicleFeatures.Any(x => x.VehicleId != id))
            {
                ModelState.AddModelError("Id", $"Some features doesn´t match with the current vehicle: {id} != {string.Join(",", model.VehicleFeatures.Select(x => x.VehicleId))}");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vehicle = await db.Vehicles.Include(x => x.VehicleFeatures).SingleOrDefaultAsync(x => x.Id == id);
            mapper.Map<VehicleDTO, Vehicle>(model, vehicle);
            vehicle.LastUpdate = DateTime.Now;

            db.Update(vehicle);
            await db.SaveChangesAsync();

            var vehicleDTO = mapper.Map<Vehicle, VehicleDTO>(vehicle);
            return Ok(vehicleDTO);
        }
    }
}
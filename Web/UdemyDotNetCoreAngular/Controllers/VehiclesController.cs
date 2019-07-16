using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UdemyDotNetCoreAngular.DAL;
using UdemyDotNetCoreAngular.Domain.Models;
using UdemyDotNetCoreAngular.DTO;
using UdemyDotNetCoreAngular.DTO.Filters;

namespace UdemyDotNetCoreAngular.Controllers
{
    public class VehiclesController : BaseController
    {
        private readonly IVehicleDAL vehicleDAL;
        private readonly IContext dataLayerContext;

        public VehiclesController(IMapper mapper, IVehicleDAL vehicleDAL, IContext dataLayerContext) : base(mapper)
        {
            this.vehicleDAL = vehicleDAL;
            this.dataLayerContext = dataLayerContext;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Save([FromBody] Save_VehicleDTO model)
        {
            if (model.Id != 0)
            {
                ModelState.AddModelError("id", "Id can´t be assigned manually");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vehicle = mapper.Map<Save_VehicleDTO, Vehicle>(model);
            vehicleDAL.AddVehicle(vehicle);
            dataLayerContext.CompleteChanges();
            vehicle = await vehicleDAL.GetVehicleById(vehicle.Id);
            var vehicleDTO = mapper.Map<Vehicle, VehicleDTO>(vehicle);
            return Ok(vehicleDTO);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Update(int id, [FromBody] Save_VehicleDTO model)
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

            Vehicle vehicle = await vehicleDAL.GetVehicleById(id);

            if (vehicle == null)
            {
                return NotFound($"Vehicle with id {id} has not been found");
            }

            mapper.Map<Save_VehicleDTO, Vehicle>(model, vehicle);

            vehicleDAL.UpdateVehicle(vehicle);
            dataLayerContext.CompleteChanges();

            vehicle = await vehicleDAL.GetVehicleById(vehicle.Id);
            var vehicleDTO = mapper.Map<Vehicle, VehicleDTO>(vehicle);
            return Ok(vehicleDTO);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var vehicle = await vehicleDAL.GetVehicleById(id);

            if (vehicle == null)
            {
                return NotFound($"Vehicle with id {id} has not been found");
            }

            vehicleDAL.RemoveVehicle(vehicle);
            dataLayerContext.CompleteChanges();

            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var vehicle = await vehicleDAL.GetVehicleById(id);

            if (vehicle == null)
            {
                return NotFound($"Vehicle with id {id} has not been found");
            }

            var vehicleDTO = mapper.Map<Vehicle, VehicleDTO>(vehicle);
            return Ok(vehicleDTO);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] VehicleFilterDTO filter)
        {
            List<Vehicle> vehicles = await vehicleDAL.GetVehicles(filter);
            var vehicleDTO = mapper.Map<List<Vehicle>, List<VehicleDTO>>(vehicles);
            return Ok(vehicleDTO);
        }
    }
}
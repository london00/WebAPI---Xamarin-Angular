using System.Collections.Generic;
using System.Threading.Tasks;
using UdemyDotNetCoreAngular.Domain.Models;
using UdemyDotNetCoreAngular.DTO.Filters;

namespace UdemyDotNetCoreAngular.DAL
{
    public interface IVehicleDAL
    {
        void AddVehicle(Vehicle vehicle);
        Task<Vehicle> GetVehicleById(int id);
        Task<List<Vehicle>> GetVehicles(VehicleFilterDTO filter);
        void RemoveVehicle(Vehicle vehicle);
        void UpdateVehicle(Vehicle vehicle);
    }
}
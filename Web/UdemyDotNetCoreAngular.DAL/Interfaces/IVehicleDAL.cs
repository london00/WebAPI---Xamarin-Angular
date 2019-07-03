using System.Collections.Generic;
using System.Threading.Tasks;
using UdemyDotNetCoreAngular.Domain.Models;

namespace UdemyDotNetCoreAngular.DAL
{
    public interface IVehicleDAL
    {
        void AddVehicle(Vehicle vehicle);
        Task<Vehicle> GetVehicleById(int id);
        Task<List<Vehicle>> GetVehicles();
        void RemoveVehicle(Vehicle vehicle);
        void UpdateVehicle(Vehicle vehicle);
    }
}
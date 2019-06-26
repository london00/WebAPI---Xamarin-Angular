using System.Threading.Tasks;
using UdemyDotNetCoreAngular.Domain.Models;

namespace UdemyDotNetCoreAngular.DAL
{
    public interface IVehicleDAL
    {
        void AddVehicle(Vehicle vehicle);
        Task<Vehicle> GetVehicleById(int id);
        void RemoveVehicle(Vehicle vehicle);
        void UpdateVehicle(Vehicle vehicle);
    }
}
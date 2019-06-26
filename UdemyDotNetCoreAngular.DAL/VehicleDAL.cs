﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using UdemyDotNetCoreAngular.Domain;
using UdemyDotNetCoreAngular.Domain.Models;

namespace UdemyDotNetCoreAngular.DAL
{
    public class VehicleDAL : IVehicleDAL
    {
        private readonly VegaDBContext db;

        public VehicleDAL(VegaDBContext db)
        {
            this.db = db;
        }

        public void AddVehicle(Vehicle vehicle)
        {
            vehicle.LastUpdate = DateTime.Now;
            db.Vehicles.Add(vehicle);
        }

        public async Task<Vehicle> GetVehicleById(int id)
        {
            return await db.Vehicles.Include(x => x.VehicleFeatures).FirstOrDefaultAsync(x => x.Id == id);
        }

        public void UpdateVehicle(Vehicle vehicle)
        {
            vehicle.LastUpdate = DateTime.Now;
            db.Update(vehicle);
        }

        public void RemoveVehicle(Vehicle vehicle)
        {
            db.Remove(vehicle);
        }
    }
}

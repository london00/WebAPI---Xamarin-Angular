using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace UdemyDotNetCoreAngular.Domain.Models
{
    public class Vehicle
    {
        public Vehicle()
        {
            VehicleFeatures = new Collection<VehicleFeature>();
            Photos = new Collection<Photo>();
        }

        public int Id { get; set; }
        public int ModelId { get; set; }
        public bool IsRegistered { get; set; }
        public string ContactName { get; set; }
        public string ContactPhone { get; set; }
        public string ContactMail { get; set; }
        public DateTime LastUpdate { get; set; }
        public virtual Model Model { get; set; }
        public virtual ICollection<VehicleFeature> VehicleFeatures { get; set; }
        public virtual  ICollection<Photo> Photos { get; set; }
    }
}

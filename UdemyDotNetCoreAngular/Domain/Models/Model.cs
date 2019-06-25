﻿using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace UdemyDotNetCoreAngular.Domain.Models
{
    public class Model
    {
        public Model()
        {
            Features = new Collection<Feature>();
            Vehicles = new Collection<Vehicle>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int MakeId { get; set; }

        public Make Make { get; set; }
        public virtual ICollection<Feature> Features { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }
    }
}
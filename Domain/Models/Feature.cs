using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace UdemyDotNetCoreAngular.Domain.Models
{
    public class Feature
    {
        public Feature()
        {
            VehicleFeatures = new Collection<VehicleFeature>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int ModelId { get; set; }

        public virtual Model Model { get; set; }
        public virtual ICollection<VehicleFeature> VehicleFeatures { get; set; }

    }
}
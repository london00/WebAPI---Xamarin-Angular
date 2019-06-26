using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using static UdemyDotNetCoreAngular.DTO.Save_VehicleDTO;

namespace UdemyDotNetCoreAngular.DTO
{
    public class VehicleDTO
    {
        public VehicleDTO()
        {
            VehicleFeatures = new Collection<KeyValuePairDTO>();
        }

        public int Id { get; set; }
        public bool IsRegistered { get; set; }
        public ContactInfo Contact { get; set; }
        public DateTime LastUpdate { get; set; }
        public KeyValuePairDTO Model { get; set; }
        public KeyValuePairDTO Make { get; set; }
        public ICollection<KeyValuePairDTO> VehicleFeatures { get; set; }
    }
}

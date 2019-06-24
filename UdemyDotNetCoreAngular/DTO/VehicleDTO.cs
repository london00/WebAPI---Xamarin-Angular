using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UdemyDotNetCoreAngular.DTO
{
    public class VehicleDTO
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public bool IsRegistered { get; set; }
        public ContactInfo Contact { get; set; }
        public ICollection<int> VehicleFeatures { get; set; }

        public class ContactInfo {
            public string Name { get; set; }
            public string Phone { get; set; }
            public string Mail { get; set; }
        }
    }
}

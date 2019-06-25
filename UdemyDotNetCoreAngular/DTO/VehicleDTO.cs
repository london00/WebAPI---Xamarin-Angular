using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UdemyDotNetCoreAngular.DTO
{
    public class VehicleDTO: IValidatableObject
    {
        public int Id { get; set; }
        [Required]
        public int ModelId { get; set; }
        [Required]
        public bool IsRegistered { get; set; }
        [Required]
        public ContactInfo Contact { get; set; }
        public ICollection<VehicleFeatureDTO> VehicleFeatures { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.VehicleFeatures.Count == 0)
            {
                yield return new ValidationResult("Features are required", new List<string> { "VehicleFeatures" });
            }
            if (!this.Contact.Mail.Contains("@"))
            {
                yield return new ValidationResult("This is not mail", new List<string> { "Contact.Mail" });
            }
        }

        public class ContactInfo {
            [Required]
            [StringLength(100)]
            public string Name { get; set; }
            [Required]
            [StringLength(10)]
            public string Phone { get; set; }
            [Required]
            [StringLength(50)]
            public string Mail { get; set; }
        }
    }
}

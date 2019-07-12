using System.ComponentModel.DataAnnotations;

namespace UdemyDotNetCoreAngular.Domain.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public int VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}

namespace UdemyDotNetCoreAngular.Domain.Models
{
    public class VehicleFeature
    {
        public int Id { get; set; }
        public int FeatureId { get; set; }
        public int VehicleId { get; set; }
        public Feature Feature { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}

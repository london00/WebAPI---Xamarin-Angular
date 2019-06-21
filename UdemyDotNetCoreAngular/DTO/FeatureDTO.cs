namespace UdemyDotNetCoreAngular.DTO
{
    public class FeatureDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ModelId { get; set; }
        public ModelDTO Model { get; set; }
    }
}

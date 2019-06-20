using System.Collections.Generic;

namespace UdemyDotNetCoreAngular.Models.DTO
{
    public class MakeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ModelDTO> Models { get; set; }
    }
}
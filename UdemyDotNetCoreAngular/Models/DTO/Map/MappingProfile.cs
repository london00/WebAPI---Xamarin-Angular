using AutoMapper;

namespace UdemyDotNetCoreAngular.Models.DTO.Maps
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Model, ModelDTO>();
            CreateMap<Make, MakeDTO>();
        }
    }
}
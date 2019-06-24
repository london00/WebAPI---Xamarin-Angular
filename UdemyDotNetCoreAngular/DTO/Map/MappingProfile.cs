using AutoMapper;
using UdemyDotNetCoreAngular.Domain.Models;

namespace UdemyDotNetCoreAngular.DTO.Maps
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Model, ModelDTO>();
            CreateMap<Make, MakeDTO>();
            CreateMap<Feature, FeatureDTO>();
        }
    }
}
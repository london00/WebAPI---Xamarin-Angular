using AutoMapper;
using System.Linq;
using UdemyDotNetCoreAngular.Domain.Models;

namespace UdemyDotNetCoreAngular.DTO.Maps
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            // Domain to DTO
            CreateMap<Model, ModelDTO>();
            CreateMap<Make, MakeDTO>();
            CreateMap<Feature, FeatureDTO>();

            // DTO to Domain
            CreateMap<VehicleDTO, Vehicle>()
                .ForMember(d => d.ContactName, configMenber => configMenber.MapFrom(o => o.Contact.Name))
                .ForMember(d => d.ContactMail, configMenber => configMenber.MapFrom(o => o.Contact.Mail))
                .ForMember(d => d.ContactPhone, configMenber => configMenber.MapFrom(o => o.Contact.Phone))
                .ForMember(d => d.VehicleFeatures, configMember => configMember.MapFrom(o => o.VehicleFeatures.Select(x => new VehicleFeature { FeatureId = x })));
        }
    }
}
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using UdemyDotNetCoreAngular.Domain.Models;

namespace UdemyDotNetCoreAngular.DTO.Maps
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to DTO
            CreateMap<Model, KeyValuePairDTO>();
            CreateMap<Make, MakeDTO>();
            CreateMap<VehicleFeature, VehicleFeatureDTO>();
            CreateMap<Feature, KeyValuePairDTO>();
            CreateMap<Vehicle, Save_VehicleDTO>()
                .ForMember(d => d.Contact, configMenber => configMenber.MapFrom(o => new Save_VehicleDTO.ContactInfo { Name = o.ContactName, Mail = o.ContactMail, Phone = o.ContactPhone }));
            CreateMap<Vehicle, VehicleDTO>()
                .ForMember(d => d.Contact, configMenber => configMenber.MapFrom(o => new Save_VehicleDTO.ContactInfo { Name = o.ContactName, Mail = o.ContactMail, Phone = o.ContactPhone }))
                .ForMember(d => d.Model, configMember => configMember.MapFrom(o => new KeyValuePairDTO { Id = o.ModelId, Name = o.Model.Name }))
                .ForMember(d => d.Make, configMember => configMember.MapFrom(o => new KeyValuePairDTO { Id = o.Model.MakeId, Name = o.Model.Make.Name }))
                .ForMember(d => d.VehicleFeatures, configMember => configMember.MapFrom(o => o.VehicleFeatures.Select(vf => new KeyValuePairDTO { Id = vf.Feature.Id, Name = vf.Feature.Name })));

            // DTO to Domain
            CreateMap<VehicleFeatureDTO, VehicleFeature>();
            CreateMap<Save_VehicleDTO, Vehicle>()
                .ForMember(d => d.ContactName, configMenber => configMenber.MapFrom(o => o.Contact.Name))
                .ForMember(d => d.ContactMail, configMenber => configMenber.MapFrom(o => o.Contact.Mail))
                .ForMember(d => d.ContactPhone, configMenber => configMenber.MapFrom(o => o.Contact.Phone))
                .ForMember(d => d.VehicleFeatures, configMember => configMember.Ignore())
                .AfterMap((vr, v) => // Collection when parsed
                {
                    #region If feature has been removed

                    // If previously had it but currently not.
                    List<VehicleFeature> vehicleFeaturesRemoved = v.VehicleFeatures
                        .Where(x => !vr.VehicleFeatures.Any(y => y.FeatureId == x.FeatureId))
                        .ToList();

                    foreach (var removedFeature in vehicleFeaturesRemoved)
                        v.VehicleFeatures.Remove(removedFeature);

                    #endregion


                    #region If feature has been added

                    // If have it now, but previously not
                    var addedFeatures = vr.VehicleFeatures
                        .Where(newFeature => !v.VehicleFeatures.Any(x => x.FeatureId == newFeature.FeatureId))
                        .Select(x => new VehicleFeature { FeatureId = x.FeatureId, VehicleId = v.Id })
                        .ToList();

                    foreach (var addedFeature in addedFeatures)
                        v.VehicleFeatures.Add(addedFeature);

                    #endregion

                    #region Assign Id in case that it had lost it
                    foreach (var vehicleFeature in v.VehicleFeatures)
                    {
                        foreach (var vehicleFeatureDTO in vr.VehicleFeatures)
                        {
                            if (vehicleFeatureDTO.VehicleId == vehicleFeature.VehicleId && vehicleFeatureDTO.FeatureId == vehicleFeature.FeatureId)
                            {
                                vehicleFeatureDTO.Id = vehicleFeature.Id;
                            }
                        }
                    }
                    #endregion
                });
        }
    }
}
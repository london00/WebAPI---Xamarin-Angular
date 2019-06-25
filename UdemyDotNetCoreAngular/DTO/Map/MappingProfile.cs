using AutoMapper;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UdemyDotNetCoreAngular.Domain.Models;

namespace UdemyDotNetCoreAngular.DTO.Maps
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to DTO
            CreateMap<Model, ModelDTO>();
            CreateMap<Make, MakeDTO>();
            CreateMap<VehicleFeature, VehicleFeatureDTO>();
            CreateMap<Feature, FeatureDTO>();
            CreateMap<Vehicle, VehicleDTO>()
                .ForMember(d => d.Contact, configMenber => configMenber.MapFrom(o => new VehicleDTO.ContactInfo { Name = o.ContactName, Mail = o.ContactMail, Phone = o.ContactPhone }));

            // DTO to Domain
            CreateMap<VehicleFeatureDTO, VehicleFeature>();
            CreateMap<VehicleDTO, Vehicle>()
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
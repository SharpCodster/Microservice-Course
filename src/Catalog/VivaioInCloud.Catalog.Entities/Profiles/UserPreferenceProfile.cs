using AutoMapper;
using VivaioInCloud.Catalog.Entities.Dtos;
using VivaioInCloud.Catalog.Entities.Models;


namespace VivaioInCloud.Catalog.Entities.Profiles
{
    public class UserPreferenceProfile : Profile
    {
        public UserPreferenceProfile()
        {
            CreateMap<UserPreference, UserPreferenceDtoRead>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.Id))
                .ForMember(dest => dest.OwnerId, opt => opt.MapFrom(source => source.OwnerId))
                .ForMember(dest => dest.ItemType, opt => opt.MapFrom(source => source.ItemType))
            .ReverseMap();

            CreateMap<UserPreferenceDtoWrite, UserPreference>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.OwnerId, opt => opt.Ignore())
                .ForMember(dest => dest.ItemType, opt => opt.Ignore())
                .ForMember(dest => dest.ItemTypeId, opt => opt.MapFrom(source => source.ItemTypeId))
            .ReverseMap();
        }
    }
}

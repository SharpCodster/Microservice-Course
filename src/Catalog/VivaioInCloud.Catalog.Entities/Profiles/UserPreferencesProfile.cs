using AutoMapper;
using VivaioInCloud.Catalog.Entities.Dtos;
using VivaioInCloud.Catalog.Entities.Models;
using VivaioInCloud.Common.Entities.Profiles;


namespace VivaioInCloud.Catalog.Entities.Profiles
{
    public class UserPreferencesProfile : Profile
    {
        public UserPreferencesProfile()
        {
            CreateMap<UserPreferences, UserPreferencesDtoRead>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.Id))
                .ForMember(dest => dest.OwnerId, opt => opt.MapFrom(source => source.OwnerId))
                .ForMember(dest => dest.ItemType, opt => opt.MapFrom(source => source.ItemType))
            .ReverseMap();

            CreateMap<UserPreferencesDtoWrite, UserPreferences>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.OwnerId, opt => opt.Ignore())
                .ForMember(dest => dest.ItemType, opt => opt.Ignore())
                .ForMember(dest => dest.ItemTypeId, opt => opt.MapFrom(source => source.ItemTypeId))
            .ReverseMap();
        }
    }
}

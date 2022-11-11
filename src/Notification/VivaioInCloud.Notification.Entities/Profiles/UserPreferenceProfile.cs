using AutoMapper;
using VivaioInCloud.Notification.Entities.Dtos;
using VivaioInCloud.Notification.Entities.Models;

namespace VivaioInCloud.Notification.Entities.Profiles
{
    public class UserPreferenceProfile : Profile
    {
        public UserPreferenceProfile()
        {
            CreateMap<UserPreference, UserPreferenceDtoRead>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.Id))
                .ForMember(dest => dest.User, opt => opt.MapFrom(source => source.User))
                .ForMember(dest => dest.TypeId, opt => opt.MapFrom(source => source.TypeId))
            .ReverseMap();

            CreateMap<UserPreferenceDtoWrite, UserPreference>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.TypeId, opt => opt.MapFrom(source => source.TypeId))
                .ForMember(dest => dest.User, opt => opt.Ignore())
            .ReverseMap();
        }
    }
}

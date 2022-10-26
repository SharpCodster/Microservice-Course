using AutoMapper;
using VivaioInCloud.Identity.Entities.Dtos;
using VivaioInCloud.Identity.Entities.Models;
using VivaioInCloud.Common.Entities.Profiles;

namespace VivaioInCloud.Identity.Model.Profiles
{
    public class ApplicationUserProfile : Profile
    {
        public ApplicationUserProfile()
        {
            CreateMap<ApplicationUser, ApplicationUserDtoRead>()
                .ForEntityToReadDto()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(source => source.Email))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(source => source.UserName))
                .ForMember(dest => dest.EmailConfirmed, opt => opt.MapFrom(source => source.EmailConfirmed))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(source => source.PhoneNumber))
                .ForMember(dest => dest.PhoneNumberConfirmed, opt => opt.MapFrom(source => source.PhoneNumberConfirmed))
                .ForMember(dest => dest.TwoFactorEnabled, opt => opt.MapFrom(source => source.TwoFactorEnabled))
                .ForMember(dest => dest.LockoutEnd, opt => opt.MapFrom(source => source.LockoutEnd))
                .ForMember(dest => dest.LockoutEnabled, opt => opt.MapFrom(source => source.LockoutEnabled))
                .ForMember(dest => dest.AccessFailedCount, opt => opt.MapFrom(source => source.AccessFailedCount))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(source => source.IsActive))
                .ForMember(dest => dest.IdentityRoles, opt => opt.MapFrom(source => source.IdentityRoles))
            .ReverseMap();

            CreateMap<ApplicationUserDtoWrite, ApplicationUser>()
                .ForWriteDtoToEntity()
                .ForMember(dest => dest.TwoFactorEnabled, opt => opt.MapFrom(source => source.TwoFactorEnabled))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(source => source.IsActive))
                .ForMember(dest => dest.Email, opt => opt.Ignore())
                .ForMember(dest => dest.UserName, opt => opt.Ignore())
                .ForMember(dest => dest.EmailConfirmed, opt => opt.Ignore())
                .ForMember(dest => dest.PhoneNumber, opt => opt.Ignore())
                .ForMember(dest => dest.PhoneNumberConfirmed, opt => opt.Ignore())
                .ForMember(dest => dest.LockoutEnd, opt => opt.Ignore())
                .ForMember(dest => dest.LockoutEnabled, opt => opt.Ignore())
                .ForMember(dest => dest.AccessFailedCount, opt => opt.Ignore())
                .ForMember(dest => dest.IdentityRoles, opt => opt.Ignore())
            .ReverseMap();
        }

    }
}

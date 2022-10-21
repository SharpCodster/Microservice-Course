using AutoMapper;
using VivaioInCloud.Identity.Entities.Dtos;
using VivaioInCloud.Identity.Entities.Models;
using VivaioInCloud.Common.Entities.Profiles;

namespace VivaioInCloud.Identity.Model.Profiles
{
    public class ApplicationRoleProfile : Profile
    {
        public ApplicationRoleProfile()
        {
            CreateMap<ApplicationRole, ApplicationRoleDtoRead>()
                .ForEntityToReadDto()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(source => source.Name))
            .ReverseMap();

            CreateMap<ApplicationRoleDtoWrite, ApplicationRole>()
                .ForWriteDtoToEntity()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(source => source.Name))
            .ReverseMap();
        }

    }
}
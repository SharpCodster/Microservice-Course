using AutoMapper;
using VivaioInCloud.Common.Entities.Profiles;
using VivaioInCloud.Notification.Entities.Dtos;
using VivaioInCloud.Notification.Entities.Models;

namespace VivaioInCloud.Notification.Entities.Profiles
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<Contact, ContactDtoRead>()
                .ForEntityToReadDto()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(source => source.Name))
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(source => source.Surname))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(source => source.Email))
            .ReverseMap();

            CreateMap<ContactDtoWrite, Contact>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.Id))
                .ForMember(dest => dest.CreatedAtUtc, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAtUtc, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())
                .ForMember(dest => dest.Name, opt => opt.MapFrom(source => source.Name))
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(source => source.Surname))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(source => source.Email))
            .ReverseMap();
        }
    }
}

using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System;
using AutoMapper;
using VivaioInCloud.Notification.Entities.Dtos;
using VivaioInCloud.Notification.Entities.Models;
using VivaioInCloud.Common.Entities.Profiles;

namespace VivaioInCloud.Notification.Entities.Profiles
{
    public class UserNotificationProfile : Profile
    {
        public UserNotificationProfile()
        {
            CreateMap<UserNotification, UserNotificationDtoRead>()
                .ForEntityToReadDto()
                .ForMember(dest => dest.Message, opt => opt.MapFrom(source => source.Message))
                .ForMember(dest => dest.Delivered, opt => opt.MapFrom(source => source.Delivered))
                .ForMember(dest => dest.User, opt => opt.MapFrom(source => source.User))
            .ReverseMap();

            CreateMap<UserNotificationDtoWrite, UserNotification>()
                .ForMember(dest => dest.Message, opt => opt.MapFrom(source => source.Message))
                .ForMember(dest => dest.Delivered, opt => opt.MapFrom(source => source.Delivered))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(source => source.UserId))
                .ForMember(dest => dest.User, opt => opt.Ignore())
            .ReverseMap();
        }
    }
}

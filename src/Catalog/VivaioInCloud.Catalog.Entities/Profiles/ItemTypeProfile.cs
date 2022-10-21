using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VivaioInCloud.Catalog.Entities.Dtos;
using VivaioInCloud.Catalog.Entities.Models;
using VivaioInCloud.Common.Entities.Profiles;

namespace VivaioInCloud.Catalog.Entities.Profiles
{
    public class ItemTypeProfile : Profile
    {
        public ItemTypeProfile()
        {
            CreateMap<ItemType, ItemTypeDtoRead>()
                .ForEntityToReadDto()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(source => source.Name))
            .ReverseMap();

            CreateMap<ItemTypeDtoWrite, ItemType>()
                .ForWriteDtoToEntity()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(source => source.Name))
                .ForMember(dest => dest.Items, opt => opt.Ignore())
            .ReverseMap();
        }
    }
}


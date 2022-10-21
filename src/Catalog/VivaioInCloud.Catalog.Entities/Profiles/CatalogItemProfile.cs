using AutoMapper;
using VivaioInCloud.Catalog.Entities.Dtos;
using VivaioInCloud.Catalog.Entities.Models;
using VivaioInCloud.Common.Entities.Profiles;

namespace VivaioInCloud.Catalog.Entities.Profiles
{
    public class CatalogItemProfile : Profile
    {
        public CatalogItemProfile()
        {
            CreateMap<CatalogItem, CatalogItemDtoRead>()
                .ForEntityToReadDto()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(source => source.Title))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(source => source.Description))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(source => source.Category))
            .ReverseMap();

            CreateMap<CatalogItemDtoWrite, CatalogItem>()
                .ForWriteDtoToEntity()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(source => source.Title))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(source => source.Description))
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(source => source.CategoryId))
                .ForMember(dest => dest.Category, opt => opt.Ignore())
            .ReverseMap();
        }
    }
}

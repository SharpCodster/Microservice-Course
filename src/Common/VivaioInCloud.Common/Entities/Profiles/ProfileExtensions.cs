using AutoMapper;
using VivaioInCloud.Common.Abstraction.Entities;

namespace VivaioInCloud.Common.Entities.Profiles
{
    public static class ProfileExtensions
    {
        public static IMappingExpression<TEntity, TReadDto> ForEntityToReadDto<TEntity, TReadDto>(this IMappingExpression<TEntity, TReadDto> expression)
            where TEntity : class, IAuditableUtc, IIdentified
            where TReadDto : class, IAuditableUtc, IIdentified
        {
            expression = expression
                        .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.Id))
                        .ForMember(dest => dest.CreatedAtUtc, opt => opt.MapFrom(source => source.CreatedAtUtc))
                        .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(source => source.CreatedBy))
                        .ForMember(dest => dest.UpdatedAtUtc, opt => opt.MapFrom(source => source.UpdatedAtUtc))
                        .ForMember(dest => dest.UpdatedBy, opt => opt.MapFrom(source => source.UpdatedBy))
                        .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(source => source.IsDeleted))
                        ;

            return expression;
        }


        public static IMappingExpression<TWriteDto, TEntity> ForWriteDtoToEntity<TWriteDto, TEntity>(this IMappingExpression<TWriteDto, TEntity> expression, bool includeConversions = true)
            where TWriteDto : class
            where TEntity : class, IAuditableUtc, IIdentified
        {
            expression = expression
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAtUtc, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAtUtc, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore());

            return expression;
        }
    }
}

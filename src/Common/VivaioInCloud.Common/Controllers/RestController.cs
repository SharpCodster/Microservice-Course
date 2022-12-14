using Ardalis.Specification;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VivaioInCloud.Common.Abstraction.Entities;
using VivaioInCloud.Common.Abstraction.Services;
using VivaioInCloud.Common.Entities.Responses;
using VivaioInCloud.Common.Json;
using VivaioInCloud.Common.Validators;

namespace VivaioInCloud.Common.Controllers
{
    public abstract class RestController<TEntity, TOut, TIn> : ControllerBase
        where TEntity : class, IIdentified
        where TOut : class, IIdentified
        where TIn : class
    {
        protected readonly ILogger<RestController<TEntity, TOut, TIn>> _logger;
        protected readonly IBaseService<TEntity> _service;
        protected readonly IMapper _mapper;
        protected readonly IValidator<TIn> _validator;

        public RestController(IValidator<TIn> validator, IMapper mapper, IBaseService<TEntity> service, ILogger<RestController<TEntity, TOut, TIn>> logger)
        {
            _validator = validator;
            _mapper = mapper;
            _service = service;
            _logger = logger;
        }

        protected async Task<IActionResult> GetWithSpecification(ISpecification<TEntity> spec)
        {
            try
            {
                var entities = await _service.ListAsync(spec);
                int count = await _service.CountAsync(spec);

                IEnumerable<TOut> dtos = _mapper.Map<IEnumerable<TOut>>(entities);

                PagedResponse<TOut> response = new PagedResponse<TOut>();

                response.Data = dtos;
                response.Metadata.Page = 1;
                response.Metadata.PageSize = count;
                response.Metadata.TotalPages = 1;

                if (spec.Skip != null && spec.Take != null)
                {
                    response.Metadata.Page = (int)spec.Skip / (int)spec.Take + 1;
                    response.Metadata.PageSize = (int)spec.Take;
                    response.Metadata.TotalPages = (int)Math.Ceiling((double)count / (int)spec.Take);
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
        }

        protected async Task<IActionResult> GetByIdMethod(string id)
        {
            try
            {
                GuidValidator validator = new GuidValidator();
                await validator.ValidateAndThrowAsync(id);

                var entity = await _service.GetByIdAsync(id);

                if (entity == null)
                {
                    return NotFound();
                }

                TOut dto = _mapper.Map<TOut>(entity);

                return Ok(dto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
        }

        protected async Task<IActionResult> PostMethod(TIn newDto)
        {
            try
            {
                await _validator.ValidateAndThrowAsync(newDto);

                TEntity entity = _mapper.Map<TEntity>(newDto);
                var createdEntity = await _service.CreateAsync(entity);
                Uri uri = new Uri($"{ControllerContext.ActionDescriptor.AttributeRouteInfo.Template}/{createdEntity.Id}", UriKind.Relative);
                TOut dto = _mapper.Map<TOut>(createdEntity);
                return Created(uri, dto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
        }

        protected async Task<IActionResult> PutMethod(string id, TIn updateDto)
        {
            try
            {
                GuidValidator validator = new GuidValidator();
                await validator.ValidateAndThrowAsync(id);
                await _validator.ValidateAndThrowAsync(updateDto);

                TEntity entity = await _service.GetByIdAsync(id);
                TEntity originalEntity = entity.JsonClone();
                _mapper.Map(updateDto, entity);
                var updatedEntity = await _service.UpdateAsync(entity);
                //return NoContent();
                TOut dto = _mapper.Map<TOut>(updatedEntity);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
        }

        protected async Task<IActionResult> PatchMethod(string id, Dictionary<string, object> valuesToPatch)
        {
            try
            {
                GuidValidator validator = new GuidValidator();
                await validator.ValidateAndThrowAsync(id);

                var patchedEntity = await _service.PatchAsync(id, valuesToPatch);
                //return NoContent();
                TOut dto = _mapper.Map<TOut>(patchedEntity);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
        }

        protected async Task<IActionResult> DeleteMethod(string id)
        {
            try
            {
                GuidValidator validator = new GuidValidator();
                await validator.ValidateAndThrowAsync(id);

                await _service.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}

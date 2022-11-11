using Ardalis.Specification;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VivaioInCloud.Catalog.Abstraction.Services;
using VivaioInCloud.Catalog.Entities.Dtos;
using VivaioInCloud.Catalog.Entities.Models;
using VivaioInCloud.Common;
using VivaioInCloud.Common.Abstraction.Services;
using VivaioInCloud.Common.Controllers;
using VivaioInCloud.Common.Entities.Responses;
using VivaioInCloud.Common.Specifications;
using VivaioInCloud.Common.Validators;

namespace VivaioInCloud.Catalog.Api.Controllers
{
    [ApiController]
    [Route("api/v1")]
    [Authorize(Roles = $"{SolutionConstants.Authorization.Roles.ADMIN},{SolutionConstants.Authorization.Roles.USER}")]
    public class PreferencesController : ControllerBase
    {
        protected readonly ILogger<PreferencesController> _logger;
        protected readonly IBaseService<UserPreferences> _service;
        protected readonly IMapper _mapper;
        protected readonly IValidator<UserPreferencesDtoWrite> _validator;

        public PreferencesController(IValidator<UserPreferencesDtoWrite> validator, IMapper mapper, IUserPreferencesService service, ILogger<PreferencesController> logger)
        {
            _validator = validator;
            _mapper = mapper;
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        [Route("preferences")]
        [Tags("catalog-preferences")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var entities = await _service.ListAllAsync();
                int count = await _service.CountAllAsync();

                IEnumerable<UserPreferencesDtoRead> dtos = _mapper.Map<IEnumerable<UserPreferencesDtoRead>>(entities);
                PagedResponse<UserPreferencesDtoRead> response = new PagedResponse<UserPreferencesDtoRead>();

                response.Data = dtos;
                response.Metadata.Page = 1;
                response.Metadata.PageSize = count;
                response.Metadata.TotalPages = 1;

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("preferences/{id}")]
        [Tags("catalog-preferences")]
        public async Task<IActionResult> GetById([FromRoute] string id)
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

                UserPreferencesDtoRead dto = _mapper.Map<UserPreferencesDtoRead>(entity);

                return Ok(dto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("preferences")]
        [Tags("catalog-preferences")]
        public async Task<IActionResult> Create([FromBody] UserPreferencesDtoWrite newDto)
        {
            try
            {
                await _validator.ValidateAndThrowAsync(newDto);

                UserPreferences entity = _mapper.Map<UserPreferences>(newDto);
                var createdEntity = await _service.CreateAsync(entity);
                Uri uri = new Uri($"{ControllerContext.ActionDescriptor.AttributeRouteInfo.Template}/{createdEntity.Id}", UriKind.Relative);
                UserPreferencesDtoRead dto = _mapper.Map<UserPreferencesDtoRead>(createdEntity);
                return Created(uri, dto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("preferences/{id}")]
        [Tags("catalog-preferences")]
        public async Task<IActionResult> Delete(string id)
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


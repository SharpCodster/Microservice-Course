using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VivaioInCloud.Catalog.Abstraction.Services;
using VivaioInCloud.Catalog.Entities.Dtos;
using VivaioInCloud.Catalog.Entities.Models;
using VivaioInCloud.Common;
using VivaioInCloud.Common.Controllers;
using VivaioInCloud.Common.Specifications;

namespace VivaioInCloud.Catalog.Api.Controllers
{
    [ApiController]
    [Route("api/v1")]
    [Authorize(Roles = $"{SolutionConstants.Authorization.Roles.ADMIN},{SolutionConstants.Authorization.Roles.USER}")]
    public class PreferencesController : RestController<UserPreference, UserPreferenceDtoRead, UserPreferenceDtoWrite>
    {
        public PreferencesController(IValidator<UserPreferenceDtoWrite> validator, IMapper mapper, IUserPreferenceService service, ILogger<PreferencesController> logger)
            : base(validator, mapper, service, logger)
        {

        }

        [HttpGet]
        [Route("preferences")]
        [Tags("catalog-preferences")]
        public async Task<IActionResult> Get([FromQuery] Dictionary<string, string> request)
        {
            var spec = new BaseQueryStringSpecification<UserPreference>(request);
            return await GetWithSpecification(spec);
        }

        [HttpGet]
        [Route("preferences/{id}")]
        [Tags("catalog-preferences")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            return await GetByIdMethod(id);
        }

        [HttpPost]
        [Route("preferences")]
        [Tags("catalog-preferences")]
        public async Task<IActionResult> Create([FromBody] UserPreferenceDtoWrite newDto)
        {
            return await PostMethod(newDto);
        }

        [HttpDelete]
        [Route("preferences/{id}")]
        [Tags("catalog-preferences")]
        public async Task<IActionResult> Delete(string id)
        {
            return await DeleteMethod(id);
        }
    }
}


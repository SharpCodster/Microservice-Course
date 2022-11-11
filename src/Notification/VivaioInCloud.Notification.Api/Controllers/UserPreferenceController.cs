using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VivaioInCloud.Common;
using VivaioInCloud.Common.Controllers;
using VivaioInCloud.Common.Specifications;
using VivaioInCloud.Notification.Abstraction.Services;
using VivaioInCloud.Notification.Entities.Dtos;
using VivaioInCloud.Notification.Entities.Models;

namespace VivaioInCloud.Notification.Api.Controllers
{
    [ApiController]
    [Route("api/v1")]
    [Authorize(Roles = SolutionConstants.Authorization.Roles.ADMIN)]
    public class UserPreferenceController : RestController<UserPreference, UserPreferenceDtoRead, UserPreferenceDtoWrite>
    {
        public UserPreferenceController(IValidator<UserPreferenceDtoWrite> validator, IMapper mapper, IUserPreferenceService service, ILogger<UserPreferenceController> logger)
            : base(validator, mapper, service, logger)
        {
        }

        [HttpGet]
        [Route("user-preferences")]
        [Tags("notification-user-preferences")]
        public async Task<IActionResult> Get([FromQuery] Dictionary<string, string> request)
        {
            var spec = new BaseQueryStringSpecification<UserPreference>(request);
            return await GetWithSpecification(spec);
        }

        [HttpGet]
        [Route("user-preferences/{id}")]
        [Tags("notification-user-preferences")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            return await GetByIdMethod(id);
        }

        [HttpPost]
        [Route("user-preferences")]
        [Tags("notification-user-preferences")]
        [Authorize(Roles = SolutionConstants.Authorization.Roles.ADMIN)]
        public async Task<IActionResult> Create([FromBody] UserPreferenceDtoWrite newDto)
        {
            return await PostMethod(newDto);
        }

        [HttpPut]
        [Route("user-preferences/{id}")]
        [Tags("notification-user-preferences")]
        [Authorize(Roles = SolutionConstants.Authorization.Roles.ADMIN)]
        public async Task<IActionResult> Update(string id, [FromBody] UserPreferenceDtoWrite updateDto)
        {
            return await PutMethod(id, updateDto);
        }

        [HttpPatch]
        [Route("user-preferences/{id}")]
        [Tags("notification-user-preferences")]
        [Authorize(Roles = SolutionConstants.Authorization.Roles.ADMIN)]
        public async Task<IActionResult> Patch(string id, [FromBody] Dictionary<string, object> valuesToPatch)
        {
            return await PatchMethod(id, valuesToPatch);
        }

        [HttpDelete]
        [Route("user-preferences/{id}")]
        [Tags("notification-user-preferences")]
        [Authorize(Roles = SolutionConstants.Authorization.Roles.ADMIN)]
        public async Task<IActionResult> Delete(string id)
        {
            return await DeleteMethod(id);
        }
    }
}



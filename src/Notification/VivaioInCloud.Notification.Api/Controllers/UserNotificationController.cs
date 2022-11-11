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
    public class UserNotificationController : RestController<UserNotification, UserNotificationDtoRead, UserNotificationDtoWrite>
    {
        public UserNotificationController(IValidator<UserNotificationDtoWrite> validator, IMapper mapper, IUserNotificationService service, ILogger<UserNotificationController> logger)
            : base(validator, mapper, service, logger)
        {
        }

        [HttpGet]
        [Route("user-notification")]
        [Tags("notification-user-notification")]
        public async Task<IActionResult> Get([FromQuery] Dictionary<string, string> request)
        {
            var spec = new AuditableQueryStringSpecification<UserNotification>(request);
            return await GetWithSpecification(spec);
        }

        [HttpGet]
        [Route("user-notification/{id}")]
        [Tags("notification-user-notification")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            return await GetByIdMethod(id);
        }

        [HttpPost]
        [Route("user-notification")]
        [Tags("notification-user-notification")]
        [Authorize(Roles = SolutionConstants.Authorization.Roles.ADMIN)]
        public async Task<IActionResult> Create([FromBody] UserNotificationDtoWrite newDto)
        {
            return await PostMethod(newDto);
        }

        [HttpPut]
        [Route("user-notification/{id}")]
        [Tags("notification-user-notification")]
        [Authorize(Roles = SolutionConstants.Authorization.Roles.ADMIN)]
        public async Task<IActionResult> Update(string id, [FromBody] UserNotificationDtoWrite updateDto)
        {
            return await PutMethod(id, updateDto);
        }

        [HttpPatch]
        [Route("user-notification/{id}")]
        [Tags("notification-user-notification")]
        [Authorize(Roles = SolutionConstants.Authorization.Roles.ADMIN)]
        public async Task<IActionResult> Patch(string id, [FromBody] Dictionary<string, object> valuesToPatch)
        {
            return await PatchMethod(id, valuesToPatch);
        }

        [HttpDelete]
        [Route("user-notification/{id}")]
        [Tags("notification-user-notification")]
        [Authorize(Roles = SolutionConstants.Authorization.Roles.ADMIN)]
        public async Task<IActionResult> Delete(string id)
        {
            return await DeleteMethod(id);
        }
    }
}


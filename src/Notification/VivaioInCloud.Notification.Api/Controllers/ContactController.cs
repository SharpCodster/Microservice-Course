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
    public class ContactController : RestController<Contact, ContactDtoRead, ContactDtoWrite>
    {
        public ContactController(IValidator<ContactDtoWrite> validator, IMapper mapper, IContactService service, ILogger<ContactController> logger)
            : base(validator, mapper, service, logger)
        {
        }

        [HttpGet]
        [Route("contacts")]
        [Tags("notification-contacts")]
        public async Task<IActionResult> Get([FromQuery] Dictionary<string, string> request)
        {
            var spec = new AuditableQueryStringSpecification<Contact>(request);
            return await GetWithSpecification(spec);
        }

        [HttpGet]
        [Route("contacts/{id}")]
        [Tags("notification-contacts")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            return await GetByIdMethod(id);
        }

        [HttpPost]
        [Route("contacts")]
        [Tags("notification-contacts")]
        [Authorize(Roles = SolutionConstants.Authorization.Roles.ADMIN)]
        public async Task<IActionResult> Create([FromBody] ContactDtoWrite newDto)
        {
            return await PostMethod(newDto);
        }

        [HttpPut]
        [Route("contacts/{id}")]
        [Tags("notification-contacts")]
        [Authorize(Roles = SolutionConstants.Authorization.Roles.ADMIN)]
        public async Task<IActionResult> Update(string id, [FromBody] ContactDtoWrite updateDto)
        {
            return await PutMethod(id, updateDto);
        }

        [HttpPatch]
        [Route("contacts/{id}")]
        [Tags("notification-contacts")]
        [Authorize(Roles = SolutionConstants.Authorization.Roles.ADMIN)]
        public async Task<IActionResult> Patch(string id, [FromBody] Dictionary<string, object> valuesToPatch)
        {
            return await PatchMethod(id, valuesToPatch);
        }

        [HttpDelete]
        [Route("contacts/{id}")]
        [Tags("notification-contacts")]
        [Authorize(Roles = SolutionConstants.Authorization.Roles.ADMIN)]
        public async Task<IActionResult> Delete(string id)
        {
            return await DeleteMethod(id);
        }
    }
}

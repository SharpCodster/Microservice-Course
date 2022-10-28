using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VivaioInCloud.Common;
using VivaioInCloud.Common.Controllers;
using VivaioInCloud.Identity.Abstraction.Services;
using VivaioInCloud.Identity.Entities.Dtos;
using VivaioInCloud.Identity.Entities.Models;

namespace VivaioInCloud.Identity.Controllers
{
    [Route("api/v1")]
    [ApiController]
    [Authorize(Roles = SolutionConstants.Authorization.Roles.ADMIN)]
    public class ApplicationRoleController : RestController<ApplicationRole, ApplicationRoleDtoRead, ApplicationRoleDtoWrite>
    {
        public ApplicationRoleController(IValidator<ApplicationRoleDtoWrite> validator, IMapper mapper, IApplicationRoleService service, ILogger<ApplicationRoleController> logger)
            : base(validator, mapper, service, logger)
        {

        }

        [HttpGet]
        [Route("application-roles")]
        [Tags("ApplicationRoles")]
        public async Task<IActionResult> Get([FromQuery] Dictionary<string, string> request)
        {
            return await GetMethod(request);
        }

        [HttpGet]
        [Route("application-roles/{id}")]
        [Tags("ApplicationRoles")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            return await GetByIdMethod(id);
        }

        [HttpPost]
        [Route("application-roles")]
        [Tags("ApplicationRoles")]
        public async Task<IActionResult> Create([FromBody] ApplicationRoleDtoWrite newDto)
        {
            return await PostMethod(newDto);
        }

        [HttpPut]
        [Route("application-roles/{id}")]
        [Tags("ApplicationRoles")]
        public async Task<IActionResult> Update([FromRoute] string id, [FromBody] ApplicationRoleDtoWrite updateDto)
        {
            return await PutMethod(id, updateDto);
        }

        [HttpPatch]
        [Route("application-roles/{id}")]
        [Tags("ApplicationRoles")]
        public async Task<IActionResult> Patch([FromRoute] string id, [FromBody] Dictionary<string, object> valuesToPatch)
        {
            return await PatchMethod(id, valuesToPatch);
        }

        [HttpDelete]
        [Route("application-roles/{id}")]
        [Tags("ApplicationRoles")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            return await DeleteMethod(id);
        }
    }
}

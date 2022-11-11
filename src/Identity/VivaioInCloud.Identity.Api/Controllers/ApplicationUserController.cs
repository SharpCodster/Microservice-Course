using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VivaioInCloud.Common;
using VivaioInCloud.Common.Controllers;
using VivaioInCloud.Common.Specifications;
using VivaioInCloud.Identity.Abstraction.Services;
using VivaioInCloud.Identity.Entities.Dtos;
using VivaioInCloud.Identity.Entities.Models;

namespace VivaioInCloud.Identity.Controllers
{
    [Route("api/v1")]
    [ApiController]
    [Authorize(Roles = SolutionConstants.Authorization.Roles.ADMIN)]
    public class ApplicationUserController : RestController<ApplicationUser, ApplicationUserDtoRead, ApplicationUserDtoWrite>
    {
        private readonly IUserAuthenticationManager _identityService;

        public ApplicationUserController(
            IUserAuthenticationManager identityService,
            IValidator<ApplicationUserDtoWrite> validator,
            IMapper mapper, IApplicationUserService service,
            ILogger<ApplicationUserController> logger)
            : base(validator, mapper, service, logger)
        {
            _identityService = identityService;
        }

        [HttpGet]
        [Route("application-users")]
        [Tags("application-users")]
        public async Task<IActionResult> Get([FromQuery] Dictionary<string, string> request)
        {
            var spec = new AuditableQueryStringSpecification<ApplicationUser>(request);
            return await GetWithSpecification(spec);
        }

        [HttpGet]
        [Route("application-users/{id}")]
        [Tags("application-users")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            return await GetByIdMethod(id);
        }

        [HttpPost]
        [Route("application-users")]
        [Tags("application-users")]
        public async Task<IActionResult> Create([FromBody] ApplicationUserDtoWrite newDto)
        {
            return await PostMethod(newDto);
        }

        [HttpPut]
        [Route("application-users/{id}")]
        [Tags("application-users")]
        public async Task<IActionResult> Update([FromRoute] string id, [FromBody] ApplicationUserDtoWrite updateDto)
        {
            return await PutMethod(id, updateDto);
        }

        [HttpPatch]
        [Route("application-users/{id}")]
        [Tags("application-users")]
        public async Task<IActionResult> Patch([FromRoute] string id, [FromBody] Dictionary<string, object> valuesToPatch)
        {
            return await PatchMethod(id, valuesToPatch);
        }

        [HttpDelete]
        [Route("application-users/{id}")]
        [Tags("application-users")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            return await DeleteMethod(id);
        }


        [HttpGet]
        [Route("application-users/{id}/deactivate")]
        [Tags("application-users")]
        public async Task<ActionResult> Deactivate([FromRoute] string userId)
        {
            var response = await _identityService.DeactivateUser(userId);

            if (response)
            {
                return Ok(response);
            }

            return StatusCode(StatusCodes.Status400BadRequest, response);
        }

        //[HttpPost]
        //[Route("application-users/create-admin")]
        //[Tags("application-users")]
        //public async Task<ActionResult> CreateAdmin([FromBody] ApplicationUserDtoWrite newDto)
        //{
        //    //var response = await _identityService.DeactivateUser(userId);

        //    //if (response)
        //    //{
        //    //    return Ok(response);
        //    //}

        //    return StatusCode(StatusCodes.Status400BadRequest, response);
        //}
    }
}

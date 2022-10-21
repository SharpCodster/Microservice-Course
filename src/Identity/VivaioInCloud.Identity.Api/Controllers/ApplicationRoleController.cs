using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using VivaioInCloud.Common.Controllers;
using VivaioInCloud.Identity.Abstraction.Services;
using VivaioInCloud.Identity.Entities.Dtos;
using VivaioInCloud.Identity.Entities.Models;

namespace VivaioInCloud.Identity.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApplicationRoleController : RestController<ApplicationRole, ApplicationRoleDtoRead, ApplicationRoleDtoWrite>
    {
        public ApplicationRoleController(IValidator<ApplicationRoleDtoWrite> validator, IMapper mapper, IApplicationRoleService service, ILogger<ApplicationRoleController> logger)
            : base(validator, mapper, service, logger)
        {

        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Dictionary<string, string> request)
        {
            return await GetMethod(request);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            return await GetByIdMethod(id);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ApplicationRoleDtoWrite newDto)
        {
            return await PostMethod(newDto);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] ApplicationRoleDtoWrite updateDto)
        {
            return await PutMethod(id, updateDto);
        }

        [HttpPatch]
        [Route("{id}")]
        public async Task<IActionResult> Patch(string id, [FromBody] Dictionary<string, object> valuesToPatch)
        {
            return await PatchMethod(id, valuesToPatch);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            return await DeleteMethod(id);
        }
    }
}

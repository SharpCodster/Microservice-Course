using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using VivaioInCloud.Catalog.Abstraction.Services;
using VivaioInCloud.Catalog.Entities.Dtos;
using VivaioInCloud.Catalog.Entities.Models;
using VivaioInCloud.Common.Controllers;


namespace VivaioInCloud.Catalog.Api.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class CategoriesController : RestController<ItemType, ItemTypeDtoRead, ItemTypeDtoWrite>
    {
        public CategoriesController(IValidator<ItemTypeDtoWrite> validator, IMapper mapper, IItemTypeService service, ILogger<CategoriesController> logger)
            : base(validator, mapper, service, logger)
        {
        }

        [HttpGet]
        [Route("catalog")]
        [Tags("catalog-catalog")]
        public async Task<IActionResult> Get([FromQuery] Dictionary<string, string> request)
        {
            return await GetMethod(request);
        }

        [HttpGet]
        [Route("catalog/{id}")]
        [Tags("catalog-catalog")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            return await GetByIdMethod(id);
        }

        [HttpPost]
        [Route("catalog")]
        [Tags("catalog-catalog")]
        //[Authorize(Roles = SolutionConstants.Authorization.Roles.ADMIN)]
        public async Task<IActionResult> Create([FromBody] ItemTypeDtoWrite newDto)
        {
            return await PostMethod(newDto);
        }

        [HttpPut]
        [Route("catalog/{id}")]
        [Tags("catalog-catalog")]
        //[Authorize(Roles = SolutionConstants.Authorization.Roles.ADMIN)]
        public async Task<IActionResult> Update(string id, [FromBody] ItemTypeDtoWrite updateDto)
        {
            return await PutMethod(id, updateDto);
        }

        [HttpPatch]
        [Route("catalog/{id}")]
        [Tags("catalog-catalog")]
        //[Authorize(Roles = SolutionConstants.Authorization.Roles.ADMIN)]
        public async Task<IActionResult> Patch(string id, [FromBody] Dictionary<string, object> valuesToPatch)
        {
            return await PatchMethod(id, valuesToPatch);
        }

        [HttpDelete]
        [Route("catalog/{id}")]
        [Tags("catalog-catalog")]
        //[Authorize(Roles = SolutionConstants.Authorization.Roles.ADMIN)]
        public async Task<IActionResult> Delete(string id)
        {
            return await DeleteMethod(id);
        }
    }
}

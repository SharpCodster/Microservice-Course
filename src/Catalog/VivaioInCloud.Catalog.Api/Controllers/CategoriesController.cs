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
    public class CategoriesController : RestController<ItemType, ItemTypeDtoRead, ItemTypeDtoWrite>
    {
        public CategoriesController(IValidator<ItemTypeDtoWrite> validator, IMapper mapper, IItemTypeService service, ILogger<CategoriesController> logger)
            : base(validator, mapper, service, logger)
        {
        }

        [HttpGet]
        [Route("category")]
        [Tags("catalog-category")]
        public async Task<IActionResult> Get([FromQuery] Dictionary<string, string> request)
        {
            var spec = new AuditableQueryStringSpecification<ItemType>(request);
            return await GetWithSpecification(spec);
        }

        [HttpGet]
        [Route("category/{id}")]
        [Tags("catalog-category")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            return await GetByIdMethod(id);
        }

        [HttpPost]
        [Route("category")]
        [Tags("catalog-category")]
        [Authorize(Roles = SolutionConstants.Authorization.Roles.ADMIN)]
        public async Task<IActionResult> Create([FromBody] ItemTypeDtoWrite newDto)
        {
            return await PostMethod(newDto);
        }

        [HttpPut]
        [Route("category/{id}")]
        [Tags("catalog-category")]
        [Authorize(Roles = SolutionConstants.Authorization.Roles.ADMIN)]
        public async Task<IActionResult> Update(string id, [FromBody] ItemTypeDtoWrite updateDto)
        {
            return await PutMethod(id, updateDto);
        }

        [HttpPatch]
        [Route("category/{id}")]
        [Tags("catalog-category")]
        [Authorize(Roles = SolutionConstants.Authorization.Roles.ADMIN)]
        public async Task<IActionResult> Patch(string id, [FromBody] Dictionary<string, object> valuesToPatch)
        {
            return await PatchMethod(id, valuesToPatch);
        }

        [HttpDelete]
        [Route("category/{id}")]
        [Tags("catalog-category")]
        [Authorize(Roles = SolutionConstants.Authorization.Roles.ADMIN)]
        public async Task<IActionResult> Delete(string id)
        {
            return await DeleteMethod(id);
        }
    }
}

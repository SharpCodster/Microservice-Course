﻿using AutoMapper;
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
    public class ApplicationUserController : RestController<ApplicationUser, ApplicationUserDtoRead, ApplicationUserDtoWrite>
    {
        public ApplicationUserController(IValidator<ApplicationUserDtoWrite> validator, IMapper mapper, IApplicationUserService service, ILogger<ApplicationUserController> logger)
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
        public async Task<IActionResult> Create([FromBody] ApplicationUserDtoWrite newDto)
        {
            return await PostMethod(newDto);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] ApplicationUserDtoWrite updateDto)
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
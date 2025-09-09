using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Ascendix_Backend.Dto.ModuleDto;
using Ascendix_Backend.Interfaces;
using Ascendix_Backend.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Ascendix_Backend.Controllers
{
    [ApiController]
    [Route("api/v1/module")]
    public class ModuleController : ControllerBase
    {
        private readonly IModuleRepository _moduleRepo;
        public ModuleController(IModuleRepository moduleRepo)
        {
            _moduleRepo = moduleRepo;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateModule create)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var module = create.toModule();
            var result = await _moduleRepo.create(module);
            return Ok(result.fromModule());
        }

        [HttpGet("getall")]
        public async Task<IActionResult> getAll()
        {
            var module = await _moduleRepo.getAll();
            var modules = module.Select(m => m.fromModule()).ToList();
            return Ok(modules);
        }

        [HttpGet("get/{id:guid}")]
        public async Task<IActionResult> getById([FromRoute] Guid id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var module = await _moduleRepo.getById(id);
            if (module == null) return StatusCode(404, "Module Not Found");

            return Ok(module.fromModule());
        }

        [HttpPatch("update/{id:guid}")]
        public async Task<IActionResult> update([FromRoute] Guid id, [FromBody] UpdateModule update)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var module = await _moduleRepo.update(id, update);
            if (module == null) return StatusCode(404, "Module Not Found");

            return Ok(module.fromModule());
        }

        [HttpDelete("delete/{id:guid}")]
        public async Task<IActionResult> delete([FromRoute] Guid id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var module = await _moduleRepo.deleteById(id);
            if (module == null) return StatusCode(404, "Module Not Found");

            return StatusCode(200, "Module successfully deleted");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Ascendix_Backend.Dto.UserModuleDto;
using Ascendix_Backend.Interfaces;
using Ascendix_Backend.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ascendix_Backend.Controllers
{
    [ApiController]
    [Route("api/v1/user-module")]
    public class UserModuleController : ControllerBase
    {
        private readonly IUserModuleRepository _userModuleRepo;
        public UserModuleController(IUserModuleRepository userModuleRepo)
        {
            _userModuleRepo = userModuleRepo;
        }

        [Authorize(Roles = "Admin, User")]
        [HttpPost("create")]
        public async Task<IActionResult> create([FromBody] CreateUserModule create)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var userModule = create.toUserModule();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return StatusCode(404, "User Non-Existent");

            userModule.userId = userId;
            await _userModuleRepo.create(userModule);

            return Ok(userModule.fromUserModule());

        }

        [Authorize(Roles = "Admin, User")]
        [HttpGet("getall")]
        public async Task<IActionResult> update()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return StatusCode(404, "User Non-Existent");

            var userModule = await _userModuleRepo.getAll(userId);
            var userModules = userModule.Select(c => c.fromUserModule()).ToList();

            return Ok(userModules);
        }

        [Authorize(Roles = "Admin, User")]
        [HttpGet("get/{id:guid}")]
        public async Task<IActionResult> getById([FromRoute] Guid id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return StatusCode(404, "User Non-Existent");

            var userModule = await _userModuleRepo.getById(id, userId);
            if (userModule == null) return StatusCode(404, "User Module Not Found");

            return Ok(userModule.fromUserModule());
        }

        [Authorize(Roles = "Admin, User")]
        [HttpPatch("update/{id:guid}")]
        public async Task<IActionResult> update([FromRoute] Guid id, [FromBody] UpdateUserModule update)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return StatusCode(404, "User Non-Existent");

            var userModule = await _userModuleRepo.update(id, userId, update);
            if (userModule == null) return StatusCode(404, "User Module Not Found");

            return Ok(userModule.fromUserModule());
        }

        [Authorize(Roles = "Admin, User")]
        [HttpDelete("delete/{id:guid}")]
        public async Task<IActionResult> delete([FromRoute] Guid id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return StatusCode(404, "User Non-Existent");

            var userModule = await _userModuleRepo.delete(id, userId);
            if (userModule == null) return StatusCode(404, "User Module Not Found");

            return Ok(userModule.fromUserModule());
        }
    }
}
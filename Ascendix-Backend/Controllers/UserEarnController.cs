using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Ascendix_Backend.Dto.UserEarnDto;
using Ascendix_Backend.Interfaces;
using Ascendix_Backend.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ascendix_Backend.Controllers
{
    [ApiController]
    [Route("api/v1/user-earn")]
    public class UserEarnController : ControllerBase
    {
        private readonly IUserEarnRepository _earnRepo;
        public UserEarnController(IUserEarnRepository earnRepo)
        {
            _earnRepo = earnRepo;
        }

        [Authorize(Roles = "Admin, User")]
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateUserEarn create)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var userEarn = create.toUserEarn();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return BadRequest();

            userEarn.userId = userId;
            var result = await _earnRepo.create(userEarn);

            return Ok(result?.fromUserEarn());
        }

        [Authorize(Roles = "Admin, User")]
        [HttpGet("getAll")]
        public async Task<IActionResult> getAll()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return BadRequest();

            var result = await _earnRepo.getAll(userId);
            var userEarn = result.Select(c => c.fromUserEarn()).ToList();

            return Ok(userEarn);
        }

        [Authorize(Roles = "Admin, User")]
        [HttpGet("get/{id:guid}")]
        public async Task<IActionResult> getById([FromRoute] Guid id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return BadRequest();

            var userEarn = await _earnRepo.getById(id, userId);
            if (userEarn == null) return StatusCode(404, "User Earning not Found");

            return Ok(userEarn.fromUserEarn());
        }

        [Authorize(Roles = "Admin, User")]
        [HttpPatch("update/{id:guid}")]
        public async Task<IActionResult> update([FromRoute] Guid id, [FromBody] UpdateUserEarn update)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return StatusCode(404, "User Non Existent");

            var userEarn = await _earnRepo.update(id, userId, update);
            if (userEarn == null) return StatusCode(404, "User Earning Not Found");

            return Ok(userEarn.fromUserEarn());
        }

        [Authorize(Roles = "Admin, User")]
        [HttpDelete("delete/{id:guid}")]
        public async Task<IActionResult> delete([FromRoute] Guid id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return StatusCode(404, "User Non Existent");

            var userEarn = await _earnRepo.deleteById(id, userId);
            if (userEarn == null) return StatusCode(404, "User Earning Not Found");

            return StatusCode(200, "User Earning Successfully deleted");
        }
    }
}
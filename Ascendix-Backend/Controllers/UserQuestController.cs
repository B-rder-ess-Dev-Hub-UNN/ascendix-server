using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Ascendix_Backend.Dto.UserQuestDto;
using Ascendix_Backend.Interfaces;
using Ascendix_Backend.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ascendix_Backend.Controllers
{
    [ApiController]
    [Route("api/v1/user-quest")]
    public class UserQuestController : ControllerBase
    {
        private readonly IUserQuestRepository _userQuestRepo;
        public UserQuestController(IUserQuestRepository userQuestRepo)
        {
            _userQuestRepo = userQuestRepo;
        }

        [Authorize(Roles = "Admin, User")]
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateUserQuest create)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var userQuest = create.toUserQuest();
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return StatusCode(404, "User Not Found");

            userQuest.userId = userId;
            var result = await _userQuestRepo.Create(userQuest);

            return Ok(result.fromUserQuest());
        }

        [Authorize(Roles = "Admin, User")]
        [HttpGet("getall")]
        public async Task<IActionResult> getAll()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return StatusCode(404, "User Not Found");
            var userQuest = await _userQuestRepo.GetAll(userId);
            var userQuests = userQuest.Select(c => c.fromUserQuest()).ToList();

            return Ok(userQuests);
        }

        [Authorize(Roles = "Admin, User")]
        [HttpGet("get/{id:guid}")]

        public async Task<IActionResult> get([FromRoute] Guid id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userQuest = await _userQuestRepo.GetbyId(id);
            if (userQuest == null || userQuest.userId != userId) return StatusCode(404, "User Quest Not Found");

            return Ok(userQuest.fromUserQuest());
        }

        [Authorize(Roles = "Admin, User")]
        [HttpPatch("update/{id:guid}")]
        public async Task<IActionResult> update([FromRoute] Guid id, [FromBody] UpdateUserQuest update)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
#pragma warning disable CS8604 // Possible null reference argument.
            var userQuest = await _userQuestRepo.UpdateStatus(id, userId, update);
#pragma warning restore CS8604 // Possible null reference argument.
            if (userQuest == null) return StatusCode(404, "User Quest Not Found");

            return Ok(userQuest.fromUserQuest());
        }

        [Authorize(Roles = "Admin, User")]
        [HttpDelete("delete/{id:guid}")]
        public async Task<IActionResult> delete([FromRoute] Guid id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
#pragma warning disable CS8604 // Possible null reference argument.
            var userQuest = await _userQuestRepo.DeleteById(id, userId);
#pragma warning restore CS8604 // Possible null reference argument.

            if (userQuest == null) return StatusCode(404, "User Quest Not Found");
            return StatusCode(200, "UserQuest Successfully Deleted");
        }
        
        
    }
}
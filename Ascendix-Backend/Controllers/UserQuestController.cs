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
        
    }
}
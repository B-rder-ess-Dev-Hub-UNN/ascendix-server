using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Ascendix_Backend.Dto.UserQuizAttemptDto;
using Ascendix_Backend.Interfaces;
using Ascendix_Backend.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Ascendix_Backend.Controllers
{
    [ApiController]
    [Route("api/v1/user-quiz-attempt")]
    public class UserQuizAttemptController : ControllerBase
    {
        private readonly IUserQuizAttemptRepository _attemptRepo;
        public UserQuizAttemptController(IUserQuizAttemptRepository attemptRepo)
        {
            _attemptRepo = attemptRepo;
        }

        [Authorize(Roles = "Admin, User")]
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateUserQuizAttempt create)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return StatusCode(404, "User Not Found");

            var attempt = create.toUserQuizAttempt();
            attempt.userId = userId;

            await _attemptRepo.create(attempt);
            return Ok(attempt.fromUserQuizAttempt());
        }

        [Authorize(Roles = "Admin, User")]
        [HttpGet("getall")]
        public async Task<IActionResult> getAll()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return StatusCode(404, "User Not Found");

            var attempt = await _attemptRepo.getAll(userId);
            var attempts = attempt.Select(c => c.fromUserQuizAttempt()).ToList();

            return Ok(attempts);
        }

        [Authorize(Roles = "Admin, User")]
        [HttpGet("get/{id:guid}")]
        public async Task<IActionResult> getById([FromRoute] Guid id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return StatusCode(404, "User not Found");

            var attempt = await _attemptRepo.getById(id, userId);
            if (attempt == null) return StatusCode(404, "User Quiz Attempt Not Found");

            return Ok(attempt.fromUserQuizAttempt());
        }

        [Authorize(Roles = "Admin, User")]
        [HttpPatch("update/{id:guid}")]
        public async Task<IActionResult> update([FromRoute] Guid id, [FromBody] UpdateUserQuizAttempt update)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return StatusCode(404, "User Not Found");

            var attempt = await _attemptRepo.update(id, userId, update);
            if (attempt == null) return StatusCode(404, "User Quiz Attempt Not Found");

            return Ok(attempt.fromUserQuizAttempt());
        }

        [Authorize(Roles = "Admin, User")]
        [HttpDelete("delete/{id:guid}")]
        public async Task<IActionResult> delete([FromRoute] Guid id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return StatusCode(404, "User Not Found");

            var attempt = await _attemptRepo.delete(id, userId);
            if (attempt == null) return StatusCode(404, "User Quiz Attempt Not Found");

            return StatusCode(200, "User Quiz Attempt Successfully Deleted");
        }
    }
}
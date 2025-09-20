using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Ascendix_Backend.Dto.UserCourseProgressDto;
using Ascendix_Backend.Interfaces;
using Ascendix_Backend.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ascendix_Backend.Controllers
{
    [ApiController]
    [Route("api/v1/user-course")]
    public class UserCourseController : ControllerBase
    {
        private readonly IUserCourseProgressRepository _userCourseRepo;

        public UserCourseController(IUserCourseProgressRepository userCourseRepo)
        {
            _userCourseRepo = userCourseRepo;
        }

        [Authorize(Roles = "Admin, User")]
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateUserCourseProgress create)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var userCourse = create.toUserCourseProgress();
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return StatusCode(404, "User Not Found");

            userCourse.userId = userId;
            var result = await _userCourseRepo.create(userId, userCourse);

            return Ok(result.fromUserCourseProgress());
        }

        [Authorize(Roles = "Admin, User")]
        [HttpGet("getall")]
        public async Task<IActionResult> getAll()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return StatusCode(404, "User Not Found");
            var userCourse = await _userCourseRepo.getAll(userId);
            var userCourses = userCourse.Select(c => c.fromUserCourseProgress()).ToList();

            return Ok(userCourses);
        }

        [Authorize(Roles = "Admin, User")]
        [HttpGet("get/{id:guid}")]
        public async Task<IActionResult> getById([FromRoute] Guid id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return StatusCode(404, "User Not Found");

            var userCourse = await _userCourseRepo.GetbyId(id);
            if (userCourse == null || userCourse.userId == userId) return StatusCode(404, "User Course No Found");

            return Ok(userCourse.fromUserCourseProgress());
        }

        [Authorize(Roles = "Admin, User")]
        [HttpPatch("update/{id:guid}")]
        public async Task<IActionResult> update([FromRoute] Guid id, [FromBody] UpdateUserCourseProgress update)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return StatusCode(404, "User Not Found");

            var userCourse = await _userCourseRepo.update(id, userId, update);
            if (userCourse == null) return StatusCode(404, "User Course Not Found");

            return Ok(userCourse.fromUserCourseProgress());
        }

        [Authorize(Roles = "Admin, User")]
        [HttpDelete("update/{id:guid}")]
        public async Task<IActionResult> delete([FromRoute] Guid id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return StatusCode(404, "User Not Found");

            var userCourse = await _userCourseRepo.delete(id, userId);
            if (userCourse == null) return StatusCode(404, "User Course Not Found");

            return StatusCode(200, "User Course Successfully Deleted");
        }

    }
}
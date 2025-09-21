using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Ascendix_Backend.Dto.UserCertificateDto;
using Ascendix_Backend.Interfaces;
using Ascendix_Backend.Mappers;
using Ascendix_Backend.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ascendix_Backend.Controllers
{
    [ApiController]
    [Route("api/v1/user-certificate")]
    public class UserCertificateController : ControllerBase
    {
        private readonly IUserCertificateRepository _usercertRepo;
        public UserCertificateController(IUserCertificateRepository userCertRepo)
        {
            _usercertRepo = userCertRepo;
        }

        [Authorize(Roles = "Admin, User")]
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateUserCertificate create)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userCertificate = create.toUserCertificate();
            userCertificate.userId = userId;

            await _usercertRepo.create(userCertificate);
            return Ok(userCertificate.fromUserCertificate());
        }

        [Authorize(Roles = "Admin, User")]
        [HttpGet("getall")]
        public async Task<IActionResult> getAll()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return StatusCode(404, "User Not Found");
            var userCertificate = await _usercertRepo.getAll(userId);

            var userCertificates = userCertificate.Select(c => c.fromUserCertificate()).ToList();
            return Ok(userCertificates);
        }

        [Authorize(Roles = "Admin, User")]
        [HttpGet("get/{id:guid}")]
        public async Task<IActionResult> getById([FromRoute] Guid id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return StatusCode(404, "User Not Found");

            var userCertificate = await _usercertRepo.getById(id, userId);
            if (userCertificate == null) return StatusCode(404, "User Certificate Not Found");

            return Ok(userCertificate.fromUserCertificate());
        }

        [Authorize(Roles = "Admin, User")]
        [HttpPatch("update/{id:guid}")]
        public async Task<IActionResult> update([FromRoute] Guid id, [FromBody] UpdateUserCertificate update)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return StatusCode(404, "User Not Found");

            var userCertificate = await _usercertRepo.update(id, userId, update);
            if (userCertificate == null) return StatusCode(404, "User Certificate Not Found");

            return Ok(userCertificate.fromUserCertificate());
        }

        [Authorize(Roles = "Admin, User")]
        [HttpDelete("delete/{id:guid}")]
        public async Task<IActionResult> delete([FromRoute] Guid id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return StatusCode(404, "User Not Found");

            var userCertificate = await _usercertRepo.delete(id, userId);
            if (userCertificate == null) return StatusCode(404, "User Certificate Not Found");

            return Ok(userCertificate.fromUserCertificate());
            
        }

    }
}
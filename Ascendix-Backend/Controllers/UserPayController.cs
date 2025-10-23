using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Ascendix_Backend.Dto.UserPayDto;
using Ascendix_Backend.Interfaces;
using Ascendix_Backend.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ascendix_Backend.Controllers
{
    [ApiController]
    [Route("api/v1/user-pay")]
    public class UserPayController : ControllerBase
    {
        private readonly IUserPayRepository _payRepo;
        public UserPayController(IUserPayRepository payRepo)
        {
            _payRepo = payRepo;
        }

        [Authorize(Roles = "Admin, User")]
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateUserPay create)
        {
            var pay = create.toUserPay();
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return StatusCode(404, "User Non Existent");

            pay.userId = userId;
            await _payRepo.create(pay);

            return Ok(pay.fromUserPay());
        }

        [Authorize(Roles = "Admin, User")]
        [HttpGet("getAll")]
        public async Task<IActionResult> getAll()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return StatusCode(404, "User Non Existent");

            var pay = await _payRepo.getAll(userId);
            var pays = pay.Select(c => c.fromUserPay()).ToList();

            return Ok(pays);
        }

        [Authorize(Roles = "Admin, User")]
        [HttpGet("get/{id:guid}")]
        public async Task<IActionResult> getById([FromRoute] Guid id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return StatusCode(404, "User Non Existent");

            var pay = await _payRepo.getById(id, userId);
            if (pay == null) return StatusCode(404, "User Payment Not Found");

            return Ok(pay.fromUserPay());
        }

        [Authorize(Roles = "Admin, User")]
        [HttpPatch("update/{id:guid}")]
        public async Task<IActionResult> update([FromRoute] Guid id, [FromBody] UpdateUserPay update)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return StatusCode(404, "User Non Existent");

            var pay = await _payRepo.updateById(id, userId, update);
            if (pay == null) return StatusCode(404, "User Payment Not Found");

            return Ok(pay.fromUserPay());
        }

        [Authorize(Roles = "Admin, User")]
        [HttpDelete("delete/{id:guid}")]
        public async Task<IActionResult> delete([FromRoute] Guid id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return StatusCode(404, "User Non Existent");

            var pay = await _payRepo.delete(id, userId);
            if (pay == null) return StatusCode(404, "User Payment Not Found");

            return StatusCode(404, $"User Payment {pay.id} successfully deleted");
        }
        
    }
}
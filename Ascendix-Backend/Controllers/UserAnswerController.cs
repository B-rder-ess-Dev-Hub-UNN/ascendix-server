using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Dto.UserAnswerDto;
using Ascendix_Backend.Interfaces;
using Ascendix_Backend.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ascendix_Backend.Controllers
{
    [ApiController]
    [Route("api/v1/user-answer")]
    public class UserAnswerController : ControllerBase
    {
        private readonly IUserAnswerRepository _answerRepo;
        public UserAnswerController(IUserAnswerRepository answerRepo)
        {
            _answerRepo = answerRepo;
        }

        [Authorize(Roles = "Admin, User")]
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateUserAnswer create)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var answer = create.toUserAnswer();

            await _answerRepo.create(answer);
            return Ok(answer.fromUserAnswer());
        }

        [Authorize(Roles = "Admin, User")]
        [HttpGet("getall")]
        public async Task<IActionResult> getAll([FromQuery] Guid attemptId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var answer = await _answerRepo.getAll(attemptId);
            var answers = answer.Select(c => c.fromUserAnswer()).ToList();

            return Ok(answers);
        }

        [Authorize(Roles = "Admin, User")]
        [HttpGet("get/{id:guid}")]
        public async Task<IActionResult> getById([FromRoute] Guid id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var answer = await _answerRepo.getById(id);
            if (answer == null) return StatusCode(404, "User Answer Not Found");

            return Ok(answer.fromUserAnswer());
        }

        [Authorize(Roles = "Admin, User")]
        [HttpPatch("update/{id:guid}")]
        public async Task<IActionResult> update([FromRoute] Guid id, [FromBody] UpdateUserAnswer update)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var answer = await _answerRepo.update(id, update);
            if (answer == null) return StatusCode(404, "User Answer Not Found");

            return Ok(answer.fromUserAnswer());
        }

        [Authorize(Roles = "Admin, User")]
        [HttpDelete("delete/{id:guid}")]
        public async Task<IActionResult> delete([FromRoute] Guid id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var answer = await _answerRepo.delete(id);
            if (answer == null) return StatusCode(404, "User Answer Not Found");

            return StatusCode(200, "User Answer Successfully Deleted");
        }
    } 
}
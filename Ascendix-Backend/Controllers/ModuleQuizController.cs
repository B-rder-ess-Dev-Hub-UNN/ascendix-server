using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Dto.ModuleQuizDto;
using Ascendix_Backend.Interfaces;
using Ascendix_Backend.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Ascendix_Backend.Controllers
{
    [ApiController]
    [Route("api/v1/moduleQuiz")]
    public class ModuleQuizController : ControllerBase
    {
        private readonly IModuleQuizRepository _quizRepo;
        public ModuleQuizController(IModuleQuizRepository quizRepo)
        {
            _quizRepo = quizRepo;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateModuleQuiz create)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var quiz = create.toModuleQuiz();
            var result = await _quizRepo.create(quiz);
            return Ok(result.fromModuleQuiz());
        }

        [HttpGet("getall")]
        public async Task<IActionResult> getAll()
        {
            var quiz = await _quizRepo.getAll();
            var quizzes = quiz.Select(c => c.fromModuleQuiz()).ToList();
            return Ok(quizzes);
        }

        [HttpGet("get/{id:guid}")]
        public async Task<IActionResult> getById([FromRoute] Guid id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var quiz = await _quizRepo.getById(id);
            if (quiz == null) return StatusCode(404, "Quiz Not Found");
            return Ok(quiz.fromModuleQuiz());
        }

        [HttpPatch("update/{id:guid}")]
        public async Task<IActionResult> update([FromRoute] Guid id, [FromBody] UpdateModuleQuiz update)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var quiz = await _quizRepo.update(id, update);
            if (quiz == null) return StatusCode(404, "Quiz Not Found");

            return Ok(quiz.fromModuleQuiz());
        }

        [HttpDelete("delete/{id:guid}")]
        public async Task<IActionResult> deleteById([FromRoute] Guid id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var quiz = await _quizRepo.deleteById(id);
            if (quiz == null) return StatusCode(404, "Quiz Not Found");

            return StatusCode(200, "Quiz Successfully Deleted");
        }
    }
}
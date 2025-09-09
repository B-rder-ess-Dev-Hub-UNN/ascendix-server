using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Dto.QuizQuestionDto;
using Ascendix_Backend.Interfaces;
using Ascendix_Backend.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Ascendix_Backend.Controllers
{
    [ApiController]
    [Route("api/v1/question")]
    public class QuizQuestionController : ControllerBase
    {
        private readonly IQuizQuestionRepository _questionRepo;
        public QuizQuestionController(IQuizQuestionRepository questionRepo)
        {
            _questionRepo = questionRepo;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateQuizQuestion create)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var question = create.toQuizQuestion();
            var result = await _questionRepo.create(question);

            return Ok(result.fromQuizQuestion());
        }

        [HttpGet("getall")]
        public async Task<IActionResult> getAll()
        {
            var question = await _questionRepo.getAll();
            var questions = question.Select(c => c.fromQuizQuestion()).ToList();
            return Ok(questions);
        }

        [HttpGet("get/{id:guid}")]
        public async Task<IActionResult> getById([FromRoute] Guid id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var question = await _questionRepo.getById(id);
            if (question == null) return StatusCode(404, "Question Not Found");

            return Ok(question.fromQuizQuestion());
        }

        [HttpPatch("update/{id:guid}")]
        public async Task<IActionResult> update([FromRoute] Guid id, [FromBody] UpdateQuizQuestion update)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var question = await _questionRepo.update(id, update);
            if (question == null) return StatusCode(404, "Question Not Found");

            return Ok(question.fromQuizQuestion());
        }

        [HttpDelete("delete/{id:guid}")]
        public async Task<IActionResult> update([FromRoute] Guid id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var question = await  _questionRepo.delete(id);
            if (question == null) return StatusCode(404, "Question Not Found");

            return StatusCode(200, "Question Successfully Deleted");
        }
    }
}
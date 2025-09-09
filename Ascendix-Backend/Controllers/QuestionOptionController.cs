using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Dto.QuestionOptionDto;
using Ascendix_Backend.Interfaces;
using Ascendix_Backend.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Ascendix_Backend.Controllers
{
    [ApiController]
    [Route("api/v1/options")]
    public class QuestionOptionController : ControllerBase
    {
        private readonly IQuestionOptionRepository _optionRepo;
        public QuestionOptionController(IQuestionOptionRepository questionRepo)
        {
            _optionRepo = questionRepo;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateQuestionOption create)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var optionModel = create.toQuestionOption();
            var option = await _optionRepo.create(optionModel);

            return Ok(option.fromQuestionOption());
        }

        [HttpGet("getall")]
        public async Task<IActionResult> getAll()
        {
            var option = await _optionRepo.getAll();
            var options = option.Select(o => o.fromQuestionOption()).ToList();

            return Ok(options);
        }

        [HttpGet("get/{id:guid}")]
        public async Task<IActionResult> getById([FromRoute] Guid id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var option = await _optionRepo.getById(id);
            if (option == null) return StatusCode(404, "Option Not Found");

            return Ok(option.fromQuestionOption());
        }

        [HttpPatch("update/{id:guid}")]
        public async Task<IActionResult> update([FromRoute] Guid id, [FromBody] UpdateQuestionOption update)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var option = await _optionRepo.update(id, update);
            if (option == null) return StatusCode(404, "Option Not Found");

            return Ok(option.fromQuestionOption());
        }

        [HttpDelete("delete/{id:guid}")]
        public async Task<IActionResult> delete([FromRoute] Guid id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var option = await _optionRepo.deleteById(id);
            if (option == null) return StatusCode(404, "Option Not Found");

            return StatusCode(200, "Option Successfuly Deleted");
        }
    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Dto.TagDto;
using Ascendix_Backend.Interfaces;
using Ascendix_Backend.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Ascendix_Backend.Controllers
{
    [ApiController]
    [Route("api/tag")]
    public class TagController : ControllerBase
    {
        private readonly ITagRepository _tagRepo;
        public TagController(ITagRepository tagRepo)
        {
            _tagRepo = tagRepo;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateTag create)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var tagModel = create.toTag();
            var tag = await _tagRepo.create(tagModel);

            return Ok(tag.fromTag());
        }

        [HttpGet("getall")]
        public async Task<IActionResult> getAll()
        {
            var tag = await _tagRepo.getAll();
            var tags = tag.Select(c => c.fromTag()).ToList();

            return Ok(tags);
        }

        [HttpGet("get/{id:guid}")]
        public async Task<IActionResult> getById([FromRoute] Guid id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var tag = await _tagRepo.getById(id);
            if (tag == null) return StatusCode(404, "Tag Not Found");

            return Ok(tag.fromTag());
        }

        [HttpPatch("update/{id:guid}")]
        public async Task<IActionResult> update([FromRoute] Guid id, [FromBody] UpdateTag update)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var tag = await _tagRepo.update(id, update);
            if (tag == null) return StatusCode(404, "Tag Not Found");

            return Ok(tag.fromTag());
        }

        [HttpDelete("delete/{id:guid}")]
        public async Task<IActionResult> delete([FromRoute] Guid id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var tag = await _tagRepo.delete(id);
            if (tag == null) return StatusCode(404, "Tag Not Found");

            return StatusCode(200, "Tag Successfully Deleted");
        }

    }
}
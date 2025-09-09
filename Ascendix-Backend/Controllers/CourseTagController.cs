using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Dto.CourseTagDto;
using Ascendix_Backend.Interfaces;
using Ascendix_Backend.Mappers;
using Ascendix_Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ascendix_Backend.Controllers
{
    [ApiController]
    [Route("api/v1/course-tag")]
    public class CourseTagController : ControllerBase
    {
        private readonly ICourseTagRepository _courseTagRepo;
        public CourseTagController(ICourseTagRepository courseTagRepo)
        {
            _courseTagRepo = courseTagRepo;
        }

        [HttpPost("create")]
        public async Task<IActionResult> create([FromBody] CreateCourseTag create)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var courseTagModel = create.toCourseTag();
            var courseTag = await _courseTagRepo.create(courseTagModel);

            return Ok(courseTag.fromCourseTag());
        }

        [HttpGet("getall")]
        public async Task<IActionResult> getAll()
        {
            var courseTag = await _courseTagRepo.getAll();
            var courseTags = courseTag.Select(c => c.fromCourseTag()).ToList();

            return Ok(courseTags);
        }

        [HttpGet("get/{id:guid}")]
        public async Task<IActionResult> getById([FromRoute] Guid id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var courseTag = await _courseTagRepo.getById(id);
            if (courseTag == null) return StatusCode(404, "CourseTag Not Found");

            return Ok(courseTag.fromCourseTag());
        }

        [HttpPatch("update/{id:guid}")]
        public async Task<IActionResult> update([FromRoute] Guid id, [FromBody] UpdateCourseTag update)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var courseTag = await _courseTagRepo.update(id, update);
            if (courseTag == null) return StatusCode(404, "CourseTag Not Found");

            return Ok(courseTag.fromCourseTag());
        }

        [HttpDelete("delete/{id:guid}")]
        public async Task<IActionResult> delete([FromRoute] Guid id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var courseTag = await _courseTagRepo.delete(id);
            if (courseTag == null) return StatusCode(404, "CourseTag Not Found");

            return StatusCode(200, "CourseTag Successfully Deleted");
        }
    }
}
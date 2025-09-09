using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Dto.CourseDto;
using Ascendix_Backend.Interfaces;
using Ascendix_Backend.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Ascendix_Backend.Controllers
{
    [ApiController]
    [Route("api/v1/course")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepo;
        public CourseController(ICourseRepository courseRepo)
        {
            _courseRepo = courseRepo;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> getAll()
        {
            var course = await _courseRepo.GetAll();
            var courses = course.Select(x => x.fromCourse()).ToList();
            return Ok(courses);
        }

        [HttpGet("get/{id:guid}")]
        public async Task<IActionResult> getById([FromRoute] Guid id)
        {
            var course = await _courseRepo.GetById(id);
            if (course == null) return StatusCode(404, "Course Not Found");
            return Ok(course.fromCourse());
        }

        [HttpGet("getbylibraryId/{id:guid}")]
        public async Task<IActionResult> getByLibraryId([FromRoute] Guid id)
        {
            var course = await _courseRepo.GetCourseByLibrary(id);
            return Ok(course);
        }

        [HttpPost("create")]
        public async Task<IActionResult> create([FromBody] CreateCourse create)
        {
            var course = create.toCourse();
            await _courseRepo.Create(course);
            return Ok(course.fromCourse());
        }

        [HttpPatch("update/{id:guid}")]
        public async Task<IActionResult> update([FromRoute] Guid id, [FromBody] UpdateCourse update)
        {
            var course = await _courseRepo.Update(id, update);
            if (course == null) return StatusCode(404, "Course not Found");

            return Ok(course.fromCourse());
        }

        [HttpDelete("delete/{id:guid}")]
        public async Task<IActionResult> delete([FromRoute] Guid id)
        {
            var course = await _courseRepo.DeleteById(id);
            if (course == null) return StatusCode(404, "Course Not Found");

            return StatusCode(200, "Course Successfully Deleted");
        }
    }
}
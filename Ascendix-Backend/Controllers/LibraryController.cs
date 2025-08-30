using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Dto.LibraryDto;
using Ascendix_Backend.Interfaces;
using Ascendix_Backend.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Ascendix_Backend.Controllers
{
    [ApiController]
    [Route("api/library")]
    public class LibraryController : ControllerBase
    {
        private readonly ILibraryRepository _libRepo;
        public LibraryController(ILibraryRepository libRepo)
        {
            _libRepo = libRepo;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateLibrary create)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var library = create.toLibrary();
            await _libRepo.Create(library);

            return Ok(library.viewLibrary());
        }

        [HttpGet("getall")]
        public async Task<IActionResult> getAll()
        {
            var library = await _libRepo.GetAll();
            var librarys = library.Select(l => l.viewLibrary()).ToList();
            return Ok(librarys);
        }

        [HttpGet("get/{id:guid}")]
        public async Task<IActionResult> getById([FromRoute] Guid id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var library = await _libRepo.GetById(id);
            if (library == null) return StatusCode(404, "Library Not Found");

            return Ok(library.viewLibrary());
        }

        [HttpPatch("update/{id:guid}")]
        public async Task<IActionResult> update([FromRoute] Guid id, [FromBody] UpdateLibrary update)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var library = await _libRepo.Update(id, update);
            if (library == null) return StatusCode(404, "Library Not Found");

            return Ok(library.viewLibrary());
        }

        [HttpDelete("delete/{id:guid}")]
        public async Task<IActionResult> delete([FromRoute] Guid id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var library = await _libRepo.DeleteById(id);
            if (library == null) return StatusCode(404, "Library Not Found");

            return StatusCode(200, "Library successfully Deleted");
        }
    }
}
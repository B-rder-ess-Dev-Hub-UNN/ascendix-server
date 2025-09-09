using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Dto.CertificateDto;
using Ascendix_Backend.Interfaces;
using Ascendix_Backend.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Ascendix_Backend.Controllers
{
    [ApiController]
    [Route("api/v1/certificate")]
    public class CertificateController : ControllerBase
    {
        private readonly ICertificateRepository _certRepo;
        public CertificateController(ICertificateRepository certRepo)
        {
            _certRepo = certRepo;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateCertificate create)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var certificateModel = create.toCertificate();
            var certificate = await _certRepo.create(certificateModel);

            return Ok(certificate.fromCertificate());
        }

        [HttpGet("getall")]
        public async Task<IActionResult> getAll()
        {
            var certificate = await _certRepo.getAll();
            var certificates = certificate.Select(c => c.fromCertificate()).ToList();
            return Ok(certificates);
        }

        [HttpGet("get/{id:guid}")]
        public async Task<IActionResult> getById([FromRoute] Guid id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var certificate = await _certRepo.getById(id);
            if (certificate == null) return StatusCode(404, "Certificate not Found");

            return Ok(certificate.fromCertificate());
        }

        [HttpPatch("update/{id:guid}")]
        public async Task<IActionResult> update([FromRoute] Guid id, [FromBody] UpdateCertificate update)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var certificate = await _certRepo.update(id, update);
            if (certificate == null) return StatusCode(404, "Certificate Not Found");
            return Ok(certificate.fromCertificate());
        }

        [HttpDelete("delete/{id:guid}")]
        public async Task<IActionResult> delete([FromRoute] Guid id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var certificate = await _certRepo.delete(id);
            if (certificate == null) return StatusCode(404, "Certificate Not Found");

            return StatusCode(200, "Certificate Deleted Successfully");
        }
    }
}
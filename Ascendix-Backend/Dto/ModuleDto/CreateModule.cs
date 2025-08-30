using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ascendix_Backend.Dto.ModuleDto
{
    public class CreateModule
    {
        public required Guid courseId { get; set; }
        public required string title { get; set; } = string.Empty;
        public required string courseContent { get; set; } = string.Empty;
        
    }
}
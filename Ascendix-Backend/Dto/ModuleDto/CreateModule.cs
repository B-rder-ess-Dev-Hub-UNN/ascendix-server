using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ascendix_Backend.Dto.ModuleDto
{
    public class CreateModule
    {
        public Guid courseId { get; set; }
        public string title { get; set; } = string.Empty;
        public string courseContent { get; set; } = string.Empty;
        
    }
}
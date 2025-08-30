using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ascendix_Backend.Dto.ModuleDto
{
    public class UpdateModule
    {
        public Guid? courseId { get; set; }
        public string? title { get; set; }
        public string? courseContent { get; set; }
        
    }
}
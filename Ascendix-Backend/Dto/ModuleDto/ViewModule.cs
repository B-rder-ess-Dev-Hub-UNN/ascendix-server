using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ascendix_Backend.Dto.ModuleDto
{
    public class ViewModule
    {
        public Guid moduleId { get; set; }
        public Guid courseId { get; set; }
        public string title { get; set; } = string.Empty;
        public string courseContent { get; set; } = string.Empty;
        
    }
}
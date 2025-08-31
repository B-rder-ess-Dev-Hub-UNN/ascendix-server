using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ascendix_Backend.Dto.ModuleQuizDto
{
    public class UpdateModuleQuiz
    {
        public Guid? moduleId { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }

    }
}
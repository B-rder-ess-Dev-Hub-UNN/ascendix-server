using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ascendix_Backend.Dto.ModuleQuizDto
{
    public class CreateModuleQuiz
    {
        public required Guid moduleId { get; set; }
        public required string title { get; set; }
        public required string description { get; set; }
    }
}
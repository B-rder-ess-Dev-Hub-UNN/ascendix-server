using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Dto.QuizQuestionDto;

namespace Ascendix_Backend.Dto.ModuleQuizDto
{
    public class ViewModuleQuiz
    {
        public Guid id { get; set; }
        public Guid moduleId { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
        public List<ViewQuizQuestion> questions {get; set; } = new List<ViewQuizQuestion>();
    }
}
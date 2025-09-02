using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Models;

namespace Ascendix_Backend.Dto.QuizQuestionDto
{
    public class ViewQuizQuestion
    {
        public Guid id { get; set; }
        public Guid moduleQuizId { get; set; }
        public string? questionText { get; set; }
        public QuestionType questionType { get; set; }
    }
}
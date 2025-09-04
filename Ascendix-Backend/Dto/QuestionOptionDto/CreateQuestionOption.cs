using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ascendix_Backend.Dto.QuestionOptionDto
{
    public class CreateQuestionOption
    {
        public required Guid questionId { get; set; }
        public required string optionText { get; set; }
        public required bool isCorrect { get; set; }
    }
}
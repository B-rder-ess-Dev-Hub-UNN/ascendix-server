using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ascendix_Backend.Dto.QuestionOptionDto
{
    public class ViewQuestionOption
    {
        public Guid id { get; set; }
        public Guid questionId { get; set; }
        public string? optionText { get; set; }
        public bool isCorrect { get; set; }
    }
}
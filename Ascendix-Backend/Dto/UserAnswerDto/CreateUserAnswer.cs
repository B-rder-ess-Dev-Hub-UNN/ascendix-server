using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ascendix_Backend.Dto.UserAnswerDto
{
    public class CreateUserAnswer
    {
        public Guid questionId { get; set; }
        public Guid attemptId { get; set; }
        public Guid optionId { get; set; }
        public string? answerText { get; set; }
    }
}
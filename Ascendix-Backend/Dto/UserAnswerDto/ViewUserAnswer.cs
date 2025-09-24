using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ascendix_Backend.Dto.UserAnswerDto
{
    public class ViewUserAnswer
    {
        public Guid id { get; set; }
        public Guid quizQuestionId { get; set; }
        public Guid userQuizAttemptId { get; set; }
        public Guid questionOptionsId { get; set; }
        public string? answerText { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ascendix_Backend.Models
{
    public class QuizQuestions
    {
        public Guid id { get; set; }
        public Guid quizId { get; set; }
        public string? questionText { get; set; }
        public QuestionType questionType { get; set; }
    }

    public enum QuestionType
    {
        MullipleChoice,
        TrueFalse,
        Text
    }
}
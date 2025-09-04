using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ascendix_Backend.Models
{
    public class QuizQuestions
    {
        [Key]
        public Guid id { get; set; }
        public Guid quizId { get; set; }
        public string? questionText { get; set; }
        public QuestionType questionType { get; set; }

        public ModuleQuiz? moduleQuiz { get; set; }
        public ICollection<QuestionOptions> options { get; set; } = new List<QuestionOptions>();
        public ICollection<UserAnswer> answers { get; set;} = new List<UserAnswer>();
    }

    public enum QuestionType
    {
        MullipleChoice,
        TrueFalse,
        Text
    }
}
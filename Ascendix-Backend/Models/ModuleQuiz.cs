using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ascendix_Backend.Models
{
    public class ModuleQuiz
    {
        public Guid Id { get; set; }
        public Guid moduleId { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }

        public Module? module { get; set; }
        public ICollection<UserQuizAttempt> attempts { get; set; } = new List<UserQuizAttempt>();
        public ICollection<QuizQuestions> quizQuestions { get; set; } = new List<QuizQuestions>();
    }
}
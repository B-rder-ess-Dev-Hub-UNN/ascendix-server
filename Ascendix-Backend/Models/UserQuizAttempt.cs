using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ascendix_Backend.Models
{
    public class UserQuizAttempt
    {
        public Guid id { get; set; }
        public Guid moduleQuizId { get; set; }
        public string? userId { get; set; }
        public decimal score { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }

        public ModuleQuiz? moduleQuiz { get; set; }
        public User? user { get; set; }
        public ICollection<UserAnswer> userAnswers{ get; set; } = new List<UserAnswer>();
    }
}
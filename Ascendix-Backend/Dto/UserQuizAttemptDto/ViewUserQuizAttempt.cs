using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ascendix_Backend.Dto.UserQuizAttemptDto
{
    public class ViewUserQuizAttempt
    {
        public Guid id { get; set; }
        public Guid moduleQuizId { get; set; }
        public string? userId { get; set; }
        public int score { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}
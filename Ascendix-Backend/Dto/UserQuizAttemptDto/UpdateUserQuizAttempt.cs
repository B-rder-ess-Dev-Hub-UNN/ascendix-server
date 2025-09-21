using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ascendix_Backend.Dto.UserQuizAttemptDto
{
    public class UpdateUserQuizAttempt
    {
        public Guid? moduleQuizId { get; set; }
        public int? score { get; set; }
    }
}
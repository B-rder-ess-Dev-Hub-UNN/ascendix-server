using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ascendix_Backend.Models
{
    public class UserAnswer
    {
        public Guid id { get; set; }
        public Guid questionId { get; set; }
        public Guid attemptId { get; set; }
        public Guid optionId { get; set; }
        public string? answerText { get; set; }
    }
}
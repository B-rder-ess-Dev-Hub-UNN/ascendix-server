using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ascendix_Backend.Models
{
    public class QuestionOptions
    {
        public Guid id { get; set; }
        public Guid questionId { get; set; }
        public string? optionText { get; set; }
        public bool isCorrect { get; set; }
    }
}
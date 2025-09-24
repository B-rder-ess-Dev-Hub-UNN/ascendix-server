using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ascendix_Backend.Dto.UserAnswerDto
{
    public class UpdateUserAnswer
    {
        public Guid? questionOptionsId { get; set; }
        public string? answerText { get; set; }
    }
}
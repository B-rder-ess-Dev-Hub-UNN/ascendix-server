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
    }
}
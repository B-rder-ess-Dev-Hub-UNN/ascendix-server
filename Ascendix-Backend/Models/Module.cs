using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ascendix_Backend.Models
{
    public class Module
    {
        [Key]
        public Guid moduleId { get; set; }
        public Guid courseId { get; set; }
        public string title { get; set; } = string.Empty;
        public string courseContent { get; set; } = string.Empty;
        
        public Course? course {get; set; }
    }
}
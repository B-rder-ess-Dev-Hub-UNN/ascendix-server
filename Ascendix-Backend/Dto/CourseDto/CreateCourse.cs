using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ascendix_Backend.Dto.CourseDto
{
    public class CreateCourse
    {
        public Guid libraryId { get; set; }
        public string title { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public decimal rewardAmount { get; set; }
        public bool isActive { get; set; }
    }
}
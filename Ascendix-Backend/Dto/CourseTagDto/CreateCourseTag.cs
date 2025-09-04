using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ascendix_Backend.Dto.CourseTagDto
{
    public class CreateCourseTag
    {
        public required Guid tagId { get; set; }
        public required Guid courseId { get; set; }
    }
}
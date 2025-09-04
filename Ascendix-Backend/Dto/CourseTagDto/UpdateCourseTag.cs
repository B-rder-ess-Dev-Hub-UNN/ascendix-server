using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ascendix_Backend.Dto.CourseTagDto
{
    public class UpdateCourseTag
    {
        public Guid? tagId { get; set; }
        public Guid? courseId { get; set; }
    }
}
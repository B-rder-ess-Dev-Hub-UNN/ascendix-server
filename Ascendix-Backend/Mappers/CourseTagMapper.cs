using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Dto.CourseTagDto;
using Ascendix_Backend.Models;

namespace Ascendix_Backend.Mappers
{
    public static class CourseTagMapper
    {
        public static CourseTag toCourseTag(this CreateCourseTag create)
        {
            return new CourseTag
            {
                tagId = create.tagId,
                courseId = create.courseId,
            };
        }

        public static ViewCourseTag fromCourseTag(this CourseTag tag)
        {
            return new ViewCourseTag
            {
                id = tag.id,
                tagId = tag.tagId,
                courseId = tag.courseId,
            };
        }
    }
}
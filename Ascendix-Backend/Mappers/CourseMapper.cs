using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Dto.CourseDto;
using Ascendix_Backend.Models;

namespace Ascendix_Backend.Mappers
{
    public static class CourseMapper
    {
        public static Course toCourse(this CreateCourse create)
        {
            return new Course
            {
                libraryId = create.libraryId,
                title = create.title,
                description = create.description,
                rewardAmount = create.rewardAmount,
                isActive = create.isActive,
            };
        }

        public static ViewCourse fromCourse(this Course course)
        {
            return new ViewCourse
            {
                title = course.title,
                description = course.description,
                rewardAmount = course.rewardAmount,
                isActive = course.isActive,
            };
        }
    }
}
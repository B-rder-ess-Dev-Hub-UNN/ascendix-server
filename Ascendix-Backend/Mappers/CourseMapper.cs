using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Dto.CourseDto;
using Ascendix_Backend.Dto.ModuleDto;
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
                tokenAllocation = create.tokenAllocation,
                createdAt = DateTime.UtcNow
            };
        }

        public static ViewCourse fromCourse(this Course course)
        {
            return new ViewCourse
            {
                title = course.title,
                description = course.description,
                tokenAllocation = course.tokenAllocation,
                modules = course.modules.Select(m => m.fromModule()).ToList(),
            };
        }
    }
}
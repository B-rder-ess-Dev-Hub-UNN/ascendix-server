using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Dto.CourseDto;
using Ascendix_Backend.Models;

namespace Ascendix_Backend.Interfaces
{
    public interface ICourseRepository
    {
        public Task<List<Course>> GetAll();
        public Task<Course?> GetById(Guid id);
        public Task<Course?> Create(Course course);
        public Task<Course?> Update(Guid id, UpdateCourse update);
        public Task<Course?> DeleteById(Guid id);
        public Task<List<Course>> GetCourseByLibrary(Guid id);
    }
}
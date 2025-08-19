using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Dto.CourseDto;
using Ascendix_Backend.Interfaces;
using Ascendix_Backend.Models;

namespace Ascendix_Backend.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        public Task<Course?> Create(Course course)
        {
            throw new NotImplementedException();
        }

        public Task<Course?> DeleteById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Course>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Course?> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Course?> Update(Guid id, UpdateCourse update)
        {
            throw new NotImplementedException();
        }
    }
}
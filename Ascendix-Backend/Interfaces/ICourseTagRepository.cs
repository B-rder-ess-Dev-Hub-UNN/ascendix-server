using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Dto.CourseTagDto;
using Ascendix_Backend.Models;

namespace Ascendix_Backend.Interfaces
{
    public interface ICourseTagRepository
    {
        public Task<List<CourseTag>> getAll();
        public Task<CourseTag?> getById(Guid id);
        public Task<CourseTag> create(CourseTag courseTag);
        public Task<CourseTag?> update(Guid id, UpdateCourseTag update);
        public Task<CourseTag?> delete(Guid id);
    }
}
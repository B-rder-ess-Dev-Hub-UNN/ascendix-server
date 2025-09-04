using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Data;
using Ascendix_Backend.Dto.CourseTagDto;
using Ascendix_Backend.Interfaces;
using Ascendix_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Ascendix_Backend.Repositories
{
    public class CourseTagRepository : ICourseTagRepository
    {
        private readonly AppDbContext _context;
        public CourseTagRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<CourseTag> create(CourseTag courseTag)
        {
            await _context.courseTags.AddAsync(courseTag);
            await _context.SaveChangesAsync();
            return courseTag;
        }

        public async Task<CourseTag?> delete(Guid id)
        {
            var courseTag = await getById(id);
            if (courseTag == null) return null;

            _context.courseTags.Remove(courseTag);
            await _context.SaveChangesAsync();

            return courseTag;
        }

        public async Task<List<CourseTag>> getAll()
        {
            return await _context.courseTags.ToListAsync();
        }

        public async Task<CourseTag?> getById(Guid id)
        {
            var courseTag = await _context.courseTags.FirstOrDefaultAsync(x => x.id == id);
            if (courseTag == null) return null;

            return courseTag;
        }

        public async Task<CourseTag?> update(Guid id, UpdateCourseTag update)
        {
            var courseTag = await getById(id);
            if (courseTag == null) return null;

            if (update.courseId.HasValue) courseTag.courseId = update.courseId.Value;
            if (update.tagId.HasValue) courseTag.tagId = update.tagId.Value;

            await _context.SaveChangesAsync();
            return courseTag;
        }
    }
}
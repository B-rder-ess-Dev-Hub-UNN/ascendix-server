using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Data;
using Ascendix_Backend.Dto.CourseDto;
using Ascendix_Backend.Interfaces;
using Ascendix_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Ascendix_Backend.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _context;
        public CourseRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Course?> Create(Course course)
        {
            await _context.course.AddAsync(course);
            await _context.SaveChangesAsync();
            return course;
        }

        public async Task<Course?> DeleteById(Guid id)
        {
            var course = await _context.course.FirstOrDefaultAsync(x => x.courseId == id);
            if (course == null) return null;

            _context.course.Remove(course);
            await _context.SaveChangesAsync();

            return course;
        }

        public async Task<List<Course>> GetAll()
        {
            return await _context.course.ToListAsync();
        }

        public async Task<Course?> GetById(Guid id)
        {
            var course = await _context.course.FirstOrDefaultAsync(x => x.courseId == id);
            if (course == null) return null;

            return course;
        }

        public async Task<List<Course>> GetCourseByLibrary(Guid id)
        {
            return await _context.course.Where(c => c.libraryId == id).ToListAsync();
        }

        public async Task<Course?> Update(Guid id, UpdateCourse update)
        {
            var course = await _context.course.FirstOrDefaultAsync(x => x.courseId == id);
            if (course == null) return null;

            if (!string.IsNullOrWhiteSpace(update.title)) course.title = update.title;
            if (!string.IsNullOrWhiteSpace(update.description)) course.description = update.description;
            if (update.tokenAllocation != default) course.tokenAllocation = update.tokenAllocation;  

            await _context.SaveChangesAsync();
            return course;
        }
    }
}
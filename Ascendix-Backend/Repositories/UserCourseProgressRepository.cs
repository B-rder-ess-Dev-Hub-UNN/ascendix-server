using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Interfaces;
using Ascendix_Backend.Models;
using Microsoft.EntityFrameworkCore;
using Ascendix_Backend.Data;
using Ascendix_Backend.Dto.UserCourseProgressDto;

namespace Ascendix_Backend.Repositories
{
    public class UserCourseProgressRepository : IUserCourseProgressRepository
    {
        private readonly AppDbContext _context;
        public UserCourseProgressRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<UserCourseProgress>> getAll(string userId)
        {
            return await _context.userCourseProgresses.Where(x => x.userId == userId).ToListAsync();
        }
        public async Task<UserCourseProgress?> GetbyId(Guid id)
        {
            var userCourseProgress = await _context.userCourseProgresses.FirstOrDefaultAsync(x => x.progressId == id);
            if (userCourseProgress == null) return null;
            return userCourseProgress;
        }
        public async Task<UserCourseProgress> create(string id, UserCourseProgress create)
        {
            var exists = await _context.userCourseProgresses
                .AnyAsync(uq => uq.userId == id && uq.progressId == create.courseId);

            if (exists)
            {
                throw new InvalidOperationException("User already has this course.");
            }
            create.status = Status.OnGoing;
            await _context.userCourseProgresses.AddAsync(create);
            await _context.SaveChangesAsync();
            return create;
        }
        public async Task<UserCourseProgress?> update(Guid id, string userId, UpdateUserCourseProgress update)
        {
            var progress = await GetbyId(id);
            if (progress == null || progress.userId != userId) return null;

            if (update.courseId.HasValue) progress.courseId = update.courseId.Value;
            if (update.progressPercent.HasValue) progress.progressPercent = update.progressPercent.Value;
            if (update.status.HasValue) progress.status = update.status.Value;

            await _context.SaveChangesAsync();
            return progress;
        }
        public async Task<UserCourseProgress?> delete(Guid id, string userId)
        {
            var progress = await GetbyId(id);
            if (progress == null || progress.userId != userId) return null;

            _context.userCourseProgresses.Remove(progress);
            await _context.SaveChangesAsync();
            return progress;
        }
    }
}
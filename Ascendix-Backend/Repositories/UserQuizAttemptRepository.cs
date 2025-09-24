using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Data;
using Ascendix_Backend.Dto.UserQuizAttemptDto;
using Ascendix_Backend.Interfaces;
using Ascendix_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Ascendix_Backend.Repositories
{
    public class UserQuizAttemptRepository : IUserQuizAttemptRepository
    {
        private readonly AppDbContext _context;
        public UserQuizAttemptRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<UserQuizAttempt> create(UserQuizAttempt attempt)
        {
            var exists = await _context.userQuizAttempts
                .AnyAsync(x => x.userId == attempt.userId && x.moduleQuizId == attempt.moduleQuizId);

            if (exists)
            {
                throw new InvalidOperationException("User has already attempted this Quiz.");
            }

            await _context.userQuizAttempts.AddAsync(attempt);
            await _context.SaveChangesAsync();

            return attempt;
        }

        public async Task<UserQuizAttempt?> delete(Guid id, string userId)
        {
            var attempt = await getById(id, userId);
            if (attempt == null) return null;

            _context.userQuizAttempts.Remove(attempt);
            return attempt;
        }

        public async Task<List<UserQuizAttempt>> getAll(string userId)
        {
            return await _context.userQuizAttempts.Where(x => x.userId == userId).ToListAsync();
        }

        public async Task<UserQuizAttempt?> getById(Guid id, string userId)
        {
            var attempt = await _context.userQuizAttempts.FirstOrDefaultAsync(x => x.id == id && x.userId == userId);
            if (attempt == null) return null;

            return attempt;
        }

        public async Task<UserQuizAttempt?> getByIdAlone(Guid id)
        {
            var attempt = await _context.userQuizAttempts.FirstOrDefaultAsync(x => x.id == id);
            if (attempt == null) return null;

            return attempt;
        }

        public async Task<UserQuizAttempt?> update(Guid id, string userId, UpdateUserQuizAttempt update)
        {
            var attempt = await getById(id, userId);
            if (attempt == null) return null;

            if (update.moduleQuizId.HasValue) attempt.moduleQuizId = update.moduleQuizId.Value;
            if (update.score.HasValue) attempt.score = update.score.Value;

            await _context.SaveChangesAsync();
            return attempt;
        }
    }
}
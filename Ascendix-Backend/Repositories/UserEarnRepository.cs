using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Data;
using Ascendix_Backend.Dto.UserEarnDto;
using Ascendix_Backend.Interfaces;
using Ascendix_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Ascendix_Backend.Repositories
{
    public class UserEarnRepository : IUserEarnRepository
    {
        private readonly AppDbContext _context;
        public UserEarnRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<UserEarn?> create(UserEarn userEarn)
        {
            await _context.userEarns.AddAsync(userEarn);
            await _context.SaveChangesAsync();
            return userEarn;
        }

        public async Task<UserEarn?> deleteById(Guid id, string userId)
        {
            var earn = await getById(id, userId);
            if (earn == null) return null;

            _context.userEarns.Remove(earn);
            await _context.SaveChangesAsync();

            return earn;
        }

        public async Task<List<UserEarn>> getAll(string userId)
        {
            return await _context.userEarns.Where(x => x.userId == userId).ToListAsync();
        }

        public async Task<UserEarn?> getById(Guid id, string userId)
        {
            var earn = await _context.userEarns.FirstOrDefaultAsync(x => x.id == id && x.userId == userId);
            if (earn == null) return null;

            return earn;
        }

        public async Task<UserEarn?> update(Guid id, string userId, UpdateUserEarn update)
        {
            var earn = await getById(id, userId);
            if (earn == null) return null;

            if (update.amountEarned.HasValue) earn.amountEarned = update.amountEarned.Value;
            if (update.earnedAt.HasValue) earn.earnedAt = update.earnedAt.Value;

            await _context.SaveChangesAsync();
            return earn;
        }
    }
}
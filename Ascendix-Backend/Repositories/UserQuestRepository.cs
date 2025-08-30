using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Data;
using Ascendix_Backend.Interfaces;
using Ascendix_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Ascendix_Backend.Repositories
{
    public class UserQuestRepository : IUserQuestRepository
    {
        private readonly AppDbContext _context;
        public UserQuestRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<UserQuest?> Create(UserQuest userQuest)
        {
            await _context.userQuest.AddAsync(userQuest);
            await _context.SaveChangesAsync();
            return userQuest;
        }

        public async Task<UserQuest?> DeleteById(Guid id)
        {
            var userQuest = await _context.userQuest.FirstOrDefaultAsync(x => x.userQuestId == id);
            if (userQuest == null) return null;

            _context.userQuest.Remove(userQuest);
            await _context.SaveChangesAsync();
            return userQuest;
        }

        public async Task<List<UserQuest>> GetAll()
        {
            return await _context.userQuest.ToListAsync();
        }

        public async Task<UserQuest?> GetbyId(Guid id)
        {
            var userQuest = await _context.userQuest.FirstOrDefaultAsync(x => x.userQuestId == id);
            if (userQuest == null) return null;
            return userQuest;
        }

        public async Task<UserQuest?> UpdateStatus(Guid id, string status)
        {
            var userQuest = await _context.userQuest.FirstOrDefaultAsync(x => x.userQuestId == id);
            if (userQuest == null) return null;

            // if(!String.IsNullOrWhiteSpace(status)) userQuest.status = status.;
            return userQuest;

        }
    }
}
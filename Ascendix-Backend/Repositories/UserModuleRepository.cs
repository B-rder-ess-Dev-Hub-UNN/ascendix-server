using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Data;
using Ascendix_Backend.Dto.UserModuleDto;
using Ascendix_Backend.Interfaces;
using Ascendix_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Ascendix_Backend.Repositories
{
    public class UserModuleRepository : IUserModuleRepository
    {
        private readonly AppDbContext _context;
        public UserModuleRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<UserModule?> create(UserModule userModule)
        {
            var exists = await _context.userModules
                .AnyAsync(u => u.moduleId == userModule.moduleId && u.userId == userModule.userId);
            if (exists)
            {
                throw new InvalidOperationException("User already has this Module.");
            }

            await _context.userModules.AddAsync(userModule);
            await _context.SaveChangesAsync();
            return userModule;
        }

        public async Task<UserModule?> delete(Guid id, string userId)
        {
            var userModule = await getById(id, userId);
            if (userModule == null) return null;

            _context.userModules.Remove(userModule);
            await _context.SaveChangesAsync();
            return userModule;
        }

        public async Task<List<UserModule>> getAll(string userId)
        {
            return await _context.userModules.Where(u => u.userId == userId).ToListAsync();
        }

        public async Task<UserModule?> getById(Guid id, string userId)
        {
            var userModule = await _context.userModules.FirstOrDefaultAsync(u => u.id == id && u.userId == userId);
            if (userModule == null) return null;

            return userModule;
        }

        public async Task<UserModule?> update(Guid id, string userId, UpdateUserModule update)
        {
            var userModule = await getById(id, userId);
            if (userModule == null) return null;

            if (update.moduleId.HasValue) userModule.moduleId = update.moduleId.Value;
            if (update.status.HasValue) userModule.status = update.status.Value;
            if (update.progressPercent.HasValue) userModule.progressPercent = update.progressPercent.Value;

            await _context.SaveChangesAsync();
            return userModule;
        }
    }
}
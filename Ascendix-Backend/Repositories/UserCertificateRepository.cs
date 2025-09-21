using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Ascendix_Backend.Data;
using Ascendix_Backend.Dto.UserCertificateDto;
using Ascendix_Backend.Interfaces;
using Ascendix_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Ascendix_Backend.Repositories
{
    public class UserCertificateRepository : IUserCertificateRepository
    {
        private readonly AppDbContext _context;

        public UserCertificateRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<UserCertificate> create(UserCertificate create)
        {
            var exists = await _context.userCertificates
                    .AnyAsync(c => c.userId == create.userId && c.certificateId == create.certificateId);

            if (exists) throw new InvalidOperationException("User Already has this Certificate");

            await _context.userCertificates.AddAsync(create);
            await _context.SaveChangesAsync();
            return create;
        }

        public async Task<UserCertificate?> delete(Guid id, string userId)
        {
            var userCertificate = await getById(id, userId);
            if (userCertificate == null) return null;

            _context.Remove(userCertificate);
            await _context.SaveChangesAsync();
            return userCertificate;
        }

        public async Task<List<UserCertificate>> getAll(string userId)
        {
            return await _context.userCertificates.Where(c => c.userId == userId).ToListAsync();
        }

        public async Task<UserCertificate?> getById(Guid id, string userId)
        {
            var userCertificate = await _context.userCertificates.FirstOrDefaultAsync(c => c.id == id && c.userId == userId);
            if (userCertificate == null) return null;
            return userCertificate;
        }

        public async Task<UserCertificate?> update(Guid id, string userId, UpdateUserCertificate update)
        {
            var userCertificate = await getById(id, userId);
            if (userCertificate == null) return null;

            if (update.certificateId.HasValue) userCertificate.certificateId = update.certificateId.Value;
            if (update.issuedAt.HasValue) userCertificate.issuedAt = update.issuedAt.Value;

            await _context.SaveChangesAsync();
            return userCertificate;
        }
    }
}
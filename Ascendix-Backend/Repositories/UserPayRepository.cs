using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Data;
using Ascendix_Backend.Dto.UserPayDto;
using Ascendix_Backend.Interfaces;
using Ascendix_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Ascendix_Backend.Repositories
{
    public class UserPayRepository : IUserPayRepository
    {
        private readonly AppDbContext _context;
        public UserPayRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<UserPay> create(UserPay userPay)
        {
            await _context.userPays.AddAsync(userPay);
            await _context.SaveChangesAsync();
            return userPay;
        }

        public async Task<UserPay?> delete(Guid id, string userId)
        {
            var pay = await getById(id, userId);
            if (pay == null) return null;

            _context.Remove(pay);
            await _context.SaveChangesAsync();

            return pay;
        }

        public async Task<List<UserPay>> getAll(string userId)
        {
            return await _context.userPays.Where(c => c.userId == c.userId).ToListAsync();

        }

        public async Task<UserPay?> getById(Guid id, string userId)
        {
            var pay = await _context.userPays.FirstOrDefaultAsync(c => c.id == id && c.userId == userId);
            if (pay == null) return null;
            return pay;
        }

        public async Task<UserPay?> updateById(Guid id, string userId, UpdateUserPay update)
        {
            var pay = await getById(id, userId);
            if (pay == null) return null;

            if (update.amountPayed.HasValue) pay.amountPayed = update.amountPayed.Value;
            if (update.paymentStatus.HasValue)
            {
                pay.paymentStatus = update.paymentStatus.Value;
                if (pay.paymentStatus == PaymentStatus.Successfull) pay.datePayed = DateTime.UtcNow;
            }

            await _context.SaveChangesAsync();
            return pay;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Dto.UserPayDto;
using Ascendix_Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ascendix_Backend.Interfaces
{
    public interface IUserPayRepository
    {
        public Task<List<UserPay>> getAll(string userId);
        public Task<UserPay?> getById(Guid id, string userId);
        public Task<UserPay?> updateById(Guid id, string userId, UpdateUserPay update);
        public Task<UserPay> create(UserPay userPay);
        public Task<UserPay?> delete(Guid id, string userId);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Dto.UserEarnDto;
using Ascendix_Backend.Models;

namespace Ascendix_Backend.Interfaces
{
    public interface IUserEarnRepository
    {
        public Task<List<UserEarn>> getAll(string userId);
        public Task<UserEarn?> getById(Guid id, string userId);
        public Task<UserEarn?> create(UserEarn userEarn);
        public Task<UserEarn?> update(Guid id, string userId, UpdateUserEarn update);
        public Task<UserEarn?> deleteById(Guid id, string userId);
    }
}
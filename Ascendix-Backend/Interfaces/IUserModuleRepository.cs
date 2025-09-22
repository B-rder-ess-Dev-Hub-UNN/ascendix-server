using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Dto.UserModuleDto;
using Ascendix_Backend.Models;

namespace Ascendix_Backend.Interfaces
{
    public interface IUserModuleRepository
    {
        public Task<List<UserModule>> getAll(string userId);
        public Task<UserModule?> getById(Guid id, string userId);
        public Task<UserModule?> create(UserModule userModule);
        public Task<UserModule?> update(Guid id, string userId, UpdateUserModule update);
        public Task<UserModule?> delete(Guid id, string userId);
    }
}
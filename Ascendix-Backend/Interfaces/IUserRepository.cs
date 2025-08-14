using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Dto.UserDto;
using Ascendix_Backend.Models;

namespace Ascendix_Backend.Interfaces
{
    public interface IUserRepository
    {
        public Task<(User? User, string? ErrorMessage)> createUser(string email, string password);
        public Task<(User? User, string? ErrorMessage)> loginUser(string email, string password);
        public Task<string?> token(string userId);
    }
}
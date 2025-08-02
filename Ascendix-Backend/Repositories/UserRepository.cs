using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Data;
using Ascendix_Backend.Dto.UserDto;
using Ascendix_Backend.Interfaces;

namespace Ascendix_Backend.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;   
        }
        public Task createAccounnt(LoginUser login)
        {
            throw new NotImplementedException();
        }
    }
}
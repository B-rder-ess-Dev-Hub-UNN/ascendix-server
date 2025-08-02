using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Dto.UserDto;

namespace Ascendix_Backend.Interfaces
{
    public interface IUserRepository
    {
        public Task createAccounnt(LoginUser login);
    }
}
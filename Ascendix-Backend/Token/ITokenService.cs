using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Models;

namespace LinternBackend.Token
{
    public interface ITokenService
    {
        string CreateToken(User user, IList<string> userRoles);
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ascendix_Backend.Dto.UserDto
{
    public class LoginUser
    {
        [Required]
        [EmailAddress]
        public required string email { get; set; }

        [Required]
        public required string? password { get; set;}
    }
}
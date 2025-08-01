using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ascendix_Backend.Dto.UserDto
{
    public class RegisterUser
    {
        [Required]
        [EmailAddress]
        public string email { get; set; } = "";
        [Required]
        public string? password { get; set; }
    }
}
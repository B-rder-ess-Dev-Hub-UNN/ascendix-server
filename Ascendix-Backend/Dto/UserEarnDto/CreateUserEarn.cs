using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ascendix_Backend.Dto.UserEarnDto
{
    public class CreateUserEarn
    {
        public decimal amountEarned { get; set; }
        public DateTime earnedAt { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ascendix_Backend.Dto.UserEarnDto
{
    public class UpdateUserEarn
    {
        public decimal? amountEarned { get; set; }
        public DateTime? earnedAt { get; set; }
    }
}
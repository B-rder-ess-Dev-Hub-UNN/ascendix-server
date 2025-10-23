using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Dto.UserEarnDto;
using Ascendix_Backend.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Ascendix_Backend.Mappers
{
    public static class UserEarnMapper
    {
        public static UserEarn toUserEarn(this CreateUserEarn create)
        {
            return new UserEarn
            {
                amountEarned = create.amountEarned,
                earnedAt = DateTime.UtcNow
            };
        }
        public static ViewUserEarn fromUserEarn(this UserEarn earn)
        {
                return new ViewUserEarn
                {
                    id = earn.id,
                    userId = earn.userId,
                    amountEarned = earn.amountEarned,
                    earnedAt = earn.earnedAt,
                };
        }
    }

}
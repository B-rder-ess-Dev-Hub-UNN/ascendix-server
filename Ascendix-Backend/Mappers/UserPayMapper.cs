using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Dto.UserPayDto;
using Ascendix_Backend.Models;

namespace Ascendix_Backend.Mappers
{
    public static class UserPayMapper
    {
        public static UserPay toUserPay(this CreateUserPay create)
        {
            return new UserPay
            {
                amountPayed = create.amountPayed,
                paymentStatus = create.paymentStatus,
                datePayed = DateTime.UtcNow
            };
        }
        public static ViewUserPay fromUserPay(this UserPay pay)
        {
            return new ViewUserPay
            {
                id = pay.id,
                userId = pay.userId,
                amountPayed = pay.amountPayed,
                paymentStatus = pay.paymentStatus,
                datePayed = pay.datePayed
            };
        }
    }
}
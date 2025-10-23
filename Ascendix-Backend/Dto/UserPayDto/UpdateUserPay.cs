using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Models;

namespace Ascendix_Backend.Dto.UserPayDto
{
    public class UpdateUserPay
    {
        public decimal? amountPayed { get; set; }
        public PaymentStatus? paymentStatus { get; set; } 
    }
}
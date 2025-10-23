using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Models;

namespace Ascendix_Backend.Dto.UserPayDto
{
    public class ViewUserPay
    {
        public Guid id { get; set; }
        public string? userId { get; set; }
        public decimal amountPayed { get; set; }
        public PaymentStatus paymentStatus { get; set; } 
        public DateTime datePayed { get; set; }
    }
}
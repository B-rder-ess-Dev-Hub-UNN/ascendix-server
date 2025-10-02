using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ascendix_Backend.Models
{
    public class UserPay
    {
        public Guid id { get; set; }
        public string? userId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal amountPayed { get; set; }
        public PaymentStatus paymentStatus { get; set; } 
        public DateTime datePayed { get; set; }
    }

    public enum PaymentStatus
    {
        Pending,
        Successfull
    }
}
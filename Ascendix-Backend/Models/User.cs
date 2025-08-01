using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ascendix_Backend.Models
{
    public class User
    {
        public Guid userId { get; set; }
        public string walletAddress { get; set; } = string.Empty;
        public string userName { get; set; } = string.Empty;
        public decimal totalPoints { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}
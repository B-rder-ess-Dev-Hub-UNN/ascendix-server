using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ascendix_Backend.Models
{
    public class Certificate
    {
        public Guid certificateId { get; set; }
        public Guid userId { get; set; }
        public Guid courseId { get; set; }
        public string nftTokenId { get; set; } = string.Empty; 
        public DateTime issuedAt { get; set; }
    }
}
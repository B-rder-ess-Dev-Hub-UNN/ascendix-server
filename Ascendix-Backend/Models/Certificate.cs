using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ascendix_Backend.Models
{
    public class Certificate
    {
        [Key]
        public Guid certificateId { get; set; }
        public Guid userId { get; set; }
        public Guid courseId { get; set; }
        public string nftTokenId { get; set; } = string.Empty;
        public DateTime issuedAt { get; set; }

        public User? user { get; set; }
        public Course? course { get; set; }
    }
}
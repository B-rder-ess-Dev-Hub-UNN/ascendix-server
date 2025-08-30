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
        public Guid courseId { get; set; }
        public string metaDataUrl { get; set; } = string.Empty;

        public Course? course { get; set; }
        public ICollection<UserCertificate> userCertificates{ get; set; } = new List<UserCertificate>();
    }
}
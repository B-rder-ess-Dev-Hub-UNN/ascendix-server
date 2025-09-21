using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ascendix_Backend.Dto.UserCertificateDto
{
    public class ViewUserCertificate
    {
        public Guid id { get; set; }
        public Guid certificateId { get; set; }
        public string? userId { get; set; }
        public DateTime issuedAt { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ascendix_Backend.Dto.UserCertificateDto
{
    public class UpdateUserCertificate
    {
        public Guid? certificateId { get; set; }
        public DateTime? issuedAt { get; set; }
    }
}
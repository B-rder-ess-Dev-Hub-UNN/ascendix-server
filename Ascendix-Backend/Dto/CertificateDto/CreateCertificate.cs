using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ascendix_Backend.Dto.CertificateDto
{
    public class CreateCertificate
    {
        public Guid userId { get; set; }
        public Guid courseId { get; set; }
        public string nftTokenId { get; set; } = string.Empty;
    }
}
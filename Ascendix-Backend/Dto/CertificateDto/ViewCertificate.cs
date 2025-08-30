using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ascendix_Backend.Dto.CertificateDto
{
    public class ViewCertificate
    {
        public Guid courseId { get; set; }
        public string metaDataUrl { get; set; } = string.Empty;
    }
}
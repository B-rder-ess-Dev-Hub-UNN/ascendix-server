using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Dto.CertificateDto;
using Ascendix_Backend.Models;

namespace Ascendix_Backend.Mappers
{
    public static class CertificateMapper
    {
        public static Certificate toCertificate(this CreateCertificate create)
        {
            return new Certificate
            {
                courseId = create.courseId,
                metaDataUrl = create.metaDataUrl
            };
        }

        public static ViewCertificate fromCertificate(this Certificate certificate)
        {
            return new ViewCertificate
            {
                courseId = certificate.courseId,
                metaDataUrl = certificate.metaDataUrl
            };
        }
    }
}
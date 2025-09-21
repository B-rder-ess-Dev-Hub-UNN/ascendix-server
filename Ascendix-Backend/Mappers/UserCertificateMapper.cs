using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Dto.UserAnswerDto;
using Ascendix_Backend.Dto.UserCertificateDto;
using Ascendix_Backend.Models;
namespace Ascendix_Backend.Mappers
{
    public static class UserCertificateMapper
    {
        public static UserCertificate toUserCertificate(this CreateUserCertificate create)
        {
            return new UserCertificate
            {
                certificateId = create.certificateId,
                issuedAt = DateTime.UtcNow
            };
        }

        public static ViewUserCertificate fromUserCertificate(this UserCertificate certificate)
        {
            return new ViewUserCertificate
            {
                id = certificate.id,
                certificateId = certificate.certificateId,
                userId = certificate.userId,
                issuedAt = certificate.issuedAt
            };
        }
    }
}
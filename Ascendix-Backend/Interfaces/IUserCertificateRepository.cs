using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Dto.UserCertificateDto;
using Ascendix_Backend.Models;

namespace Ascendix_Backend.Interfaces
{
    public interface IUserCertificateRepository
    {
        public Task<List<UserCertificate>> getAll(string userId);
        public Task<UserCertificate?> getById(Guid id, string userId);
        public Task<UserCertificate> create(UserCertificate create);
        public Task<UserCertificate?> update(Guid id, string userId, UpdateUserCertificate update);
        public Task<UserCertificate?> delete(Guid id, string userId);
    }
}
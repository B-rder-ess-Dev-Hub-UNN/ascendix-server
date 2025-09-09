using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Dto.CertificateDto;
using Ascendix_Backend.Models;

namespace Ascendix_Backend.Interfaces
{
    public interface ICertificateRepository
    {
        public Task<List<Certificate>> getAll();
        public Task<Certificate?> getById(Guid id);
        public Task<Certificate> create(Certificate certificate);
        public Task<Certificate?> update(Guid id, UpdateCertificate update);
        public Task<Certificate?> delete(Guid id);
    }
}
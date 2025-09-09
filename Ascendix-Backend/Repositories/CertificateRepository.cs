using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Data;
using Ascendix_Backend.Dto.CertificateDto;
using Ascendix_Backend.Interfaces;
using Ascendix_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Ascendix_Backend.Repositories
{
    public class CertificateRepository : ICertificateRepository
    {
        private readonly AppDbContext _context;
        
        public CertificateRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Certificate> create(Certificate certificate)
        {
            await _context.certificates.AddAsync(certificate);
            await _context.SaveChangesAsync();
            return certificate;
        }

        public async Task<Certificate?> delete(Guid id)
        {
            var certificate = await getById(id);
            if (certificate == null) return null;

            _context.certificates.Remove(certificate);
            await _context.SaveChangesAsync();

            return certificate;
        }

        public async Task<List<Certificate>> getAll()
        {
            return await _context.certificates.ToListAsync();
            
        }

        public async Task<Certificate?> getById(Guid id)
        {
            var certificate = await _context.certificates.FirstOrDefaultAsync(x => x.certificateId == id);
            if (certificate == null) return null;
            return certificate;
        }

        public async Task<Certificate?> update(Guid id, UpdateCertificate update)
        {
            var certificate = await getById(id);
            if (certificate == null) return null;

            if (update.courseId.HasValue) certificate.courseId = update.courseId.Value;
            if (!string.IsNullOrWhiteSpace(update.metaDataUrl)) certificate.metaDataUrl = update.metaDataUrl;

            await _context.SaveChangesAsync();
            return certificate;
        }
    }
}
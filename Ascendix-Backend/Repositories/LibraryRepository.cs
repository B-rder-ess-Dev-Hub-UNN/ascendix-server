using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Data;
using Ascendix_Backend.Dto.LibraryDto;
using Ascendix_Backend.Interfaces;
using Ascendix_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Ascendix_Backend.Repositories
{
    public class LibraryRepository : ILibraryRepository
    {
        private readonly AppDbContext _context;

        public LibraryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Library?> Create(Library library)
        {
            await _context.library.AddAsync(library);
            await _context.SaveChangesAsync();
            return library;
        }

        public async Task<Library?> DeleteById(Guid id)
        {
            var library = await _context.library.FirstOrDefaultAsync(x => x.libraryId == id);
            if (library == null) return null;

            _context.library.Remove(library);
            await _context.SaveChangesAsync();
            return library;
        }

        public async Task<List<Library>> GetAll()
        {
            return await _context.library.ToListAsync();
        }

        public async Task<Library?> GetById(Guid id)
        {
            var library = await _context.library.FirstOrDefaultAsync(x => x.libraryId == id);
            if (library == null) return null;

            return library;
        }

        public async Task<Library?> Update(Guid id, ViewLibrary update)
        {
            var library = await _context.library.FirstOrDefaultAsync(x => x.libraryId == id);
            if (library == null) return null;

            if (string.IsNullOrWhiteSpace(update.libraryName)) library.libraryName = update.libraryName;
            await _context.SaveChangesAsync();

            return library;
        }
    }
}
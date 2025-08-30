using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Dto.LibraryDto;
using Ascendix_Backend.Models;

namespace Ascendix_Backend.Interfaces
{
    public interface ILibraryRepository
    {
        public Task<List<Library>> GetAll();
        public Task<Library?> GetById(Guid id);
        public Task<Library?> Create(Library library);
        public Task<Library?> Update(Guid id, UpdateLibrary update);
        public Task<Library?> DeleteById(Guid id);
    }
}
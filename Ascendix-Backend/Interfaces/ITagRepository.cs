using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Dto.TagDto;
using Ascendix_Backend.Models;

namespace Ascendix_Backend.Interfaces
{
    public interface ITagRepository
    {
        public Task<List<Tag>> getAll();
        public Task<Tag?> getById(Guid id);
        public Task<Tag> create(Tag tag);
        public Task<Tag?> update(Guid id, UpdateTag update);
        public Task<Tag?> delete(Guid id);
    }
}
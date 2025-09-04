using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Data;
using Ascendix_Backend.Dto.TagDto;
using Ascendix_Backend.Interfaces;
using Ascendix_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Ascendix_Backend.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly AppDbContext _context;
        public TagRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Tag> create(Tag tag)
        {
            await _context.tags.AddAsync(tag);
            await _context.SaveChangesAsync();
            return tag;
        }

        public async Task<Tag?> delete(Guid id)
        {
            var tag = await getById(id);
            if (tag == null) return null;

            _context.tags.Remove(tag);
            await _context.SaveChangesAsync();

            return tag;
        }

        public async Task<List<Tag>> getAll()
        {
            return await _context.tags.Include(c => c.courseTags).ToListAsync();
            
        }

        public async Task<Tag?> getById(Guid id)
        {
            var tag = await _context.tags.Include(c => c.courseTags).FirstOrDefaultAsync(x => x.id == id);
            if (tag == null) return null;

            return tag;
        }

        public async Task<Tag?> update(Guid id, UpdateTag update)
        {
            var tag = await getById(id);
            if (tag == null) return null;

            if (!string.IsNullOrWhiteSpace(update.name)) tag.name = update.name;
            if (!string.IsNullOrWhiteSpace(update.slug)) tag.slug = update.slug;

            await _context.SaveChangesAsync();
            return tag;
        }
    }
}
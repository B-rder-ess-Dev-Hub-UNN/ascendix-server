using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Data;
using Ascendix_Backend.Dto.ModuleDto;
using Ascendix_Backend.Interfaces;
using Ascendix_Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Ascendix_Backend.Repositories
{
    public class ModuleRepository : IModuleRepository
    {
        private readonly AppDbContext _context;
        public ModuleRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Module> create(Module module)
        {
            await _context.modules.AddAsync(module);
            await _context.SaveChangesAsync();
            return module;
        }

        public async Task<Module?> deleteById(Guid id)
        {
            var module = await getById(id);
            if (module == null) return null;

            _context.modules.Remove(module);
            await _context.SaveChangesAsync();
            return module;
        }

        public async Task<List<Module>> getAll()
        {
            return await _context.modules.ToListAsync();
        }

        public async Task<Module?> getById(Guid id)
        {
            var module = await _context.modules.FirstOrDefaultAsync(c => c.moduleId == id);
            if (module == null) return null;

            return module;
        }

        public async Task<Module?> update(Guid id, UpdateModule update)
        {
            var module = await getById(id);
            if (module == null) return null;

            if (update.courseId.HasValue) module.courseId = update.courseId.Value;
            if (!string.IsNullOrWhiteSpace(update.title)) module.title = update.title;
            if (!string.IsNullOrWhiteSpace(update.courseContent)) module.courseContent = update.courseContent;

            await _context.SaveChangesAsync();
            return module;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Data;
using Ascendix_Backend.Dto.ModuleQuizDto;
using Ascendix_Backend.Interfaces;
using Ascendix_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Ascendix_Backend.Repositories
{
    public class ModuleQuizRepository : IModuleQuizRepository
    {
        private readonly AppDbContext _context;
        public ModuleQuizRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ModuleQuiz> create(ModuleQuiz create)
        {
            await _context.moduleQuizzes.AddAsync(create);
            await _context.SaveChangesAsync();
            return create;
        }

        public async Task<ModuleQuiz?> deleteById(Guid id)
        {
            var quiz = await getById(id);
            if (quiz == null) return null;

            _context.moduleQuizzes.Remove(quiz);
            await _context.SaveChangesAsync();

            return quiz;
        }

        public async Task<List<ModuleQuiz>> getAll()
        {
            return await _context.moduleQuizzes.ToListAsync();
        }

        public async Task<ModuleQuiz?> getById(Guid id)
        {
            var quiz = await _context.moduleQuizzes.FirstOrDefaultAsync(c => c.id == id);
            if (quiz == null) return null;

            return quiz;
        }

        public async Task<ModuleQuiz?> update(Guid id, UpdateModuleQuiz update)
        {
            var quiz = await getById(id);
            if (quiz == null) return null;

            if (update.moduleId.HasValue) quiz.moduleId = update.moduleId.Value;
            if (!string.IsNullOrWhiteSpace(update.title)) quiz.title = update.title;
            if (!string.IsNullOrWhiteSpace(update.description)) quiz.description = update.description;

            await _context.SaveChangesAsync();
            return quiz;
        }
    }
}
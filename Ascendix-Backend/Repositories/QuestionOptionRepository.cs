using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Data;
using Ascendix_Backend.Dto.QuestionOptionDto;
using Ascendix_Backend.Interfaces;
using Ascendix_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Ascendix_Backend.Repositories
{
    public class QuestionOptionRepository : IQuestionOptionRepository
    {
        private readonly AppDbContext _context;
        public QuestionOptionRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<QuestionOptions> create(QuestionOptions options)
        {
            await _context.questionOptions.AddAsync(options);
            await _context.SaveChangesAsync();
            return options;
        }

        public async Task<QuestionOptions?> deleteById(Guid id)
        {
            var option = await getById(id);
            if (option == null) return null;

            _context.questionOptions.Remove(option);
            await _context.SaveChangesAsync();

            return option;
        }

        public async Task<List<QuestionOptions>> getAll()
        {
            return await _context.questionOptions.ToListAsync();
        }

        public async Task<QuestionOptions?> getById(Guid id)
        {
            var option = await _context.questionOptions.FirstOrDefaultAsync(x => x.id == id);
            if (option == null) return null;

            return option;
        }

        public async Task<QuestionOptions?> update(Guid id, UpdateQuestionOption update)
        {
            var option = await getById(id);
            if (option == null) return null;

            if (update.questionId.HasValue) option.questionId = update.questionId.Value;
            if (!string.IsNullOrWhiteSpace(update.optionText)) option.optionText = update.optionText;
            if (update.isCorrect.HasValue) option.isCorrect = update.isCorrect.Value;

            await _context.SaveChangesAsync();
            return option;
        }
    }
}
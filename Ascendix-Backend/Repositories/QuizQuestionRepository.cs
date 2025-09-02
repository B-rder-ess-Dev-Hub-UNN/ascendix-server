using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Data;
using Ascendix_Backend.Dto.QuizQuestionDto;
using Ascendix_Backend.Interfaces;
using Ascendix_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Ascendix_Backend.Repositories
{
    public class QuizQuestionRepository : IQuizQuestionRepository
    {
        private readonly AppDbContext _context;
        public QuizQuestionRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<QuizQuestions> create(QuizQuestions question)
        {
            await _context.quizQuestions.AddAsync(question);
            await _context.SaveChangesAsync();
            return question;
        }

        public async Task<QuizQuestions?> delete(Guid id)
        {
            var question = await getById(id);
            if (question == null) return null;
            
            _context.quizQuestions.Remove(question);
            await _context.SaveChangesAsync();
            return question;
        }

        public async Task<List<QuizQuestions>> getAll()
        {
            return await _context.quizQuestions.Include(c => c.options).ToListAsync();
        }

        public async Task<QuizQuestions?> getById(Guid id)
        {
            var question = await _context.quizQuestions.Include(o => o.options).FirstOrDefaultAsync(x => x.id == id);
            if (question == null) return null;
            return question;
        }

        public async Task<QuizQuestions?> update(Guid id, UpdateQuizQuestion update)
        {
            var question = await getById(id);
            if (question == null) return null;

            if (!string.IsNullOrWhiteSpace(update.questionText)) question.questionText = update.questionText;
            if (update.quizId.HasValue) question.quizId = update.quizId.Value;
            if (update.questionType.HasValue) question.questionType = update.questionType.Value;

            await _context.SaveChangesAsync();
            return question;
        }
    }
}
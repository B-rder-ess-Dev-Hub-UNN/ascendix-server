using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Data;
using Ascendix_Backend.Dto.UserAnswerDto;
using Ascendix_Backend.Dto.UserQuizAttemptDto;
using Ascendix_Backend.Interfaces;
using Ascendix_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Ascendix_Backend.Repositories
{
    public class UserAnswerRepository : IUserAnswerRepository
    {
        private readonly AppDbContext _context;
        private readonly IUserQuizAttemptRepository _attemptRepo;
        private readonly IQuizQuestionRepository _questionRepo;
        private readonly IQuestionOptionRepository _optionRepo;
        public UserAnswerRepository(
            AppDbContext context,
            IUserQuizAttemptRepository attemptRepo,
            IQuizQuestionRepository questionRepo,
            IQuestionOptionRepository optionRepo
            )
        {
            _context = context;
            _attemptRepo = attemptRepo;
            _questionRepo = questionRepo;
            _optionRepo = optionRepo;
        }

        
        public async Task<UserAnswer> create(UserAnswer answer)
        {
            var exists = await _context.userAnswers.AnyAsync(c =>
                c.userQuizAttemptId == answer.userQuizAttemptId
                && c.quizQuestionId == answer.quizQuestionId);

            if (exists) throw new InvalidOperationException("User has already answered thiis question in ths attempt");

            await _context.userAnswers.AddAsync(answer);
            await updateUserQuizAttempt(answer);
            await _context.SaveChangesAsync();

            return answer;
        }

        public async Task<UserAnswer?> delete(Guid id)
        {
            var answer = await getById(id);
            if (answer == null) return null;

            _context.userAnswers.Remove(answer);
            await _context.SaveChangesAsync();

            return answer;
        }

        public async Task<List<UserAnswer>> getAll(Guid attemptId)
        {
            return await _context.userAnswers.Where(c => c.userQuizAttemptId == attemptId).ToListAsync();
        }

        public async Task<UserAnswer?> getById(Guid id)
        {
            var answer = await _context.userAnswers.FirstOrDefaultAsync(c => c.id == id);
            if (answer == null) return null;

            return answer;
        }

        public async Task<UserAnswer?> update(Guid id, UpdateUserAnswer update)
        {
            var answer = await getById(id);
            if (answer == null) return null;

            if (update.questionOptionsId.HasValue) answer.questionOptionsId = update.questionOptionsId.Value;
            if (!string.IsNullOrWhiteSpace(update.answerText)) answer.answerText = update.answerText;

            await _context.SaveChangesAsync();
            return answer;
        }


/// <summary>
/// This function check if a question is correct then updates the attempt score field
/// it accepts the UserAnswer model and returns it too, if it return null then there might be some error
/// </summary>
/// <param name="answer"></param>
/// <returns></returns>
        public async Task<UserAnswer?> updateUserQuizAttempt(UserAnswer answer)
        {
            var question = await _questionRepo.getById(answer.quizQuestionId);
            if (question == null) return null;
            var score = question.questionScore;

            var option = await _optionRepo.getById(answer.questionOptionsId);
            if (option == null) return null;
            var correct = option.isCorrect;

            if (correct)
            {
                var attempt = await _attemptRepo.getByIdAlone(answer.userQuizAttemptId);
                var updateAttempt = new UpdateUserQuizAttempt
                {
                    score = score,
                };
#pragma warning disable CS8604 // Possible null reference argument.
                var update = await _attemptRepo.update(answer.userQuizAttemptId, attempt?.userId, updateAttempt);
#pragma warning restore CS8604 // Possible null reference argument.

                if (update == null) return null;
            }

            return answer;
        }
    }
}
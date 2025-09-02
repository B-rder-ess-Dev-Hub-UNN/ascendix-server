using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Dto.QuizQuestionDto;
using Ascendix_Backend.Models;

namespace Ascendix_Backend.Interfaces
{
    public interface IQuizQuestionRepository
    {
        public Task<List<QuizQuestions>> getAll();
        public Task<QuizQuestions?> getById(Guid id);
        public Task<QuizQuestions?> update(Guid id, UpdateQuizQuestion update);
        public Task<QuizQuestions> create(QuizQuestions quiz);
        public Task<QuizQuestions?> delete(Guid id);
    }

}
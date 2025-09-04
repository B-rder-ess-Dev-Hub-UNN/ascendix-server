using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Dto.QuestionOptionDto;
using Ascendix_Backend.Models;

namespace Ascendix_Backend.Interfaces
{
    public interface IQuestionOptionRepository
    {
        public Task<List<QuestionOptions>> getAll();
        public Task<QuestionOptions?> getById(Guid id);
        public Task<QuestionOptions> create(QuestionOptions options);
        public Task<QuestionOptions?> update(Guid id, UpdateQuestionOption update);
        public Task<QuestionOptions?> deleteById(Guid id);
    }
}
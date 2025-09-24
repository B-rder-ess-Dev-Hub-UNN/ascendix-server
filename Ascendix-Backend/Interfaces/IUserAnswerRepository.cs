using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Ascendix_Backend.Dto.UserAnswerDto;
using Ascendix_Backend.Models;

namespace Ascendix_Backend.Interfaces
{
    public interface IUserAnswerRepository
    {
        public Task<List<UserAnswer>> getAll(Guid attemptId);
        public Task<UserAnswer?> getById(Guid id);
        public Task<UserAnswer> create(UserAnswer answer);
        public Task<UserAnswer?> update(Guid id, UpdateUserAnswer update);
        public Task<UserAnswer?> delete(Guid id);
        public Task<UserAnswer?> updateUserQuizAttempt(UserAnswer answer);
    }
}
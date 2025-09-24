using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Dto.UserQuizAttemptDto;
using Ascendix_Backend.Models;

namespace Ascendix_Backend.Interfaces
{
    public interface IUserQuizAttemptRepository
    {
        public Task<List<UserQuizAttempt>> getAll(string userId);
        public Task<UserQuizAttempt?> getById(Guid id, string userId);
        public Task<UserQuizAttempt?> getByIdAlone(Guid id);
        public Task<UserQuizAttempt> create(UserQuizAttempt attempt);
        public Task<UserQuizAttempt?> update(Guid id, string userId, UpdateUserQuizAttempt update);
        public Task<UserQuizAttempt?> delete(Guid id, string userId);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Dto.UserQuizAttemptDto;
using Ascendix_Backend.Models;

namespace Ascendix_Backend.Mappers
{
    public static class UserQuizAttemptMapper
    {
        public static UserQuizAttempt toUserQuizAttempt(this CreateUserQuizAttempt create)
        {
            return new UserQuizAttempt
            {
                moduleQuizId = create.moduleQuizId,
                createdAt = DateTime.UtcNow
            };
        }

        public static ViewUserQuizAttempt fromUserQuizAttempt(this UserQuizAttempt attempt)
        {
            return new ViewUserQuizAttempt
            {
                id = attempt.id,
                moduleQuizId = attempt.moduleQuizId,
                userId = attempt.userId,
                score = attempt.score,
                createdAt = attempt.createdAt,
                updatedAt = attempt.updatedAt,
            };
        }
    }
}
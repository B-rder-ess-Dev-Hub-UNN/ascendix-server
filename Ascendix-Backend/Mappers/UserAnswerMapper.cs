using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Dto.UserAnswerDto;
using Ascendix_Backend.Models;

namespace Ascendix_Backend.Mappers
{
    public static class UserAnswerMapper
    {
        public static UserAnswer toUserAnswer(this CreateUserAnswer create)
        {
            return new UserAnswer
            {
                quizQuestionId = create.questionId,
                userQuizAttemptId = create.attemptId,
                questionOptionsId = create.optionId,
                answerText = create.answerText,
            };
        }

        public static ViewUserAnswer fromUserAnswer(this UserAnswer answer)
        {
            return new ViewUserAnswer
            {
                id = answer.id,
                quizQuestionId = answer.quizQuestionId,
                userQuizAttemptId = answer.userQuizAttemptId,
                questionOptionsId = answer.questionOptionsId,
                answerText = answer.answerText,
            };
        }
    }
}
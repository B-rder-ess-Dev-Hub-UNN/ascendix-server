using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Dto.QuizQuestionDto;
using Ascendix_Backend.Models;

namespace Ascendix_Backend.Mappers
{
    public static class QuizQuestionMapper
    {
        public static QuizQuestions toQuizQuestion(this CreateQuizQuestion create)
        {
            return new QuizQuestions
            {
                quizId = create.quizId,
                questionText = create.questionText,
                questionType = create.questionType,
            };
        }

        public static ViewQuizQuestion fromQuizQuestion(this QuizQuestions question)
        {
            return new ViewQuizQuestion
            {
                id = question.id,
                quizId = question.quizId,
                questionText = question.questionText,
                questionType = question.questionType,
            };
        }
    }
}
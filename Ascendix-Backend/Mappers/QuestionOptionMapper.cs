using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Dto.QuestionOptionDto;
using Ascendix_Backend.Models;

namespace Ascendix_Backend.Mappers
{
    public static class QuestionOptionMapper
    {
        public static QuestionOptions toQuestionOption(this CreateQuestionOption create)
        {
            return new QuestionOptions
            {
                questionId = create.questionId,
                optionText = create.optionText,
                isCorrect = create.isCorrect,
            };
        }

        public static ViewQuestionOption fromQuestionOption(this QuestionOptions options)
        {
            return new ViewQuestionOption
            {
                id = options.id,
                questionId = options.questionId,
                optionText = options.optionText,
                isCorrect = options.isCorrect,
            };
        }
    }
}
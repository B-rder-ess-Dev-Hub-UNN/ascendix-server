using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Dto.ModuleQuizDto;
using Ascendix_Backend.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Ascendix_Backend.Mappers
{
    public static class ModuleQuizMapper
    {
        public static ModuleQuiz toModuleQuiz(this CreateModuleQuiz create)
        {
            return new ModuleQuiz
            {
                moduleId = create.moduleId,
                title = create.title,
                description = create.description,
            };
        }

        public static ViewModuleQuiz fromModuleQuiz(this ModuleQuiz quiz)
        {
            return new ViewModuleQuiz
            {
                id = quiz.id,
                moduleId = quiz.moduleId,
                title = quiz.title,
                description = quiz.description,
                questions = quiz.quizQuestions.Select(q => q.fromQuizQuestion()).ToList(),
            };
        }     

    }
}
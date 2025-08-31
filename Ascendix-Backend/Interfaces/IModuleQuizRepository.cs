using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Dto.ModuleQuizDto;
using Ascendix_Backend.Models;

namespace Ascendix_Backend.Interfaces
{
    public interface IModuleQuizRepository
    {
        public Task<List<ModuleQuiz>> getAll();
        public Task<ModuleQuiz?> getById(Guid id);
        public Task<ModuleQuiz> create(ModuleQuiz create);
        public Task<ModuleQuiz?> update(Guid id, UpdateModuleQuiz update);
        public Task<ModuleQuiz?> deleteById(Guid id);
    }
}
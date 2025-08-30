using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Dto.ModuleDto;
using Ascendix_Backend.Models;

namespace Ascendix_Backend.Interfaces
{
    public interface IModuleRepository
    {
        public Task<List<Module>> getAll();
        public Task<Module?> getById(Guid id);
        public Task<Module> create(Module module);
        public Task<Module?> update(Guid id, UpdateModule update);
        public Task<Module?> deleteById(Guid id);
    }
}
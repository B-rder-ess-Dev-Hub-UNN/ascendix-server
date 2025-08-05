using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Dto.ModuleDto;
using Ascendix_Backend.Models;

namespace Ascendix_Backend.Mappers
{
    public static class ModuleMapper
    {
        public static Module toModule(this CreateModule create)
        {
            return new Module
            {
                courseId = create.courseId,
                title = create.title,
                courseContent = create.courseContent,
            };
        }

        public static ViewModule fromModule(this Module module)
        {
            return new ViewModule
            {
                moduleId = module.moduleId,
                courseId = module.courseId,
                title = module.title,
                courseContent = module.courseContent,

            };
        }
    }
}
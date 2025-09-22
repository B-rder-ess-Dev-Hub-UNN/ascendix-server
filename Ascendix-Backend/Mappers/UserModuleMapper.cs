using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Dto.UserModuleDto;
using Ascendix_Backend.Models;

namespace Ascendix_Backend.Mappers
{
    public static class UserModuleMapper
    {
        public static UserModule toUserModule(this CreateUserModule create)
        {
            return new UserModule
            {
                moduleId = create.moduleId,
                status = Status.OnGoing
            };
        }

        public static ViewUserModule fromUserModule(this UserModule userModule)
        {
            return new ViewUserModule
            {
                id = userModule.id,
                moduleId = userModule.moduleId,
                userId = userModule.userId,
                progressPercent = userModule.progressPercent,
                status = userModule.status
            };
        }
        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Dto.UserQuestDto;
using Ascendix_Backend.Models;

namespace Ascendix_Backend.Mappers
{
    public static class UserQuestMapper
    {
        public static UserQuest toUserQuest(this CreateUserQuest create)
        {
            return new UserQuest
            {
                userId = create.userId,
                questId = create.questId,
                status = Status.OnGoing,
            };
        }

        public static ViewUserQuest fromUserQuest(this UserQuest quest)
        {
            return new ViewUserQuest
            {
                userQuestId = quest.userQuestId,
                userId = quest.userId,
                questId = quest.questId,
                status = quest.status,
                completedAt = quest.completedAt,
            };
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Dto.QuestDto;
using Ascendix_Backend.Models;

namespace Ascendix_Backend.Mappers
{
    public static class QuestMapper
    {
        public static Quest toQuest(this CreateQuest create)
        {
            return new Quest
            {
                title = create.title,
                description = create.description,
                tokenAllocation = create.tokenAllocation,
                createdAt = DateTime.UtcNow,
            };
        }

        public static ViewQuest fromQuest(this Quest create)
        {
            return new ViewQuest
            {
                questId = create.questId,
                title = create.title,
                description = create.description,
                tokenAllocation = create.tokenAllocation
            };
        }
    }
}
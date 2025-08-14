using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Dto.QuestDto;
using Ascendix_Backend.Models;

namespace Ascendix_Backend.Interfaces
{
    public interface IQuestRepository
    {
        public Task<List<Quest>> GetAllQuestsAsync();
        public Task<Quest?> GetQuestByIdAsync(Guid id);
        public Task<Quest> createQuestAsync(Quest quest);
        public Task<Quest?> updateQuestAsync(Guid id, UpdateQuest update);
        public Task<Quest?> deleteQuestByIdAsync(Guid id);
        
    }
}
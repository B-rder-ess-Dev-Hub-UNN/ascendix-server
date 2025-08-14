using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Data;
using Ascendix_Backend.Dto.QuestDto;
using Ascendix_Backend.Interfaces;
using Ascendix_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Ascendix_Backend.Repositories
{
    public class QuestRepository : IQuestRepository
    {
        private readonly AppDbContext _context;
        public QuestRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Quest> createQuestAsync(Quest quest)
        {
            await _context.quests.AddAsync(quest);
            await _context.SaveChangesAsync();
            return quest;
        }

        public async Task<Quest?> deleteQuestByIdAsync(Guid id)
        {
            var quest = await _context.quests.FirstOrDefaultAsync(c => c.questId == id);
            if (quest == null) return null;

            _context.quests.Remove(quest);
            await _context.SaveChangesAsync();
            return quest;
        }

        public async Task<List<Quest>> GetAllQuestsAsync()
        {
            return await _context.quests.ToListAsync();
        }

        public async Task<Quest?> GetQuestByIdAsync(Guid id)
        {
            var quest = await _context.quests.FirstOrDefaultAsync(c => c.questId == id);
            if (quest == null) return null;
            
            return quest; ;
        }

        public async Task<Quest?> updateQuestAsync(Guid id, UpdateQuest update)
        {
            var quest = await _context.quests.FirstOrDefaultAsync(c => c.questId == id);
            if (quest == null) return null;

            if (!string.IsNullOrWhiteSpace(update.title)) quest.title = update.title;
            if (!string.IsNullOrWhiteSpace(update.description)) quest.description = update.description;
            if (!string.IsNullOrWhiteSpace(update.actionType)) quest.actionType = update.actionType;
            if (update.rewardAmount != default) quest.rewardAmount = update.rewardAmount;
            if (update.isActive.HasValue) quest.isActive = update.isActive.Value;

            await _context.SaveChangesAsync();
            return quest;
        }
    }
}
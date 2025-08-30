using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Models;

namespace Ascendix_Backend.Interfaces
{
    public interface IUserQuestRepository
    {
        public Task<List<UserQuest>> GetAll();
        public Task<UserQuest?> GetbyId(Guid id);
        public Task<UserQuest?> Create(UserQuest userQuest);
        public Task<UserQuest?> UpdateStatus(Guid id, string status);
        public Task<UserQuest?> DeleteById(Guid id);
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ascendix_Backend.Models
{
    public class Quest
    {
        [Key]
        public Guid questId { get; set; }
        public string title { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public string actionType { get; set; } = string.Empty;
        public decimal rewardAmount { get; set; }
        public bool isActive { get; set; }
        public DateTime createdAt { get; set; }

        public ICollection<UserQuest> userQuests { get; set; } = new List<UserQuest>();
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ascendix_Backend.Models
{
    public class UserQuest
    {
        [Key]
        public Guid userQuestId { get; set; }
        public Guid userId { get; set; }
        public Guid questId { get; set; }
        public Status status { get; set; }
        public DateTime completedAt { get; set; }

        public User user { get; set; } = new User();
        public Quest quest { get; set; } = new Quest();
    }
}
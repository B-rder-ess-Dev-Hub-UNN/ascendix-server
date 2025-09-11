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
        public string? userId { get; set; }
        public Guid questId { get; set; }
        public Status status { get; set; }
        public DateTime completedAt { get; set; }

        public User? user { get; set; }
        public Quest? quest { get; set; }
    }
}
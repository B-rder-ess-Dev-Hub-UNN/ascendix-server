using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Models;

namespace Ascendix_Backend.Dto.UserQuestDto
{
    public class ViewUserQuest
    {
        public Guid userQuestId { get; set; }
        public string? userId { get; set; }
        public Guid questId { get; set; }
        public Status status { get; set; }
        public DateTime completedAt { get; set; }
    }
}
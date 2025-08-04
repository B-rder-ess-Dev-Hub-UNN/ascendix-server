using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Models;

namespace Ascendix_Backend.Dto.UserQuestDto
{
    public class CreateUserQuest
    {
        public Guid userId { get; set; }
        public Guid questId { get; set; }
        public Status status { get; set; }
    }
}
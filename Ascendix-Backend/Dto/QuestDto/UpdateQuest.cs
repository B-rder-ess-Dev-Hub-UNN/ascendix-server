using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ascendix_Backend.Dto.QuestDto
{
    public class UpdateQuest
    {
        public string? title { get; set; }
        public string? description { get; set; }
        public decimal tokenAllocation { get; set; }
    }
}
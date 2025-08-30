using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ascendix_Backend.Models
{
    public class LeaderBoard
    {
        public Guid id { get; set; }
        public int rank { get; set; }
        public string? userId { get; set; }
        public decimal earnings { get; set; }
    }
}
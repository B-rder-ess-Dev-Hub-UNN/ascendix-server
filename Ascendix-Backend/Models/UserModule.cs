using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ascendix_Backend.Models
{
    public class UserModule
    {
        public Guid id { get; set; }
        public Guid moduleId { get; set; }
        public string? userId { get; set; }
        public Status status { get; set; }
        public int progressPercent { get; set; }

        public Module? modules { get; set; }
        public User? user { get; set; }
    }
}
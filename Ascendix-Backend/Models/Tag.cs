using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ascendix_Backend.Models
{
    public class Tag
    {
        public Guid id { get; set; }
        public string? name { get; set; }
        public string? slug { get; set; }

        public ICollection<CourseTag> courseTags{ get; set; } = new List<CourseTag>();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ascendix_Backend.Models
{
    public class CourseTag
    {
        public Guid id { get; set; }
        public Guid tagId { get; set; }
        public Guid courseId { get; set; }

        public Tag? tag { get; set; }
        public Course? course{ get; set; }
    }
}
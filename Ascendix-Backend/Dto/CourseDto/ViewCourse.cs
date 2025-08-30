using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Ascendix_Backend.Dto.ModuleDto;

namespace Ascendix_Backend.Dto.CourseDto
{
    public class ViewCourse
    {
        public Guid id { get; set;}
        public string title { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public decimal tokenAllocation { get; set; }
        public List<ViewModule> modules { get; set; } = new List<ViewModule>();

    }
}
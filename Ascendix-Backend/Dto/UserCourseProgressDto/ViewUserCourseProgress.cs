using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Models;

namespace Ascendix_Backend.Dto.UserCourseProgressDto
{
    public class ViewUserCourseProgress
    {
        public Guid progressId { get; set; }
        public string? userId { get; set; }
        public Guid courseId { get; set; }
        public int progressPercent { get; set; }
        public Status status { get; set; }
        
    }
}
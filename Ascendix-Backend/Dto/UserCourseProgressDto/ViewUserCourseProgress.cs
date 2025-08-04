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
        public Guid userId { get; set; }
        public Guid courseId { get; set; }
        public decimal progressPercent { get; set; }
        public Status status { get; set; }
        public char grade { get; set; }
        public string certificateURL { get; set; } = string.Empty;
        public DateTime completedAt { get; set; }
    }
}
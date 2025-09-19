using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Models;

namespace Ascendix_Backend.Dto.UserCourseProgressDto
{
    public class UpdateUserCourseProgress
    {
        public Guid? courseId { get; set; }
        public decimal? progressPercent { get; set; }
        public Status? status { get; set; }

    }
}
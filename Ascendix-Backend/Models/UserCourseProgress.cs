using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Ascendix_Backend.Models
{
    public class UserCourseProgress
    {
        [Key]
        public Guid progressId { get; set; }
        public Guid userId { get; set; }
        public Guid courseId { get; set; }
        public decimal progressPercent { get; set; }
        public Status status { get; set; }
        public char grade { get; set; }
        public string certificateURL { get; set; } = string.Empty;
        public DateTime completedAt { get; set; }

        public User user { get; set; } = new User();
        public Course course { get; set; } = new Course();
    }

    public enum Status
    {
        Pending,
        OnGoing,
        Completed
    }
}
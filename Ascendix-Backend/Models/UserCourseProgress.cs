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
        public DateTime completedAt { get; set; }

        public User? user { get; set; }
        public Course? course { get; set; }
    }

    public enum Status
    {
        Pending,
        OnGoing,
        Completed
    }
}
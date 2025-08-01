using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ascendix_Backend.Models
{
    public class Course
    {
        [Key]
        public Guid courseId { get; set; }
        public Guid libraryId { get; set; }
        public string title { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public decimal rewardAmount { get; set; }
        public string nftTemplateId { get; set; } = string.Empty;
        public bool isActive { get; set; }
        public DateTime createdAt { get; set; }

        public Library library { get; set; } = new Library();
        public ICollection<UserCourseProgress> userCourseProgresses { get; set; } = new List<UserCourseProgress>();
        public ICollection<Certificate> certificates { get; set; } = new List<Certificate>();
        public ICollection<Module> modules { get; set; } = new List<Module>();
    }
}
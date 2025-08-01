using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Ascendix_Backend.Models
{
    public class User : IdentityUser
    {
        public string walletAddress { get; set; } = string.Empty;
        public decimal totalPoints { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }

        public ICollection<UserQuest> userQuests { get; set; } = new List<UserQuest>();
        public ICollection<UserCourseProgress> userCourseProgresses { get; set; } = new List<UserCourseProgress>();
        public ICollection<Certificate> certificates { get; set; } = new List<Certificate>();
    }
}
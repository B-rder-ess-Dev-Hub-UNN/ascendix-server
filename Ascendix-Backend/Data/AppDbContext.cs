using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Ascendix_Backend.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> users { get; set; }
        public DbSet<UserCourseProgress> userCourseProgresses { get; set; }
        public DbSet<Course> course { get; set; }
        public DbSet<Library> library { get; set; }
        public DbSet<Module> modules { get; set; }
        public DbSet<Certificate> certificates { get; set; }
        public DbSet<Quest> quests { get; set; }
        public DbSet<UserQuest> userQuest { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings => 
                warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ascendix_Backend.Models;
using Microsoft.AspNetCore.Identity;
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
        public DbSet<Tag> tags { get; set; }
        public DbSet<CourseTag> courseTags { get; set; }
        public DbSet<LeaderBoard> leaderBoards { get;  set; }
        public DbSet<ModuleQuiz> moduleQuizzes { get;  set; }
        public DbSet<QuestionOptions> questionOptions { get; set; }
        public DbSet<QuizQuestions> quizQuestions { get; set; }
        public DbSet<UserAnswer> userAnswers { get; set; }
        public DbSet<UserCertificate> userCertificates { get; set; }
        public DbSet<UserQuizAttempt> userQuizAttempts { get; set;}
        public DbSet<UserModule> userModules { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            List<IdentityRole> role = new List<IdentityRole>()
                {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                }
                };
            builder.Entity<IdentityRole>().HasData(role);

            //this is where the relationships between useranswer and other tables is declared
            builder.Entity<UserAnswer>()
                .HasOne(ua => ua.attempt)
                .WithMany(uqa => uqa.userAnswers)
                .HasForeignKey(ua => ua.userQuizAttemptId)
                .OnDelete(DeleteBehavior.NoAction); // 👈 no cascade here

            builder.Entity<UserAnswer>()
                .HasOne(ua => ua.question)
                .WithMany(q => q.answers)
                .HasForeignKey(ua => ua.quizQuestionId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<UserAnswer>()
                .HasOne(ua => ua.options)
                .WithMany(qo => qo.userAnswers)
                .HasForeignKey(ua => ua.questionOptionsId)
                .OnDelete(DeleteBehavior.Cascade);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings =>
                warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }
    }
}
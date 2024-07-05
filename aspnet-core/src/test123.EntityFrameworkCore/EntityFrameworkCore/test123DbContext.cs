using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using test123.Authorization.Roles;
using test123.Authorization.Users;
using test123.MultiTenancy;
using test123.Courses;
using test123.Quizzes;

namespace test123.EntityFrameworkCore
{
    public class test123DbContext : AbpZeroDbContext<Tenant, Role, User, test123DbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Course> Courses { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Option> Options { get; set; }
        public test123DbContext(DbContextOptions<test123DbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the Course-Quiz relationship
            modelBuilder.Entity<Quiz>()
                .HasOne(q => q.Course)
                .WithMany(c => c.Quizzes)
                .HasForeignKey(q => q.CourseId);

            // Configure the Quiz-Question relationship
            modelBuilder.Entity<Question>()
                .HasOne(q => q.Quiz)
                .WithMany(qz => qz.Questions)
                .HasForeignKey(q => q.QuizId);

            // Configure the Question-Option relationship
            modelBuilder.Entity<Option>()
                .HasOne(o => o.Question)
                .WithMany(q => q.Options)
                .HasForeignKey(o => o.QuestionId);
        }
    }
}

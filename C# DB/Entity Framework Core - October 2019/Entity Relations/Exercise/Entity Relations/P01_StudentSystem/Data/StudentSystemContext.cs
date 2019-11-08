namespace P01_StudentSystem.Data
{
    using Microsoft.EntityFrameworkCore;

    using P01_StudentSystem.Configuration;
    using P01_StudentSystem.Data.Models;

    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {
        }

        public StudentSystemContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Homework> HomeworkSubmissions { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            DatabaseSeeder.CoursesSeed(modelBuilder);

            modelBuilder.ApplyConfiguration(new HomeworkConfiguration());
            DatabaseSeeder.HomeworkSeed(modelBuilder);

            modelBuilder.ApplyConfiguration(new ResourceConfiguration());
            DatabaseSeeder.ResourceSeed(modelBuilder);

            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            DatabaseSeeder.StudentSeed(modelBuilder);

            modelBuilder.ApplyConfiguration(new StudentCourseConfiguration());
            DatabaseSeeder.StudentCourseSeed(modelBuilder);
        }
    }
}
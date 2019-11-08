namespace P01_StudentSystem.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Data.Models;

    public class StudentCourseConfiguration : IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(EntityTypeBuilder<StudentCourse> studentCourse)
        {
            studentCourse
                .HasKey(pk => new
                {
                    pk.StudentId,
                    pk.CourseId
                });

            studentCourse
                .HasOne(sc => sc.Student)
                .WithMany(c => c.CourseEnrollments)
                .HasForeignKey(s => s.StudentId);

            studentCourse
                .HasOne(sc => sc.Course)
                .WithMany(sc => sc.StudentsEnrolled)
                .HasForeignKey(c => c.CourseId);
        }
    }
}
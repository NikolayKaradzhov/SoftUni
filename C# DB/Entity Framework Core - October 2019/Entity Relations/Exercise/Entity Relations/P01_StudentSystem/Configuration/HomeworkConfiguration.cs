namespace P01_StudentSystem.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Data.Models;

    public class HomeworkConfiguration : IEntityTypeConfiguration<Homework>
    {
        public void Configure(EntityTypeBuilder<Homework> homework)
        {
            homework
                .HasKey(h => h.HomeworkId);

            homework
                .Property(h => h.Content)
                .IsRequired(true)
                .IsUnicode(false);

            homework
                .Property(h => h.ContentType)
                .IsRequired(true);

            homework
                .Property(h => h.SubmissionTime)
                .IsRequired(true);

            homework
                .HasOne(h => h.Student)
                .WithMany(h => h.HomeworkSubmissions)
                .HasForeignKey(s => s.StudentId);

            homework
                .HasOne(h => h.Course)
                .WithMany(h => h.HomeworkSubmissions)
                .HasForeignKey(c => c.CourseId);
        }
    }
}
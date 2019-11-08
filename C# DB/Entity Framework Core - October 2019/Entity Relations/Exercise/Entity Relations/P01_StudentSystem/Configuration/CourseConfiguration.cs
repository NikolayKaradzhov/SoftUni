namespace P01_StudentSystem.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Data.Models;

    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder
                .HasKey(c => c.CourseId);

            builder
                .Property(c => c.Name)
                .HasMaxLength(80)
                .IsRequired(true)
                .IsUnicode(true);

            builder
                .Property(c => c.Description)
                .IsRequired(false)
                .IsUnicode(true);

            builder
                .Property(c => c.StartDate)
                .IsRequired(true);

            builder
                .Property(c => c.EndDate)
                .IsRequired(true);

            builder
                .Property(c => c.Price)
                .IsRequired(true);
        }
    }
}
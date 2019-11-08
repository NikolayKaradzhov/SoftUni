namespace P01_StudentSystem.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Data.Models;

    public class ResourceConfiguration : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> resource)
        {
            resource
                .HasKey(r => r.ResourceId);

            resource
                .Property(r => r.Name)
                .HasMaxLength(50)
                .IsUnicode(true)
                .IsRequired(true);

            resource
                .Property(r => r.Url)
                .IsRequired(false)
                .IsUnicode(false);

            resource
                .Property(r => r.ResourceType)
                .IsRequired(true);

            resource
                .HasOne(r => r.Course)
                .WithMany(r => r.Resources)
                .HasForeignKey(fk => fk.CourseId);
        }
    }
}
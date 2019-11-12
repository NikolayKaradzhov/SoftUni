namespace P03_FootballBetting.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using P03_FootballBetting.Data.Models;

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> userBuilder)
        {
            userBuilder
                .HasKey(u => u.UserId);

            userBuilder
                .Property(u => u.Username)
                .HasMaxLength(30)
                .IsRequired(true)
                .IsUnicode(true);

            userBuilder
                .Property(u => u.Password)
                .HasMaxLength(30)
                .IsRequired(true)
                .IsUnicode(true);

            userBuilder
                .Property(u => u.Email)
                .HasMaxLength(50)
                .IsRequired(true)
                .IsUnicode(true);

            userBuilder
                .Property(u => u.Balance)
                .IsRequired(true);
        }
    }
}
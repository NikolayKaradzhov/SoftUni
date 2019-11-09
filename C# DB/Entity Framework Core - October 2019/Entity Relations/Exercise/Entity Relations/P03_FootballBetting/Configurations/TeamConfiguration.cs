using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Configurations
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> teamBuilder)
        {
            teamBuilder
                .HasKey(t => t.TeamId);

            teamBuilder
                .Property(t => t.Name)
                .HasMaxLength(30)
                .IsRequired(true)
                .IsUnicode(true);

            teamBuilder
                .Property(t => t.LogoUrl)
                .IsRequired(true)
                .IsUnicode(true);

            teamBuilder
                .Property(t => t.Initials)
                .HasColumnType("CHAR(3)")
                .IsRequired(true)
                .IsUnicode(true);

            teamBuilder
                .Property(t => t.Budget)
                .IsRequired(true);

            teamBuilder
                .HasOne(t => t.PrimaryKitColor)
                .WithMany(c => c.PrimaryKitTeams)
                .HasForeignKey(t => t.PrimaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict);

            teamBuilder
                .HasOne(t => t.SecondaryKitColor)
                .WithMany(c => c.SecondaryKitTeams)
                .HasForeignKey(t => t.SecondaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict);

            teamBuilder
                .HasOne(t => t.Town)
                .WithMany(tm => tm.Teams)
                .HasForeignKey(t => t.TownId);
        }
    }
}
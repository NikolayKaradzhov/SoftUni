namespace P03_FootballBetting.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using P03_FootballBetting.Data.Models;

    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> playerBuilder)
        {
            playerBuilder
                .HasKey(p => p.PlayerId);

            playerBuilder
                .Property(p => p.Name)
                .HasMaxLength(30)
                .IsRequired(true)
                .IsUnicode(true);

            playerBuilder
                .Property(p => p.SquadNumber)
                .IsRequired(true);

            playerBuilder
                .Property(p => p.IsInjured)
                .IsRequired(true);

            playerBuilder
                .HasOne(t => t.Team)
                .WithMany(p => p.Players)
                .HasForeignKey(fk => fk.TeamId);

            playerBuilder
                .HasOne(p => p.Position)
                .WithMany(pl => pl.Players)
                .HasForeignKey(fk => fk.PositionId);
        }
    }
}
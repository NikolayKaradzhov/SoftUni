namespace P03_FootballBetting.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using P03_FootballBetting.Data.Models;

    public class PlayerStatisticConfiguration : IEntityTypeConfiguration<PlayerStatistic>
    {
        public void Configure(EntityTypeBuilder<PlayerStatistic> playerStatisticsBuilder)
        {
            playerStatisticsBuilder
                .HasKey(pk => new
                {
                    pk.GameId,
                    pk.PlayerId
                });

            playerStatisticsBuilder
                .Property(p => p.ScoredGoals)
                .IsRequired(true);

            playerStatisticsBuilder
                .Property(p => p.Assists)
                .IsRequired(true);

            playerStatisticsBuilder
                .Property(p => p.MinutesPlayed)
                .IsRequired(true);

            playerStatisticsBuilder
                .HasOne(ps => ps.Player)
                .WithMany(p => p.PlayerStatistics)
                .HasForeignKey(p => p.PlayerId);

            playerStatisticsBuilder
                .HasOne(g => g.Game)
                .WithMany(p => p.PlayerStatistics)
                .HasForeignKey(fk => fk.GameId);
        }
    }
}
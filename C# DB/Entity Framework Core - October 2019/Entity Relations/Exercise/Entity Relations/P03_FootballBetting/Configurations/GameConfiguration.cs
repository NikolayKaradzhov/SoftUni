namespace P03_FootballBetting.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using P03_FootballBetting.Data.Models;

    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> gameBuilder)
        {
            gameBuilder
                .HasKey(g => g.GameId);

            gameBuilder
                .Property(g => g.HomeTeamGoals)
                .IsRequired(true);

            gameBuilder
                .Property(g => g.AwayTeamGoals)
                .IsRequired(true);

            gameBuilder
                .Property(g => g.DateTime)
                .IsRequired(true);

            gameBuilder
                .Property(g => g.HomeTeamBetRate)
                .IsRequired(true);

            gameBuilder
                .Property(g => g.AwayTeamBetRate)
                .IsRequired(true);

            gameBuilder
                .Property(g => g.DrawBetRate)
                .IsRequired(true);

            gameBuilder
                .Property(g => g.Result)
                .HasMaxLength(20)
                .IsRequired(true)
                .IsUnicode(true);

            gameBuilder
                .HasOne(g => g.HomeTeam)
                .WithMany(g => g.HomeGames)
                .HasForeignKey(fk => fk.HomeTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            gameBuilder
                .HasOne(g => g.AwayTeam)
                .WithMany(g => g.AwayGames)
                .HasForeignKey(fk => fk.AwayTeamId)
                .OnDelete(DeleteBehavior.Restrict);    
        }
    }
}
namespace P03_FootballBetting.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using P03_FootballBetting.Data.Models;

    public class BetConfiguration : IEntityTypeConfiguration<Bet>
    {
        public void Configure(EntityTypeBuilder<Bet> betBuilder)
        {
            betBuilder
                .HasKey(b => b.BetId);

            betBuilder
                .Property(b => b.Amount)
                .IsRequired(true);

            betBuilder
                .Property(b => b.DateTime)
                .IsRequired(true);

            betBuilder
                .Property(b => b.Prediction)
                .HasMaxLength(200)
                .IsRequired(true);

            betBuilder
                .HasOne(g => g.Game)
                .WithMany(b => b.Bets)
                .HasForeignKey(fk => fk.GameId);

            betBuilder
                .HasOne(u => u.User)
                .WithMany(b => b.Bets)
                .HasForeignKey(fk => fk.UserId);
        }
    }
}
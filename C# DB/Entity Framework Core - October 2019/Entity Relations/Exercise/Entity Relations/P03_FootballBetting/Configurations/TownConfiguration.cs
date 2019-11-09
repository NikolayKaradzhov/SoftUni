namespace P03_FootballBetting.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using P03_FootballBetting.Data.Models;

    public class TownConfiguration : IEntityTypeConfiguration<Town>
    {
        public void Configure(EntityTypeBuilder<Town> townBuilder)
        {
            townBuilder
                .HasKey(t => t.TownId);

            townBuilder
                .Property(t => t.Name)
                .HasMaxLength(30)
                .IsRequired(true)
                .IsUnicode(true);

            townBuilder
                .HasOne(c => c.Country)
                .WithMany(t => t.Towns)
                .HasForeignKey(fk => fk.CountryId);
        }
    }
}
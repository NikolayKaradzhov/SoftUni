using Microsoft.Extensions.Logging;

namespace P01_HospitalDatabase.Data
{
    using Microsoft.EntityFrameworkCore;

    using P01_HospitalDatabase.Data.Models;

    public class HospitalContext : DbContext
    {
        public HospitalContext()
        {
            
        }

        public HospitalContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Diagnose> Diagnoses { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Visitation> Visitations { get; set; }
        public DbSet<PatientMedicament> PatientsMedicaments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Diagnose>(entity =>
            {
                entity
                    .HasKey(d => d.DiagnoseId);

                entity
                    .Property(d => d.Name)
                    .HasMaxLength(50)
                    .IsRequired(true)
                    .IsUnicode(true);

                entity
                    .Property(d => d.Comments)
                    .HasMaxLength(250)
                    .IsRequired(false)
                    .IsUnicode(true);
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity
                    .HasKey(p => p.PatientId);

                entity
                    .Property(p => p.FirstName)
                    .HasMaxLength(50)
                    .IsRequired(true)
                    .IsUnicode(true);

                entity
                    .Property(p => p.LastName)
                    .HasMaxLength(50)
                    .IsRequired(true)
                    .IsUnicode(true);

                entity
                    .Property(p => p.Address)
                    .HasMaxLength(50)
                    .IsRequired(true)
                    .IsUnicode(true);

                entity
                    .Property(p => p.Email)
                    .HasMaxLength(80)
                    .IsRequired(true)
                    .IsUnicode(false);

                entity
                    .Property(p => p.HasInsurance)
                    .IsRequired(true);

                entity
                    .HasMany(p => p.Visitations)
                    .WithOne(p => p.Patient)
                    .HasForeignKey(k => k.VisitationId);

                entity
                    .HasMany(p => p.Diagnoses)
                    .WithOne(p => p.Patient)
                    .HasForeignKey(k => k.DiagnoseId);

                entity
                    .HasMany(p => p.Prescriptions)
                    .WithOne(p => p.Patient)
                    .HasForeignKey(k => k.PatientId);
            });

            modelBuilder.Entity<Visitation>(entity =>
            {
                entity
                    .HasKey(v => v.VisitationId);

                entity
                    .Property(v => v.Date)
                    .HasColumnType("DATETIME2")
                    .IsRequired(true);

                entity
                    .Property(v => v.Comments)
                    .HasMaxLength(250)
                    .IsRequired(false)
                    .IsUnicode(true);
            });

            modelBuilder.Entity<Medicament>(entity =>
            {
                entity
                    .HasKey(m => m.MedicamentId);

                entity
                    .Property(m => m.Name)
                    .HasMaxLength(50)
                    .IsRequired(true)
                    .IsUnicode(true);
            });

            modelBuilder.Entity<PatientMedicament>(entity =>
            {
                entity
                    .HasKey(k => new
                    {
                        k.MedicamentId,
                        k.PatientId
                    });
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity
                    .HasKey(d => d.DoctorId);

                entity
                    .Property(d => d.Name)
                    .HasMaxLength(30)
                    .IsRequired(true)
                    .IsUnicode(true);

                entity
                    .Property(d => d.Specialty)
                    .IsRequired(true);

                entity
                    .HasMany(d => d.Visitations)
                    .WithOne(d => d.Doctor)
                    .HasForeignKey(v => v.DoctorId);
            });
        }
    }
}
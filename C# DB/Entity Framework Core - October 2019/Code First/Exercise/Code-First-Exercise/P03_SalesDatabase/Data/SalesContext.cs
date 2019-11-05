namespace P03_SalesDatabase.Data
{
    using Microsoft.EntityFrameworkCore;

    using P03_SalesDatabase.Data.Models;

    public class SalesContext : DbContext
    {
        public SalesContext()
        {
            
        }

        public SalesContext(DbContextOptions options)
            :base(options)
        {
            
        }

        //DbSets are representation of a table in the DB
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public DbSet<Store> Stores { get; set; }


        //Overriding of OnConfiguring() and OnModelCreating() methods
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected internal virtual void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                //Primary Key
                entity.HasKey(p => p.ProductId);

                //Name property requirements((up to 50 characters, unicode))
                entity
                    .Property(p => p.Name)
                    .HasMaxLength(50)
                    .IsRequired(true) //True by default
                    .IsUnicode(true); //True by default


                entity
                    .Property(p => p.Quantity)
                    .IsRequired(true);

                entity
                    .Property(p => p.Price)
                    .IsRequired(true);

                //Sale property
                entity
                    .HasMany(p => p.Sales) //One product has many Sales
                    .WithOne(s => s.Product) //The Sale has one product
                    .HasForeignKey(s => s.ProductId); //The foreign key is ProductId in Sales class
            });
        }
    }
}
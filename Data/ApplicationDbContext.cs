using Asp_Net_Core_Mvc_Store.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Asp_Net_Core_Mvc_Store.Data
{
    public class ApplicationDbContext : DbContext
    {
        private const string CONNECTION_STRING_ID = "Default";

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        private readonly IConfiguration _configuration;

        public ApplicationDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
                return;

            string? connectionString = _configuration.GetConnectionString(CONNECTION_STRING_ID);

            if (string.IsNullOrEmpty(connectionString))
                throw new MissingFieldException($"Failed to get '{CONNECTION_STRING_ID}' connection string");

            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                        .Property(c => c.CreatedAt)
                        .HasDefaultValueSql("GETUTCDATE()");

            modelBuilder.Entity<Product>()
                        .Property(p => p.CreatedAt)
                        .HasDefaultValueSql("GETUTCDATE()");
        }
    }
}

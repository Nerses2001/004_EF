
using _004_EF.Configuration;
using _004_EF.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace _004_EF
{
    internal class AppDbContext : DbContext
    {
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Company> Companies { get; set; }

        public AppDbContext()
        {
            Database.EnsureDeleted();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) 
            {
                var builder = new SqlConnectionStringBuilder
                {
                    DataSource = ".",
                    InitialCatalog = "004_EF",
                    IntegratedSecurity = true,
                    TrustServerCertificate = true,
                };

                optionsBuilder.UseSqlServer(builder.ConnectionString);

            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PhoneConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
        }
    }
}

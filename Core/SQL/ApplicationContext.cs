using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Core.SQL
{
    public class ApplicationContext : DbContext
    {
        private readonly string _connectionString;

        public ApplicationContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SQL");
        }
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        public DbSet<Core.Models.Coffee> Coffee { get; set; }
        public DbSet<Core.Models.Purchase> Purchases { get; set; }
        public DbSet<Core.Models.Customer> Customers { get; set; }

    }
}

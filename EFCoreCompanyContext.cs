using Microsoft.EntityFrameworkCore;

namespace StockVisionConsole.Models
{
    public class EFCoreDemoContext : DbContext
    {
        public DbSet<Companies> Companies { get; set; }
        public DbSet<Company> Company { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("");
            
        }
    }
}
using lab123.Models;
using Microsoft.EntityFrameworkCore;

namespace lab123
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=UserDb;Trusted_Connection=True;");
        }
    }
}

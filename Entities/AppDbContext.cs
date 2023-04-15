using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace razor_countries.Entities
{
    public class AppDbContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=razorCountries_wer4-234asd3-33;Trusted_Connection=True");
        }

    }
}

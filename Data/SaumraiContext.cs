using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class SaumraiContext : DbContext
    {
        public DbSet<Samurai> Samuraies { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Clan> Clans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data source=samurai.db");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
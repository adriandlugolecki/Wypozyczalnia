using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using webAPI.Models;

namespace webAPI.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public DbSet<Klient> Klienci { get; set; }
        public DbSet<Pracownik> Pracownicy { get; set; }
        public DbSet<Samochod> Samochody { get; set; }
        public DbSet<Ubezpieczenie> Ubezpieczenia { get; set; }
        public DbSet<Wypozyczenie> Wypozyczenia { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Klient>(entity => { entity.ToTable("Klienci").HasIndex(p => p.Pesel).IsUnique(); });
            builder.Entity<Pracownik>(entity => { entity.ToTable("Pracownicy").HasIndex(e => e.Pesel).IsUnique(); });
        }

        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }
        
    }
}

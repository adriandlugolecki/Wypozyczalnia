using Microsoft.EntityFrameworkCore;
using webAPI.Models;

namespace webAPI.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Klient> Klienci { get; set; }
        public DbSet<Pracownik> Pracownicy { get; set; }
        public DbSet<Samochody> Samochody { get; set; }
        public DbSet<Ubezpieczenie> Ubezpieczenia { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }
        
    }
}

using Microsoft.EntityFrameworkCore;
using PlanetRegistration.Models;
using Планеты.Model;

namespace Планеты.Data.ApplicationDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Planet> Planets { get; set; }
    }
}

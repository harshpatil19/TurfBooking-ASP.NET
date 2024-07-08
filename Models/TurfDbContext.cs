using Microsoft.EntityFrameworkCore;

namespace TurfBookingSystem.Models
{
    public class TurfDbContext : DbContext
    {
        public TurfDbContext(DbContextOptions options):base(options) 
        { 
        }
        public DbSet<Turf>turf { get; set; }
    
    }
}

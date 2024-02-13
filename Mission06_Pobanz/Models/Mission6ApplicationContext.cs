using Microsoft.EntityFrameworkCore;

namespace Mission06_Pobanz.Models
{
    public class Mission6ApplicationContext : DbContext
    {
        public Mission6ApplicationContext(DbContextOptions<Mission6ApplicationContext> options) : base (options) 
        { 
        }

        public DbSet<Application> Applications { get; set; }

    }

    
}

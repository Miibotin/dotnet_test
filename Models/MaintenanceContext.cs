using Microsoft.EntityFrameworkCore;

namespace EtteplanTehtava.Models
{
    public class MaintenanceContext : DbContext
    {
        
        public MaintenanceContext(DbContextOptions<MaintenanceContext> options)
            : base(options)
        { }

        public DbSet<Maintenance> Maintenance { get; set; }
    }
}
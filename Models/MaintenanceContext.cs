using Microsoft.EntityFrameworkCore;

namespace EtteplanTehtava.Models
{
    public class MaintenanceContext : DbContext
    {
        public DbSet<Maintenance> Units { get; set; }
        public MaintenanceContext(DbContextOptions<MaintenanceContext> options)
            : base(options)
        { }

        public DbSet<Maintenance> MaintenanceUnit { get; set; }
    }
}
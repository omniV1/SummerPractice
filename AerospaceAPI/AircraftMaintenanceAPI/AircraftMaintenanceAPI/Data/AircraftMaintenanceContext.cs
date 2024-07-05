using Microsoft.EntityFrameworkCore;
using AircraftMaintenanceAPI.Models;

namespace AircraftMaintenanceAPI.Data
{
    /// <summary>
    /// Database context for the Aircraft Maintenance API.
    /// </summary>
    public class AircraftMaintenanceContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Aircraft> Aircrafts { get; set; }
        public DbSet<MaintenanceRecord> MaintenanceRecords { get; set; }
        public DbSet<PerformanceMetric> PerformanceMetrics { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configure the MySQL database connection string
            optionsBuilder.UseMySql("server=localhost;database=AircraftMaintenanceDB;user=root;password=yourpassword", new MySqlServerVersion(new Version(8, 0, 21)));
        }
    }
}

using AircraftMaintenanceAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace AircraftMaintenanceAPI.Data  // Make sure this matches the folder structure
{
    public class AircraftMaintenanceContext : DbContext
    {
        public AircraftMaintenanceContext(DbContextOptions<AircraftMaintenanceContext> options)
            : base(options)
        {
        }

        public DbSet<Aircraft> Aircrafts { get; set; }
        public DbSet<MaintenanceRecord> MaintenanceRecords { get; set; }
        public DbSet<PerformanceMetric> PerformanceMetrics { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aircraft>().HasData(
                new Aircraft
                {
                    Id = 1,
                    Model = "Boeing 747",
                    SerialNumber = "SN747",
                    LastMaintenanceDate = DateTime.Now
                },
                new Aircraft
                {
                    Id = 2,
                    Model = "Airbus A320",
                    SerialNumber = "SNA320",
                    LastMaintenanceDate = DateTime.Now
                }
            );
        }
    }
}

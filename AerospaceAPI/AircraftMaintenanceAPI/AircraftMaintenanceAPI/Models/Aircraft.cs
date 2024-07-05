using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AircraftMaintenanceAPI.Models
{
    /// <summary>
    /// Represents an aircraft with its details.
    /// </summary>
    public class Aircraft
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Model cannot be longer than 100 characters.")]
        public string Model { get; set; } = string.Empty;

        [Required]
        [StringLength(50, ErrorMessage = "Serial Number cannot be longer than 50 characters.")]
        public string SerialNumber { get; set; } = string.Empty;

        public DateTime LastMaintenanceDate { get; set; }

        public ICollection<MaintenanceRecord> MaintenanceRecords { get; set; } = new List<MaintenanceRecord>();
        public ICollection<PerformanceMetric> PerformanceMetrics { get; set; } = new List<PerformanceMetric>();
    }
}

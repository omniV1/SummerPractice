using System;
using System.ComponentModel.DataAnnotations;

namespace AircraftMaintenanceAPI.Models
{
    /// <summary>
    /// Represents a performance metric for an aircraft.
    /// </summary>
    public class PerformanceMetric
    {
        public int Id { get; set; }

        [Required]
        public int AircraftId { get; set; }
        public Aircraft Aircraft { get; set; } = new Aircraft();

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public double MetricValue { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Metric Type cannot be longer than 100 characters.")]
        public string MetricType { get; set; } = string.Empty;
    }
}

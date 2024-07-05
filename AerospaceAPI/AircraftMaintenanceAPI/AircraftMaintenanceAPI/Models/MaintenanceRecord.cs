using System;
using System.ComponentModel.DataAnnotations;

namespace AircraftMaintenanceAPI.Models
{
    /// <summary>
    /// Represents a maintenance record for an aircraft.
    /// </summary>
    public class MaintenanceRecord
    {
        public int Id { get; set; }

        [Required]
        public int AircraftId { get; set; }
        public Aircraft Aircraft { get; set; } = new Aircraft();

        [Required]
        public DateTime MaintenanceDate { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "Details cannot be longer than 500 characters.")]
        public string Details { get; set; } = string.Empty;
    }
}

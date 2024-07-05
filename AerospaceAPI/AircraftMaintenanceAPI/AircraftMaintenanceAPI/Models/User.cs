using System.ComponentModel.DataAnnotations;

namespace AircraftMaintenanceAPI.Models
{
    /// <summary>
    /// Represents a user in the system.
    /// </summary>
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Username cannot be longer than 100 characters.")]
        public string Username { get; set; } = string.Empty;

        [Required]
        [StringLength(255, ErrorMessage = "Password cannot be longer than 255 characters.")]
        public string Password { get; set; } = string.Empty;

        [Required]
        [StringLength(50, ErrorMessage = "Role cannot be longer than 50 characters.")]
        public string Role { get; set; } = string.Empty;
    }
}

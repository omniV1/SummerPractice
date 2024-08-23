using AircraftMaintenanceAPI.Models;

namespace AircraftMaintenanceAPI.Services
{
    public interface IMaintenanceRecordService
    {
        Task<IEnumerable<MaintenanceRecord>> GetAllMaintenanceRecordsAsync();
        Task<MaintenanceRecord?> GetMaintenanceRecordByIdAsync(int id);
        Task<MaintenanceRecord> CreateMaintenanceRecordAsync(MaintenanceRecord maintenanceRecord);
        Task<MaintenanceRecord?> UpdateMaintenanceRecordAsync(int id, MaintenanceRecord maintenanceRecord);
        Task<bool> DeleteMaintenanceRecordAsync(int id);
    }
}

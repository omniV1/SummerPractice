using AircraftMaintenanceAPI.Data;
using AircraftMaintenanceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AircraftMaintenanceAPI.Services
{
    public class MaintenanceRecordService : IMaintenanceRecordService
    {
        private readonly AircraftMaintenanceContext _context;

        public MaintenanceRecordService(AircraftMaintenanceContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MaintenanceRecord>> GetAllMaintenanceRecordsAsync()
        {
            return await _context.MaintenanceRecords.ToListAsync();
        }

        public async Task<MaintenanceRecord?> GetMaintenanceRecordByIdAsync(int id)
        {
            return await _context.MaintenanceRecords.FindAsync(id);
        }

        public async Task<MaintenanceRecord> CreateMaintenanceRecordAsync(MaintenanceRecord maintenanceRecord)
        {
            _context.MaintenanceRecords.Add(maintenanceRecord);
            await _context.SaveChangesAsync();
            return maintenanceRecord;
        }

        public async Task<MaintenanceRecord?> UpdateMaintenanceRecordAsync(int id, MaintenanceRecord maintenanceRecord)
        {
            var existingMaintenanceRecord = await _context.MaintenanceRecords.FindAsync(id);
            if (existingMaintenanceRecord == null)
            {
                return null;
            }

            existingMaintenanceRecord.MaintenanceDate = maintenanceRecord.MaintenanceDate;
            existingMaintenanceRecord.Details = maintenanceRecord.Details;

            await _context.SaveChangesAsync();
            return existingMaintenanceRecord;
        }

        public async Task<bool> DeleteMaintenanceRecordAsync(int id)
        {
            var maintenanceRecord = await _context.MaintenanceRecords.FindAsync(id);
            if (maintenanceRecord == null)
            {
                return false;
            }

            _context.MaintenanceRecords.Remove(maintenanceRecord);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

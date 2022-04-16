using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using FitnessConsole.CORE.Entities;
using FitnessConsole.Infrastructure.Storage;

namespace FitnessConsole.Infrastructure.REPOSITORIES
{
    public class AttendanceRepository
    {
        private readonly JsonStorage<Attendance> _jsonStorage;

        public AttendanceRepository(JsonStorage<Attendance> jsonStorage)
        {
            _jsonStorage = jsonStorage;
        }

        public async Task<IEnumerable<Attendance>> GetAttendanceByDate(DateTime date)
        {
            IEnumerable<Attendance> allAttendances = await _jsonStorage.GetAllAsync();
            return allAttendances.Where(at => at.Date == date);
        }

    }
}
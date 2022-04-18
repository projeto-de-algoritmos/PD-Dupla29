using FitnessConsole.CORE.Entities;
using FitnessConsole.Infrastructure.REPOSITORIES;
using FitnessConsole.SERVICES;

namespace FitnessConsole.Services
{
    public class AttendanceService
    {
        private readonly AttendanceRepository _attendanceRepository;
        private readonly WeightIntervalScheduling _weightIntervalScheduling;

        public AttendanceService(AttendanceRepository attendanceRepository, WeightIntervalScheduling weightIntervalScheduling)
        {
            _attendanceRepository = attendanceRepository;
            _weightIntervalScheduling = weightIntervalScheduling;
        }

        public async Task<DaySchedule> GetDateSchedule(DateTime date)
        {
            try
            {
                List<Attendance> listAttendance= (await _attendanceRepository.GetAttendanceByDate(date))
                    .OrderBy(at=>at.EndTime)
                    .ToList();
                DaySchedule daySchedule = _weightIntervalScheduling.GetDaySchedule(listAttendance);
                return daySchedule;   
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }
    }
}
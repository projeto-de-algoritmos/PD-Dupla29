using FitnessConsole.CORE.Entities;
using FitnessConsole.Infrastructure.REPOSITORIES;

namespace FitnessConsole.Services
{
    public class AttendanceService
    {
        private readonly AttendanceRepository _attendanceRepository;

        public AttendanceService(AttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }

        public async Task<DaySchedule> GetDateSchedule(DateTime date)
        {
            List<Attendance> listAttendance= (await _attendanceRepository.GetAttendanceByDate(date)).ToList();
            
            DaySchedule daySchedule = GetDaySchedule(listAttendance);
            return daySchedule;
            
        }

        //Podera derivar em outra classe 
        private DaySchedule GetDaySchedule(List<Attendance> listAttendance)
        {
            throw new NotImplementedException();
        }
    }
}
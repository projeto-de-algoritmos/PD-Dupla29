using FitnessConsole.Services;

namespace FitnessConsole.App
{
    public class AppConsole
    {
        private readonly AttendanceService _attendanceService;

        public AppConsole(AttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }
    
        public async Task GetDayScheduleAsync()
        {
            try
            {
                Console.WriteLine($"Digite o dia para os atendimentos: ");
                var inputDate = Console.ReadLine();
                var date = DateTime.Parse(inputDate);
                await _attendanceService.GetDateSchedule(date);
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }
    
    }
}
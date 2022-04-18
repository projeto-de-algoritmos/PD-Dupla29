using FitnessConsole.Services;
using FitnessConsole.CORE.Entities;


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
                DaySchedule daySchedule = await _attendanceService.GetDateSchedule(date);
                Console.WriteLine($"\nAgenda para o dia {inputDate}: ");
                Console.Write($"{daySchedule.ToString()}");
                
                
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }
    
    }
}
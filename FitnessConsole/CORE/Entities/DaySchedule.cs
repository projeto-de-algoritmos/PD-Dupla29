namespace FitnessConsole.CORE.Entities
{
    public class DaySchedule
    {
        public List<Attendance> RequestAttendance { get; set; } = new List<Attendance>();
        public List<Attendance> AprovedAttendance { get; set; } = new List<Attendance>();        
    }
}
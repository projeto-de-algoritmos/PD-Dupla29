namespace FitnessConsole.CORE.Entities
{
    public class Attendance
    {
        public decimal TotalValue { get;  set; }
        public string UserEmail { get;  set; }
        public DateTime StartTime { get;  set; }
        public DateTime EndTime { get;  set; }
        public DateTime Date { get;  set; } 
    }
}
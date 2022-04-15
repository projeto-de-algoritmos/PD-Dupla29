namespace FitnessConsole.CORE.Entities
{
    public class Attendance
    {
        public decimal TotalValue { get; private set; }
        public string UserEmail { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public DateTime Date { get; private set; } 
    }
}
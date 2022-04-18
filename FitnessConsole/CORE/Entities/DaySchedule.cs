namespace FitnessConsole.CORE.Entities
{
    public class DaySchedule
    {
        public decimal DayMaxValue { get; set; }
        public List<Attendance> AprovedAttendance { get; set; }

        public DaySchedule(decimal dayMaxValue, List<Attendance> aprovedAttendance)
        {
            DayMaxValue = dayMaxValue;
            AprovedAttendance = aprovedAttendance;
        }

        public override string ToString()
        {
            string text = $"\nFaturamento : {DayMaxValue.ToString("C")}\n";
            AprovedAttendance.ForEach(at => text += at.ToString() );
            return text;
        }
    }
}
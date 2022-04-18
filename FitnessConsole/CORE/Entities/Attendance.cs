namespace FitnessConsole.CORE.Entities
{
    public class Attendance
    {
        public decimal TotalValue { get;  set; }
        public string UserEmail { get;  set; }
        public DateTime StartTime { get;  set; }
        public DateTime EndTime { get;  set; }
        public DateTime Date { get;  set; } 

        public override string ToString()
        {
            string text = $" Cliente: {UserEmail}\n";
            text += $" Pagamento: {TotalValue.ToString("C")}\n";
            text += $" Data: {Date.ToShortDateString()}\n";            
            text += $" Inicio: {StartTime.ToShortTimeString()}\n";
            text += $" Termino: {EndTime.ToShortTimeString()}\n\n";            
            return text;
        }
    }
}
using FitnessConsole.CORE.Entities;

namespace FitnessConsole.SERVICES
{
    public class WeightIntervalScheduling
    {
        private List<Attendance> _listAttendance;
        private List<decimal?> _M;
        private List<Attendance> _Solution = new List<Attendance>();
        private decimal _MaxValue;
        public DaySchedule GetDaySchedule(List<Attendance> listAttendance)
        {
            try
            {    
                _listAttendance= listAttendance;
                _MaxValue = GetMaxValue();
                Find_Solution(_listAttendance.Count);
                //todo Create DaySchedule 
                return new DaySchedule(_MaxValue,_Solution);
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }
        public void Find_Solution(int index)
        {
            if(index == 0)
                return;
            if(_listAttendance[index-1].TotalValue + _M[P(index)] > _M[index - 1] )
            {
                _Solution.Add(_listAttendance[index-1]);
                Find_Solution(P(index));
            }
            else
                Find_Solution(index-1);
            

        }
        private decimal GetMaxValue()
        {
            try
            {
                _M = new List<decimal?>();
                _M.Add(0);
                for(int i = 1; i <= _listAttendance.Count ; i++)
                {
                    _M.Add(null);
                }
                return M_Compute_Opt(_listAttendance.Count); 
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }
        private decimal M_Compute_Opt(int index)
        {
            try
            {    
                if(_M[index]==null)
                    _M[index] = Math.Max(_listAttendance[index-1].TotalValue + M_Compute_Opt(P(index)),M_Compute_Opt(index-1));
                return _M[index].Value;
            }
            catch (System.Exception ex)
            {
                throw;
            }        
        }
        private int P(int indexAttendance)
        {
            try
            {    
                Attendance attendance = _listAttendance[indexAttendance - 1];
                List<Attendance> remainingList = _listAttendance.Take(indexAttendance).ToList();
                int index = _listAttendance.IndexOf(
                    _listAttendance
                    .SingleOrDefault(at=>at.EndTime <= attendance.StartTime)
                    ) ;
                return index == -1? 0 : index +1;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }
    }
}
using System;
using TimeKeepingDataCode;
using TimeKeepingDataCode.Biometrics;

namespace TimeKeepingCode.Code
{
    public class Schedule
    {
        public string ScheduleType { get; private set; }
        public string ShiftingName { get; private set; }
        public string ShiftingType { get; private set; }
        public FilterClause<TimeSpan> AmIn { get; private set; }
        public FilterClause<TimeSpan> LunchOut { get; private set; }
        public FilterClause<TimeSpan> LunchIn { get; private set; }
        public FilterClause<TimeSpan> CoffeeOut { get; private set; }
        public FilterClause<TimeSpan> CoffeeIn { get; private set; }
        public FilterClause<TimeSpan> PmOut { get; private set; }
        public int Lunchtime { get; private set; }
        public int Breaktime { get; private set; }
        public bool IsFixed { get; private set; }

        public ShiftingSchedule LoadedShifting { get; private set; }

        public Schedule(ShiftingSchedule schedule)
        {
            this.LoadedShifting = schedule;
            LoadDetails(schedule);
        }

        private void LoadDetails(ShiftingSchedule schedule) 
        {
            if (schedule != null)
            {
                TimeKeepingDataCode.Biometrics.ScheduleType type =
                    TimeKeepingCode.Program.ScheduleType.Find(t => t.Id == schedule.ScheduleType);

                TimeKeepingDataCode.Biometrics.ShiftingType sh = 
                    TimeKeepingCode.Program.ShiftingTypes.Find(s => s.Pk == schedule.ShiftingType);

                this.ScheduleType = type != null ? type.ScheduleName : string.Empty;
                this.ShiftingName = schedule.ShiftingName;
                this.ShiftingType = sh != null ? sh.ShiftType : string.Empty;
                this.AmIn = new FilterClause<TimeSpan>(schedule.AMIn);
                this.PmOut = new FilterClause<TimeSpan>(schedule.PmOut);
                this.Lunchtime = schedule.Lunchtime;
                this.Breaktime = schedule.Breaktime;
                this.IsFixed = schedule.IsFixed;

                if (type != null) 
                {
                    if (type.Id == 1)
                    {
                        this.LunchOut = new FilterClause<TimeSpan>(schedule.LunchOut);
                        this.LunchIn = new FilterClause<TimeSpan>(schedule.LunchIn);
                        this.CoffeeOut = new FilterClause<TimeSpan>(schedule.CoffeeOut);
                        this.CoffeeIn = new FilterClause<TimeSpan>(schedule.CoffeeIn);
                    }
                    else if (type.Id == 2)
                    {
                        this.CoffeeOut = new FilterClause<TimeSpan>(schedule.CoffeeOut);
                        this.CoffeeIn = new FilterClause<TimeSpan>(schedule.CoffeeIn);
                    }
                    else if (type.Id == 3)
                    {
                        this.LunchOut = new FilterClause<TimeSpan>(schedule.LunchOut);
                        this.LunchIn = new FilterClause<TimeSpan>(schedule.LunchIn);
                    }
                }
            }
        }

        public static Schedule Empty {
            get { return new Schedule(null); }
        }

        public static bool IsEmptyNull(Schedule schedule) {
            return schedule == null || schedule == Schedule.Empty;
        }
    }
}

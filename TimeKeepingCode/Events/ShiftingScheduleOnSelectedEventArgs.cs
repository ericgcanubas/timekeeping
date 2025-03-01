using System;

namespace TimeKeepingCode.Events
{
    public class ShiftingScheduleOnSelectedEventArgs : EventArgs
    {
        public TimeKeepingDataCode.Biometrics.ShiftingSchedule Selected { get; private set; }

        public ShiftingScheduleOnSelectedEventArgs(TimeKeepingDataCode.Biometrics.ShiftingSchedule shifting)
        {
            this.Selected = shifting;
        }
    }
}

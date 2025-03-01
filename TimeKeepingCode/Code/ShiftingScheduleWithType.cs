using TimeKeepingDataCode.Biometrics;

namespace TimeKeepingCode.Code
{
    public class ShiftingScheduleWithType
    {
        public string ShiftingType { get; private set; }
        public ShiftingSchedule Shifting { get; private set; }
        public string ShiftingName { get { return this.Shifting.ShiftingName; } }
        public string Fullname { get { return this.ShiftingType + " - " + this.ShiftingName; } }

        public ShiftingScheduleWithType(string shiftType,ShiftingSchedule schedule)
        {
            this.ShiftingType = shiftType;
            this.Shifting = schedule;
        }
    }
}

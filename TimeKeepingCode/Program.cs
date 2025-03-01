using System.Collections.Generic;
using System.Threading.Tasks;
using TimeKeepingDataCode;
using TimeKeepingDataCode.Biometrics;
using TimeKeepingDataCode.PayrollSystem;

namespace TimeKeepingCode
{
    public static class Program
    {
        public static Connection PayrollConnection { get; set; }
        public static Connection BiometricsConnection { get; set; }

        public static void LoadData() 
        {
            Task.Factory.StartNew(() => {
                ActiveEmployees = BasicEmployeeInfo.GetActiveEmployees(PayrollConnection);
            });

            Task.Factory.StartNew(() => {
                InactiveEmployees = BasicEmployeeInfo.GetInactiveEmployees(PayrollConnection);
            });

            Task.Factory.StartNew(() => {
                ScheduleType = TimeKeepingDataCode.Biometrics.ScheduleType.GetScheduleTypes(BiometricsConnection);
            });

            Task.Factory.StartNew(() => {
                ShiftingSchedule = TimeKeepingDataCode.Biometrics.ShiftingSchedule.GetSchedules(BiometricsConnection);
            });

            Task.Factory.StartNew(() => {
                ShiftingTypes = TimeKeepingDataCode.Biometrics.ShiftingType.GetShiftingTypes(BiometricsConnection);
            });
        }

        public static List<BasicEmployeeInfo> ActiveEmployees { get; private set; }
        public static List<BasicEmployeeInfo> InactiveEmployees { get; private set; }

        public static List<ScheduleType> ScheduleType { get; private set; }
        public static List<ShiftingSchedule> ShiftingSchedule { get; private set; }
        public static List<ShiftingType> ShiftingTypes { get; private set; }

        public static System.DateTime DefaultDate { get { return new System.DateTime(1901, 01, 01); } }

        public static void ResetShiftingSchedule() {
            System.Threading.Tasks.Task.Factory.StartNew(() => {
                ShiftingSchedule = TimeKeepingDataCode.Biometrics.ShiftingSchedule.GetSchedules(BiometricsConnection);
            });
        }

        public static Users User { get; set; }
    }
}

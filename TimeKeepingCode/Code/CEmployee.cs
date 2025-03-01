
namespace TimeKeepingCode.Code
{
    public class CEmployee
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string IdNumber { get; set; }
        public bool IsScheduled { get; set; }

        public CEmployee(int id,string fullname,bool isSceduled,string idNumber)
        {
            this.Id = id;
            this.Fullname = fullname;
            this.IsScheduled = isSceduled;
            this.IdNumber = idNumber;
        }

        public CEmployee(TimeKeepingDataCode.PayrollSystem.BasicEmployeeInfo employee, bool isScheduled) {
            this.Id = employee.PkId;
            this.Fullname = employee.Fullname;
            this.IsScheduled = isScheduled;
            this.IdNumber = employee.IdNumber;
        }
    }
}

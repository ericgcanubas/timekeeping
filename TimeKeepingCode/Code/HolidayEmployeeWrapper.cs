using System.Collections.Generic;

namespace TimeKeepingCode.Code
{
    public class HolidayEmployeeWrapper
    {
        public bool IsDuty { get; set; }
        public string Fullname { get; set; }
        public int EmpNo { get; set; }
        public string Division { get; set; }
        public string Department { get; set; }
        public string Section { get; set; }
        public string Position { get; set; }
        public int DivisionId { get; set; }
        public int DepartmentId { get; set; }
        public int SectionId { get; set; }
        public int PositionId { get; set; }

        public HolidayEmployeeWrapper(bool isDuty,string fullname,int empNo,
            string division,string department,string section,string position,
            int divisionId,int departmentId,int sectionId,int positionId)
        {
            this.IsDuty = isDuty;
            this.Fullname = fullname;
            this.EmpNo = empNo;
            this.Division = division;
            this.Department = department;
            this.Section = section;
            this.Position = position;
            this.DivisionId = divisionId;
            this.DepartmentId = departmentId;
            this.SectionId = sectionId;
            this.PositionId = positionId;
        }

        public HolidayEmployeeWrapper(TimeKeepingDataCode.PayrollSystem.BasicEmployeeInfo employee)
        {
            this.IsDuty = false;
            this.Fullname = employee.Fullname;
            this.EmpNo = employee.PkId;
            this.Division = employee.Division;
            this.Department = employee.Department;
            this.Section = employee.Section;
            this.Position = employee.Position;
            this.DivisionId = employee.DivisionId;
            this.DepartmentId = employee.DepartmentId;
            this.SectionId = employee.SectionId;
            this.PositionId = employee.PositionId;
        }

        public static List<HolidayEmployeeWrapper> Convert(List<TimeKeepingDataCode.PayrollSystem.BasicEmployeeInfo> employees) 
        {
            List<HolidayEmployeeWrapper> result = new List<HolidayEmployeeWrapper>();
            for (int i = 0; i < employees.Count; i++)
            {
                result.Add(new HolidayEmployeeWrapper(employees[i]));
            }
            return result;
        }
    }
}

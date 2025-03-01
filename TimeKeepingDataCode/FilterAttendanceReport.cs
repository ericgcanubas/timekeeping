using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeKeepingDataCode
{
    public class FilterAttendanceReport
    {
        public string Type { get; private set; }
        public int AreaId { get; private set; }
        public int DepartmentId { get; private set; }
        public int SectionId { get; private set; }
        public int PositionId { get; private set; }
        public int EmpId { get; private set; }

        public FilterAttendanceReport(string type,int areaId,int departmentId,
            int sectionId,int positionId,int empId)
        {
            this.Type = type;
            this.AreaId = areaId;
            this.DepartmentId = departmentId;
            this.SectionId = sectionId;
            this.PositionId = positionId;
            this.EmpId = empId;
        }
    }
}

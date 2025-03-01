using System;
using System.Collections.Generic;

namespace TimeKeepingDataCode.Biometrics
{
    public class HolidayEmployees
    {
        public int HolidayEmployeesPk { get; set; }
        public int HolidaNamePk { get; set; }
        public int EmployeeId { get; set; }
        public bool IsHolidayDuty { get; set; }
        public string Fullname { get; set; }
        public string Position { get; set; }
        public string Section { get; set; }
        public string Department { get; set; }
        public string Division { get; set; }
        public int PositionId { get; set; }
        public int SectionId { get; set; }
        public int DepartmentId { get; set; }
        public int DivisionId { get; set; }

        public HolidayEmployees(int holidayEmployeesPk,int holidaNamePk,
            int employeeId,bool isHolidayDuty,string fullname,string position,
            string section,string department,string division,int positionId,
            int sectionId,int departmentId,int divisionId)
        {
            this.HolidayEmployeesPk = holidayEmployeesPk;
            this.HolidaNamePk = holidaNamePk;
            this.EmployeeId = employeeId;
            this.IsHolidayDuty = isHolidayDuty;
            this.Fullname = fullname;
            this.Position = position;
            this.Section = section;
            this.Department = department;
            this.Division = division;
            this.PositionId = positionId;
            this.SectionId = sectionId;
            this.DepartmentId = departmentId;
            this.DivisionId = divisionId;
        }

        public HolidayEmployees(int holidayEmployeePk,int holidayNamePk,PayrollSystem.BasicEmployeeInfo employee,bool isHolidayDuty)
        {
            this.HolidayEmployeesPk = holidayEmployeePk;
            this.HolidaNamePk = holidayNamePk;
            this.IsHolidayDuty = isHolidayDuty;
            this.EmployeeId = employee.PkId;
            this.Fullname = employee.Fullname;
            this.Position = employee.Position;
            this.Section = employee.Section;
            this.Department = employee.Department;
            this.Division = employee.Division;
            this.PositionId = employee.PositionId;
            this.SectionId = employee.SectionId;
            this.DepartmentId = employee.DepartmentId;
            this.DivisionId = employee.DivisionId;
        }

        public HolidayEmployees(HolidayEmployees employee, int holidayNamePk, bool isHolidayDuty) 
        {
            this.HolidayEmployeesPk = employee.HolidayEmployeesPk;
            this.HolidaNamePk = holidayNamePk;
            this.IsHolidayDuty = isHolidayDuty;
            this.EmployeeId = employee.EmployeeId;
            this.Fullname = employee.Fullname;
            this.Position = employee.Position;
            this.Section = employee.Section;
            this.Department = employee.Department;
            this.Division = employee.Division;
            this.PositionId = employee.PositionId;
            this.SectionId = employee.SectionId;
            this.DepartmentId = employee.DepartmentId;
            this.DivisionId = employee.DivisionId;
        }

        public static List<HolidayEmployees> Convert(List<PayrollSystem.BasicEmployeeInfo> employees) 
        {
            List<HolidayEmployees> result = new List<HolidayEmployees>();
            for (int i = 0; i < employees.Count; i++)
            {
                result.Add(new HolidayEmployees(0,0,employees[i],false));
            }
            return result;
        }

        public static List<HolidayEmployees> GetAllHolidayEmployees(Connection connection) 
        {
            return GetDatas(connection,QueryFilter(new FilterClause<int>(),new FilterClause<int>(),new FilterClause<int>()));
        }

        public static List<HolidayEmployees> GetAllHolidayEmployees(Connection connection,int empPk) 
        {
            return GetDatas(connection, QueryFilter(new FilterClause<int>(), new FilterClause<int>(empPk),new FilterClause<int>()));
        }

        public static List<HolidayEmployees> GetAllHolidayEmployeesByHolidayName(Connection connection,int holidayNamePk) 
        {
            return GetDatas(connection, QueryFilter(new FilterClause<int>(), new FilterClause<int>(), new FilterClause<int>(holidayNamePk)));
        }

        public static HolidayEmployees GetHolidayEmployee(Connection connection,int id) 
        {
            return GetData(connection,QueryFilter(new FilterClause<int>(id),new FilterClause<int>(),new FilterClause<int>()));
        }

        private static string QueryFilter(FilterClause<int> id,FilterClause<int> employeePk, FilterClause<int> holidayNamePk) 
        {
            string idWhereClause = string.Empty;
            string employeePkWhereClause = string.Empty;
            string holidayNamePkWhereClause = string.Empty;

            if (id.IsFilter)
                idWhereClause = " and HolidayEmployeesPk = " + id.Value + " ";
            if (employeePk.IsFilter)
                employeePkWhereClause = " and EmpId = " + employeePk.Value + " ";
            if (holidayNamePk.IsFilter)
                holidayNamePkWhereClause = " and HolidayNamePk = " + holidayNamePk.Value + " ";

            string query = "select a.*,b.PPositionName,c.SSectionName,d.DDepartment,e.Description " +
                           "from ( " +
                               "SELECT a.HolidayEmployeesPk,a.HolidayNamePk,a.EmpId,a.IsHolidayDuty,b.EFullName, " +
                                      "Row = ROW_NUMBER() over (partition by a.EmpId order by c.PEffectivityDate desc), " +
                                      "c.PPosition,c.PDiv,c.PDept,c.PSection " +
                               "FROM tbl_HolidayEmployees a " +
                               "join PayrollSystem.dbo.tbl_Profile_IDNumber b " +
                                   "on a.EmpId = b.PK " +
                               "join PayrollSystem.dbo.tbl_Profile_Action c " +
                                   "on a.EmpId = c.PEmployeeNo " +
                               "where 1=1 " + idWhereClause + employeePkWhereClause + holidayNamePkWhereClause + " ) a " +
                           "left join PayrollSystem.dbo.PPositionName b " +
                               "on a.PPosition = b.PPositionIDNo " +
                           "left join PayrollSystem.dbo.SSection c " +
                               "on a.PSection = c.SSectionID " +
                           "left join PayrollSystem.dbo.DDepartmental d " +
                               "on a.PDept = d.DDepartmentsNo " +
                           "left join PayrollSystem.dbo.EEmployeeDiv e " +
                               "on a.PDiv = e.PK " +
                           "where a.Row = 1 ";
            return query;
        }

        private static List<HolidayEmployees> GetDatas(Connection connection,string query) 
        {
            List<HolidayEmployees> result = new List<HolidayEmployees>();
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result.Add(new HolidayEmployees(System.Convert.ToInt32(d.Rows[i]["HolidayEmployeesPk"]),
                   System.Convert.ToInt32(d.Rows[i]["HolidayNamePk"]), System.Convert.ToInt32(d.Rows[i]["EmpId"]),
                    System.Convert.ToBoolean(d.Rows[i]["IsHolidayDuty"]), d.Rows[i]["EFullName"].ToString(),
                    d.Rows[i]["PPositionName"].ToString(), d.Rows[i]["SSectionName"].ToString(),
                    d.Rows[i]["DDepartment"].ToString(), d.Rows[i]["Description"].ToString(),
                    System.Convert.ToInt32(d.Rows[i]["PPosition"]), System.Convert.ToInt32(d.Rows[i]["PSection"]),
                    System.Convert.ToInt32(d.Rows[i]["PDept"]), System.Convert.ToInt32(d.Rows[i]["PDiv"])));
            }
            return result;
        }

        private static HolidayEmployees GetData(Connection connection,string query) 
        {
            HolidayEmployees result = null;
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result = new HolidayEmployees(System.Convert.ToInt32(d.Rows[i]["HolidayEmployeesPk"]),
                    System.Convert.ToInt32(d.Rows[i]["HolidayNamePk"]), System.Convert.ToInt32(d.Rows[i]["EmpId"]),
                    System.Convert.ToBoolean(d.Rows[i]["IsHolidayDuty"]), d.Rows[i]["EFullName"].ToString(),
                    d.Rows[i]["PPositionName"].ToString(), d.Rows[i]["SSectionName"].ToString(),
                    d.Rows[i]["DDepartment"].ToString(), d.Rows[i]["Description"].ToString(),
                    System.Convert.ToInt32(d.Rows[i]["PPosition"]), System.Convert.ToInt32(d.Rows[i]["PSection"]),
                    System.Convert.ToInt32(d.Rows[i]["PDept"]), System.Convert.ToInt32(d.Rows[i]["PDiv"]));
            }
            return result;
        }

        public static bool IsEmployeeHoliday(Connection connection,DateTime date,int empId,out string holidayType) 
        {
            string query = "SELECT a.HolidayEmployeesPk,a.EmpId,a.IsHolidayDuty,b.HolidayType " +
                           "FROM tbl_HolidayEmployees a " +
                           "join dbo.tbl_HolidayName b on a.HolidayNamePk = b.HolidayNamePk " +
                           "where b.HolidayDate = '" + date.ToShortDateString() + "' and a.EmpId =" + empId + " and IsHolidayDuty = 0 ";
            var d = connection.GetData(query);

            if (d.Rows.Count > 0)
            {
                holidayType = d.Rows[0]["HolidayType"].ToString();
                return true;
            }
            else
            {
                holidayType = string.Empty;
                return false;
            }
        }

        public static int CheckHoliday(Connection connection,DateTime date,int empNo) 
        {
            /**
             * Legend 0=No Record,1=Holiday Duty,2=Holiday Not Duty
             **/
            string query = "select a.IsHolidayDuty,a.EmpId,b.HolidayDate " +
                           "from tbl_HolidayEmployees a " +
                           "join tbl_HolidayName b on a.HolidayNamePk = b.HolidayNamePk " +
                           "where b.HolidayDate = '" + date.ToShortDateString() + "' and a.EmpId = " + empNo + " ";

            var d = connection.GetData(query);
            if (d.Rows.Count > 0)
            {
                if (System.Convert.ToBoolean(d.Rows[0]["IsHolidayDuty"]))
                    return 1;
                else
                    return 0;
            }
            else {
                return 2;
            }
        }
    }
}

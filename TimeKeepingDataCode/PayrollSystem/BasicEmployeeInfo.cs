using System;
using System.Collections.Generic;

namespace TimeKeepingDataCode.PayrollSystem
{
    public class BasicEmployeeInfo
    {
        public int ProfileId { get; private set; }
        public string LastName { get; private set; }
        public string FirstName { get; private set; }
        public string MiddleName { get; private set; }
        public DateTime BirthDate { get; private set; }
        public int Age { get; private set; }
        public string CurrentAddress { get; private set; }
        public int PkId { get; private set; }
        public int PositionId { get; private set; }
        public int SectionId { get; private set; }
        public int DepartmentId { get; private set; }
        public int DivisionId { get; private set; }
        public int EmployeeStatusId { get; private set; }
        public int Active { get; private set; }
        public string Position { get; private set; }
        public string Section { get; private set; }
        public string Department { get; private set; }
        public string Division { get; private set; }
        public string Fullname { get; private set; }
        public string IdNumber { get; private set; }

        public BasicEmployeeInfo(int profileId,string lastname,string firstname,string middlename,
            DateTime birthdate,int age,string currentAddress,int pkId,int positionId,int sectionId,
            int departmentId,int divisionId,int employeeStatusId,int active,string position,
            string section,string department,string division,string idNumber)
        {
            this.ProfileId = profileId;
            this.LastName = lastname;
            this.FirstName = firstname;
            this.MiddleName = middlename;
            this.BirthDate = birthdate;
            this.Age = age;
            this.CurrentAddress = currentAddress;
            this.PkId = pkId;
            this.PositionId = positionId;
            this.SectionId = sectionId;
            this.DepartmentId = departmentId;
            this.DivisionId = divisionId;
            this.EmployeeStatusId = employeeStatusId;
            this.Active = active;
            this.Position = position;
            this.Section = section;
            this.Department = department;
            this.Division = division;
            this.Fullname = this.LastName + ", " + this.FirstName + " " + this.MiddleName;
            this.IdNumber = idNumber;
        }

        public override string ToString()
        {
            return this.Fullname;
        }

        public static List<BasicEmployeeInfo> GetActiveEmployees(Connection connection) 
        {
            return GetDatas(connection, QueryFilter(new FilterClause<int>(1),
                new FilterClause<string>(),new FilterClause<int>()));
        }

        public static List<BasicEmployeeInfo> GetInactiveEmployees(Connection connection)
        {
            return GetDatas(connection, QueryFilter(new FilterClause<int>(2),
                new FilterClause<string>(), new FilterClause<int>()));
        }

        public static List<BasicEmployeeInfo> SearchEmployeeByName(Connection connection,string lastname,int numRows) 
        {
            return GetDatas(connection,QueryFilter(new FilterClause<int>(),
                new FilterClause<string>(lastname), new FilterClause<int>(numRows)));
        }

        public static List<BasicEmployeeInfo> SearchActiveEmployeeByName(Connection connection, string lastname, int numRows)
        {
            return GetDatas(connection, QueryFilter(new FilterClause<int>(1),
                new FilterClause<string>(lastname), new FilterClause<int>(numRows)));
        }

        public static List<BasicEmployeeInfo> SearchInactiveEmployeeByName(Connection connection, string lastname, int numRows)
        {
            return GetDatas(connection, QueryFilter(new FilterClause<int>(2),
                new FilterClause<string>(lastname), new FilterClause<int>(numRows)));
        }

        private static string QueryFilter(FilterClause<int> isActive,FilterClause<string> searchName,
            FilterClause<int> topRowsInSearch) 
        {
            string isActiveWhereClause = string.Empty;
            string searchNameClause = string.Empty;
            string topRowsInSearchWhereClause = string.Empty;

            if (isActive.IsFilter)
            {
                if(isActive.Value != 0)
                    isActiveWhereClause = " and b.EActive = " + isActive.Value + " ";
            }

            if (searchName.IsFilter) 
                searchNameClause = " and (a.LastName + ', ' + a.FirstName) like '" + Connection.SqlString(searchName.Value) + "%' ";

            if (topRowsInSearch.IsFilter)
                topRowsInSearchWhereClause = " top " + topRowsInSearch.Value + " ";

            string query = "select " + topRowsInSearchWhereClause + " a.* ,isnull(b.PPositionName,'')Position, " +
                                  "isnull(c.SSectionName,'')Section, " +
                                  "isnull(d.DDepartment,'')Department,e.Description Division " +
                           "from ( " +
                               "select a.ProfileId,a.LastName,a.FirstName,a.MiddleName, " +
                                      "a.BirthDate,a.Age,a.CurrAddress,a.PkId,a.PPosition, " +
                                      "a.PSection,a.PDept,a.PDiv,a.PEmploymentStatus, " +
                                      "isnull(b.EActive,2)EActive,a.EEmployeeIDNo " +
                               "from ( " +
                                   "select a.PK ProfileId,a.LastName,a.FirstName,a.MiddleName, " +
                                       "a.BirthDate,a.Age,a.CurrAddress,b.PK PkId,c.PPosition, " +
                                       "c.PSection,c.PDept,c.PDiv,c.PEmploymentStatus,b.EEmployeeIDNo, " +
                                       "Row = ROW_NUMBER() over (partition by b.Pk order by c.PEffectivityDate desc) " +
                                   "from PayrollSystem.dbo.tbl_Profile a " +
                                   "join PayrollSystem.dbo.tbl_Profile_IDNumber b " +
                                       "on b.Pk = a.CurrentIDNumber " +
                                   "join PayrollSystem.dbo.tbl_Profile_Action c " +
                                       "on b.PK = c.PEmployeeNo ) a " +
                               "left join PayrollSystem.dbo.EEmploymentStatus b " +
                                   "on a.PEmploymentStatus = b.EEmploymentStatus " +
                               "where a.Row = 1 " + isActiveWhereClause + " ) a " +
                           "left join PayrollSystem.dbo.PPositionName b " +
                               "on a.PPosition = b.PPositionIDNo " +
                           "left join PayrollSystem.dbo.SSection c " +
                               "on a.PSection = c.SSectionID " +
                           "left join PayrollSystem.dbo.DDepartmental d " +
                               "on a.PDept = d.DDepartmentsNo " +
                           "left join PayrollSystem.dbo.EEmployeeDiv e " +
                               "on a.PDiv = e.PK " +
                           "where 1=1 " + searchNameClause;
            return query;
        }

        private static List<BasicEmployeeInfo> GetDatas(Connection connection,string query) 
        {
            List<BasicEmployeeInfo> result = new List<BasicEmployeeInfo>();
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result.Add(new BasicEmployeeInfo(Convert.ToInt32(d.Rows[i]["ProfileId"]),
                    d.Rows[i]["LastName"].ToString(), d.Rows[i]["FirstName"].ToString(), d.Rows[i]["MiddleName"].ToString(),
                    Convert.ToDateTime(d.Rows[i]["BirthDate"]), Convert.ToInt32(d.Rows[i]["Age"]),
                    d.Rows[i]["CurrAddress"].ToString(), Convert.ToInt32(d.Rows[i]["PkId"]),
                    Convert.ToInt32(d.Rows[i]["PPosition"]), Convert.ToInt32(d.Rows[i]["PSection"]),
                    Convert.ToInt32(d.Rows[i]["PDept"]), Convert.ToInt32(d.Rows[i]["PDiv"]),
                    Convert.ToInt32(d.Rows[i]["PEmploymentStatus"]), Convert.ToInt32(d.Rows[i]["EActive"]),
                    d.Rows[i]["Position"].ToString(),d.Rows[i]["Section"].ToString(),
                    d.Rows[i]["Department"].ToString(), d.Rows[i]["Division"].ToString(), d.Rows[i]["EEmployeeIDNo"].ToString()));
            }
            return result;
        }

        private static BasicEmployeeInfo GetData(Connection connection,string query) 
        {
            BasicEmployeeInfo result = null;
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result = new BasicEmployeeInfo(Convert.ToInt32(d.Rows[i]["ProfileId"]),
                    d.Rows[i]["LastName"].ToString(), d.Rows[i]["FirstName"].ToString(), d.Rows[i]["MiddleName"].ToString(),
                    Convert.ToDateTime(d.Rows[i]["BirthDate"]), Convert.ToInt32(d.Rows[i]["Age"]),
                    d.Rows[i]["CurrAddress"].ToString(), Convert.ToInt32(d.Rows[i]["PkId"]),
                    Convert.ToInt32(d.Rows[i]["PPosition"]), Convert.ToInt32(d.Rows[i]["PSection"]),
                    Convert.ToInt32(d.Rows[i]["PDept"]), Convert.ToInt32(d.Rows[i]["PDiv"]),
                    Convert.ToInt32(d.Rows[i]["PEmploymentStatus"]), Convert.ToInt32(d.Rows[i]["EActive"]),
                    d.Rows[i]["Position"].ToString(), d.Rows[i]["Section"].ToString(),
                    d.Rows[i]["Department"].ToString(), d.Rows[i]["Division"].ToString(), d.Rows[i]["EEmployeeIDNo"].ToString());
            }
            return result;
        }

        public static object GetImage(Connection connection,int empId) {
            object result = null;
            string query = "select Photo from tbl_Profile_Photo where EmployeePK =" + empId + " ";
            var resultData = connection.GetData(query);
            foreach (System.Data.DataRow row in resultData.Rows)
            {
                result = row["Photo"];
            }
            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeKeepingDataCode.Biometrics
{
    public class Holiday
    {
        public int CntrlId { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }
        public string EffectDates { get; set; }
        public string Remarks { get; set; }

        public Holiday(int cntrlId,DateTime dateCreated,string createdBy,
            string effectDates,string remarks)
        {
            this.CntrlId = cntrlId;
            this.DateCreated = dateCreated;
            this.CreatedBy = createdBy;
            this.EffectDates = effectDates;
            this.Remarks = remarks;
        }

        private static string QueryFilter() 
        {
            string query = "select HolidayCntrlId,DateCreated,CreatedBy, " +
	                              "Dates,Remarks " +
                           "from tbl_Holiday ";
            return query;
        }

        private static List<Holiday> GetDatas(Connection connection,string query) 
        {
            List<Holiday> result = new List<Holiday>();
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result.Add(new Holiday(Convert.ToInt32(d.Rows[i]["HolidayCntrlId"]), Convert.ToDateTime(d.Rows[i]["DateCreated"]),
                    d.Rows[i]["CreatedBy"].ToString(), d.Rows[i]["Dates"].ToString(), d.Rows[i]["Remarks"].ToString()));
            }
            return result;
        }

        private static Holiday GetData(Connection connection,string query) 
        {
            Holiday result = null;
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result = new Holiday(Convert.ToInt32(d.Rows[i]["HolidayCntrlId"]), Convert.ToDateTime(d.Rows[i]["DateCreated"]),
                    d.Rows[i]["CreatedBy"].ToString(), d.Rows[i]["Dates"].ToString(), d.Rows[i]["Remarks"].ToString());
            }
            return result;
        }

        public static List<Holiday> GetAllHolidays(Connection connection) 
        {
            return GetDatas(connection,QueryFilter());
        }

        public static bool CreateHoliday(Connection connection,Holiday holiday,
            List<HolidayName> holidaNames,List<HolidayEmployees> holidayEmployees) 
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("insert tbl_Holiday values ('" + Connection.SqlString(holiday.Remarks) + "','" + 
                Connection.SqlString(holiday.EffectDates) + "',GETDATE(),'" + Connection.SqlString(holiday.CreatedBy) + "') ");
            sb.Append("declare @id int = (select MAX(HolidayCntrlId) from tbl_Holiday) ");
            sb.Append("declare @holidayId int; ");

            for (int i = 0; i < holidaNames.Count; i++)
            {
                sb.Append("insert tbl_HolidayName values (@id,'" + Connection.SqlString(holidaNames[i].Description) + 
                    "','" + holidaNames[i].Date.ToShortDateString() + "','" + Connection.SqlString(holidaNames[i].Type) + "') ");

                sb.Append("set @holidayId = (select MAX(HolidayNamePk) from tbl_HolidayName) ");

                var employees = holidayEmployees.FindAll(e => e.HolidaNamePk == holidaNames[i].Pk);

                for (int a = 0; a < employees.Count; a++)
                {
                    sb.Append("insert tbl_HolidayEmployees values (@holidayId," + employees[a].EmployeeId + "," + Convert.ToInt32(employees[a].IsHolidayDuty) + ") ");
                }
            }

            return connection.Execute(sb.ToString());
        }

        public static bool UpdateHoliday(Connection connection,Holiday holiday,
            List<HolidayName> holidayNames,List<HolidayEmployees> holidayEmployees,
            List<HolidayName> newHolidayNames,List<HolidayEmployees> newHolidayEmployees) 
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("declare @holidayCntrlId int = " + holiday.CntrlId + "; ");

            sb.Append("update tbl_Holiday " +
                      "set Remarks = Remarks,Dates=Dates " +
                      "where HolidayCntrlId = @holidayCntrlId ");

            sb.Append("declare @tblHolidayEmployees table " +
                      "( " +
                          "HolidayEmployeesPk int, " +
                          "HolidayNamePk int, " +
                          "EmpId int, " +
                          "IsHolidayDuty bit " +
                      ") ");

            for (int i = 0; i < holidayEmployees.Count; i++)
            {
                sb.Append("insert @tblHolidayEmployees values " +
                          "(" + holidayEmployees[i].HolidayEmployeesPk + "," +
                          holidayEmployees[i].HolidaNamePk + "," + holidayEmployees[i].EmployeeId +
                          ",'" + holidayEmployees[i].IsHolidayDuty + "') ");
            }

            sb.Append("delete a " +
                      "from tbl_HolidayEmployees a " +
                      "join tbl_HolidayName b on a.HolidayNamePk = b.HolidayNamePk " +
                      "left join @tblHolidayEmployees c on  " +
                          "a.EmpId = c.EmpId and a.HolidayNamePk = c.HolidayNamePk " +
                      "where b.HolidayCntrlId = @holidayCntrlId " +
                          "and c.EmpId is null ");

            sb.Append("update a " +
                          "set a.IsHolidayDuty = b.IsHolidayDuty " +
                      "from tbl_HolidayEmployees a " +
                      "join @tblHolidayEmployees b on " +
                          "a.EmpId = b.EmpId and a.HolidayNamePk = b.HolidayNamePk ");

            sb.Append("insert tbl_HolidayEmployees " +
                      "select b.HolidayNamePk,b.EmpId,b.IsHolidayDuty " +
                      "from tbl_HolidayEmployees a " +
                      "right join @tblHolidayEmployees b on " +
                          "a.EmpId = b.EmpId and a.HolidayNamePk = b.HolidayNamePk " +
                      "where a.EmpId is null ");

            sb.Append("declare @tblHolidayName table " +
                      "( " +
	                      "HolidayNamePk int, " +
	                      "HolidayCntrlId int, " +
	                      "HolidayName varchar(100), " +
	                      "HolidayDate date, " +
	                      "HolidayType varchar(50) " +
                      ") ");

            for (int i = 0; i < holidayNames.Count; i++)
            {
                sb.Append("insert @tblHolidayName values (" + holidayNames[i].Pk + "," + holidayNames[i].CntrlId + ", " +
	                      "'" + Connection.SqlString(holidayNames[i].Description) + "','" + 
                          holidayNames[i].Date + "','" + Connection.SqlString(holidayNames[i].Type) + "') ");
            }

            sb.Append("delete a " +
                      "from tbl_HolidayName a " +
                      "left join @tblHolidayName b " +
	                      "on a.HolidayNamePk = b.HolidayNamePk " +
	                      "and a.HolidayCntrlId = b.HolidayCntrlId " +
                      "where a.HolidayCntrlId = @holidayCntrlId and b.HolidayCntrlId is null ");

            sb.Append("update a " +
                      "set a.HolidayDate =  b.HolidayDate, " +
	                      "a.HolidayName = b.HolidayName, " +
	                      "a.HolidayType = b.HolidayType " +
                      "from tbl_HolidayName a " +
                      "join @tblHolidayName b " +
	                      "on a.HolidayNamePk = b.HolidayNamePk " +
	                      "and a.HolidayCntrlId = b.HolidayCntrlId ");

            sb.Append("insert tbl_HolidayName " +
                      "select b.HolidayCntrlId, " +
	                       "b.HolidayName,b.HolidayDate,b.HolidayType " +
                      "from tbl_HolidayName a " +
                      "right join @tblHolidayName b " +
	                       "on a.HolidayNamePk = b.HolidayNamePk " +
	                       "and a.HolidayCntrlId = b.HolidayCntrlId " +
                      "where a.HolidayCntrlId is null ");

            sb.Append("declare @newHolidayNamePk int; ");
            for (int i = 0; i < newHolidayNames.Count; i++)
            {
                sb.Append("insert tbl_HolidayName values (@holidayCntrlId,'" + 
                    Connection.SqlString(newHolidayNames[i].Description) + "','" + 
                    newHolidayNames[i].Date + "','" + Connection.SqlString(newHolidayNames[i].Type) + "') " );

                sb.Append("select @newHolidayNamePk = MAX(HolidayNamePk) from tbl_HolidayName ");

                var employees = newHolidayEmployees.FindAll(e => e.HolidaNamePk == newHolidayNames[i].Pk);
                for (int a = 0; a < employees.Count; a++)
                {
                    sb.Append("insert tbl_HolidayEmployees values (@newHolidayNamePk," + 
                        newHolidayEmployees[a].EmployeeId + ",'" + newHolidayEmployees[a].IsHolidayDuty + "') ");
                }
            }

            return connection.Execute(sb.ToString());
        }

        public static bool DeleteHoliday(Connection connection,Holiday holiday)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete c " +
                      "from tbl_Holiday a " +
                      "join dbo.tbl_HolidayName b " +
	                      "on a.HolidayCntrlId = b.HolidayCntrlId " +
                      "join dbo.tbl_HolidayEmployees c " +
	                      "on b.HolidayNamePk = c.HolidayNamePk " +
                      "where a.HolidayCntrlId = " + holiday.CntrlId + " ");

            sb.Append("delete b " +
                      "from tbl_Holiday a " +
                      "join dbo.tbl_HolidayName b " +
	                      "on a.HolidayCntrlId = b.HolidayCntrlId " +
                      "where a.HolidayCntrlId = " + holiday.CntrlId + " ");

            sb.Append("delete a " +
                      "from tbl_Holiday a " +
                      "where a.HolidayCntrlId = " + holiday.CntrlId + " ");

            return connection.Execute(sb.ToString());
        }
    }
}

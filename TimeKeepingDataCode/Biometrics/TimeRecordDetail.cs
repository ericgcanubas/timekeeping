using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeKeepingDataCode.Biometrics
{
    public class TimeRecordDetail
    {
        public int Id { get; set; }
        public int EmpPk { get; set; }
        public DateTime ActualDate { get; set; }
        public int Line { get; set; }
        public DateTime BioTimeIn { get; set; }
        public DateTime ActualTimeIn { get; set; }
        public DateTime ShiftTimeIn { get; set; }
        public DateTime BioTimeOut { get; set; }
        public DateTime ActualTimeOut { get; set; }
        public DateTime ShiftTimeOut { get; set; }
        public double TotalHours { get; set; }
        public double Late { get; set; }
        public double Undertime { get; set; }
        public string Remarks { get; set; }
        public double NetHours { get; set; }

        public TimeRecordDetail(int id,int empPk,DateTime actualDate,int line,
            DateTime bioTimeIn,DateTime actualTimeIn,DateTime shiftTimeIn,
            DateTime bioTimeOut,DateTime actualTimeOut,DateTime shitTimeOut,
            double totalHours,double late,double undertime,string remarks,double netHours)
        {
            this.Id = id;
            this.EmpPk = empPk;
            this.ActualDate = actualDate;
            this.Line = line;
            this.BioTimeIn = bioTimeIn;
            this.ActualTimeIn = actualTimeIn;
            this.ShiftTimeIn = shiftTimeIn;
            this.BioTimeOut = bioTimeOut;
            this.ActualTimeOut = actualTimeOut;
            this.ShiftTimeOut = shitTimeOut;
            this.TotalHours = totalHours;
            this.Late = late;
            this.Undertime = undertime;
            this.Remarks = remarks;
            this.NetHours = netHours;
        }

        private static string QueryFilter(FilterClause<int> pk,FilterClause<int> empPk,FilterClause<DateTime> actualDate) 
        {
            string pkWhereClause = string.Empty;
            string empPkWhereClause = string.Empty;
            string actualDateWhereClause = string.Empty;

            if (pk.IsFilter)
                pkWhereClause = " and Pk = " + pk.Value + " ";
            if (empPk.IsFilter)
                empPkWhereClause = " and EmployeeKey = " + empPk.Value + " ";
            if (actualDate.IsFilter)
                actualDateWhereClause = " and Actual_Date = '" + actualDate.Value.ToShortDateString() + "' ";

            string query = "SELECT PK,EmployeeKey,Actual_Date,Line, " +
                                  "isnull(Bio_Time_In,'1901-01-01')Bio_Time_In, " +
                                  "isnull(Actual_Time_In,'1901-01-01')Actual_Time_In, " +
                                  "isnull(Shift_Time_In,'1901-01-01')Shift_Time_In, " +
                                  "isnull(Bio_Time_Out,'1901-01-01')Bio_Time_Out, " +
                                  "isnull(Actual_Time_Out,'1901-01-01')Actual_Time_Out, " +
                                  "isnull(Shift_Time_Out,'1901-01-01')Shift_Time_Out, " +
                                  "TotalHours,Late,Undertime,Remarks,isnull(NetHours,0)NetHours " +
                           "FROM tbl_TimeRecord_Detail " +
                           "where 1=1 " + pkWhereClause + empPkWhereClause + actualDateWhereClause;
            return query;
        }

        private static string QueryFilterLocked(FilterClause<int> pk, FilterClause<int> empPk, FilterClause<DateTime> actualDate)
        {
            string pkWhereClause = string.Empty;
            string empPkWhereClause = string.Empty;
            string actualDateWhereClause = string.Empty;

            if (pk.IsFilter)
                pkWhereClause = " and Pk = " + pk.Value + " ";
            if (empPk.IsFilter)
                empPkWhereClause = " and EmployeeKey = " + empPk.Value + " ";
            if (actualDate.IsFilter)
                actualDateWhereClause = " and Actual_Date = '" + actualDate.Value.ToShortDateString() + "' ";

            string query = "SELECT PK,EmployeeKey,Actual_Date,Line, " +
                                 "isnull(Bio_Time_In,'1901-01-01')Bio_Time_In, " +
                                 "isnull(Actual_Time_In,'1901-01-01')Actual_Time_In, " +
                                 "isnull(Shift_Time_In,'1901-01-01')Shift_Time_In, " +
                                 "isnull(Bio_Time_Out,'1901-01-01')Bio_Time_Out, " +
                                 "isnull(Actual_Time_Out,'1901-01-01')Actual_Time_Out, " +
                                 "isnull(Shift_Time_Out,'1901-01-01')Shift_Time_Out, " +
                                 "TotalHours,Late,Undertime,Remarks,isnull(NetHours,0)NetHours " +
                           "FROM tbl_TimeRecord_Locked_Detail " +
                           "where 1=1 " + pkWhereClause + empPkWhereClause + actualDateWhereClause;
            return query;
        }

        private static List<TimeRecordDetail> GetDatas(Connection connection,string query) 
        {
            List<TimeRecordDetail> result = new List<TimeRecordDetail>();
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result.Add(new TimeRecordDetail(Convert.ToInt32(d.Rows[i]["PK"]), Convert.ToInt32(d.Rows[i]["EmployeeKey"]),
                    Convert.ToDateTime(d.Rows[i]["Actual_Date"]), Convert.ToInt32(d.Rows[i]["Line"]),
                    Convert.ToDateTime(d.Rows[i]["Bio_Time_In"]), Convert.ToDateTime(d.Rows[i]["Actual_Time_In"]),
                    Convert.ToDateTime(d.Rows[i]["Shift_Time_In"]), Convert.ToDateTime(d.Rows[i]["Bio_Time_Out"]),
                    Convert.ToDateTime(d.Rows[i]["Actual_Time_Out"]), Convert.ToDateTime(d.Rows[i]["Shift_Time_Out"]),
                    Convert.ToDouble(d.Rows[i]["TotalHours"]), Convert.ToDouble(d.Rows[i]["Late"]),
                    Convert.ToDouble(d.Rows[i]["Undertime"]), d.Rows[i]["Remarks"].ToString(), 
                    Convert.ToDouble(d.Rows[i]["NetHours"])));
            }
            return result;
        }

        private static TimeRecordDetail GetData(Connection connection,string query)
        {
            TimeRecordDetail result = null;
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result = new TimeRecordDetail(Convert.ToInt32(d.Rows[i]["PK"]), Convert.ToInt32(d.Rows[i]["EmployeeKey"]),
                    Convert.ToDateTime(d.Rows[i]["Actual_Date"]), Convert.ToInt32(d.Rows[i]["Line"]),
                    Convert.ToDateTime(d.Rows[i]["Bio_Time_In"]), Convert.ToDateTime(d.Rows[i]["Actual_Time_In"]),
                    Convert.ToDateTime(d.Rows[i]["Shift_Time_In"]), Convert.ToDateTime(d.Rows[i]["Bio_Time_Out"]),
                    Convert.ToDateTime(d.Rows[i]["Actual_Time_Out"]), Convert.ToDateTime(d.Rows[i]["Shift_Time_Out"]),
                    Convert.ToDouble(d.Rows[i]["TotalHours"]), Convert.ToDouble(d.Rows[i]["Late"]),
                    Convert.ToDouble(d.Rows[i]["Undertime"]), d.Rows[i]["Remarks"].ToString(),
                    Convert.ToDouble(d.Rows[i]["NetHours"]));
            }
            return result;
        }

        public static List<TimeRecordDetail> GetAllTimeRecordDetail(Connection connection,int empPk,DateTime date) 
        {
            return GetDatas(connection,QueryFilter(new FilterClause<int>(),new FilterClause<int>(empPk),new FilterClause<DateTime>(date)));
        }

        public static List<TimeRecordDetail> GetAllLockedTimeRecordDetail(Connection connection, int empPk, DateTime date)
        {
            return GetDatas(connection, QueryFilterLocked(new FilterClause<int>(), new FilterClause<int>(empPk), new FilterClause<DateTime>(date)));
        }
    }
}

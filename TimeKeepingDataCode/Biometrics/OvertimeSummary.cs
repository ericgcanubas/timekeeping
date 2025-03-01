using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeKeepingDataCode.Biometrics
{
    public class OvertimeSummary
    {
        public int EmpNo { get; set; }
        public DateTime DateApplied { get; set; }
        public double Morning { get; set; }
        public double Evening { get; set; }
        public double TotalOvertime { get; set; }

        public OvertimeSummary(int empNo,DateTime dateApplied,
            double morning,double evening,double totalOvertime)
        {
            this.EmpNo = empNo;
            this.DateApplied = dateApplied;
            this.Morning = morning;
            this.Evening = evening;
            this.TotalOvertime = totalOvertime;
        }

        private static string QueryFilter(FilterClause<int> empNo,FilterClause<DateTime> dateApplied) 
        {
            string empNoWhereClause = string.Empty;
            string dateAppliedWhereClause = string.Empty;

            if (empNo.IsFilter)
                empNoWhereClause = " and EmpNo = " + empNo.Value + " ";
            if (dateApplied.IsFilter)
                dateAppliedWhereClause = " and DateApplied = '" + dateApplied.Value.ToShortDateString() + "' ";

            string query = "select EmpNo,DateApplied, " +
                                  "Morning,Evening,Total_Overtime " +
                           "from tbl_Overtime_Summary " +
                           "where 1=1 " + empNoWhereClause + dateAppliedWhereClause;
            return query;
        }

        private static List<OvertimeSummary> GetDatas(Connection connection,string query) 
        {
            List<OvertimeSummary> result = new List<OvertimeSummary>();
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result.Add(new OvertimeSummary(Convert.ToInt32(d.Rows[i]["EmpNo"]),
                    Convert.ToDateTime(d.Rows[i]["DateApplied"]), Convert.ToDouble(d.Rows[i]["Morning"]),
                    Convert.ToDouble(d.Rows[i]["Evening"]), Convert.ToDouble(d.Rows[i]["Total_Overtime"])));
            }
            return result;
        }

        private static OvertimeSummary GetData(Connection connection,string query) 
        {
            OvertimeSummary result = null;
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result = new OvertimeSummary(Convert.ToInt32(d.Rows[i]["EmpNo"]),
                    Convert.ToDateTime(d.Rows[i]["DateApplied"]), Convert.ToDouble(d.Rows[i]["Morning"]),
                    Convert.ToDouble(d.Rows[i]["Evening"]), Convert.ToDouble(d.Rows[i]["Total_Overtime"]));
            }
            return result;
        }

        public static List<OvertimeSummary> GetAllOverTimeSummaries(Connection connection) 
        {
            return GetDatas(connection,QueryFilter(new FilterClause<int>(),new FilterClause<DateTime>()));
        }

        public static List<OvertimeSummary> GetAllOverTimeSummaries(Connection connection,DateTime dateApplied)
        {
            return GetDatas(connection, QueryFilter(new FilterClause<int>(), new FilterClause<DateTime>(dateApplied)));
        }

        public static List<OvertimeSummary> GetAllOverTimeSummaries(Connection connection,int empNo)
        {
            return GetDatas(connection, QueryFilter(new FilterClause<int>(empNo), new FilterClause<DateTime>()));
        }

        public static OvertimeSummary GetOverTimeSummary(Connection connection,DateTime dateApplied,int empNo) 
        {
            return GetData(connection,QueryFilter(new FilterClause<int>(empNo),new FilterClause<DateTime>(dateApplied)));
        }
    }
}

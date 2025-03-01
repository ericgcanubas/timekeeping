using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeKeepingDataCode.PayrollSystem
{
    public class Period
    {
        public int PeriodNo { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

        public Period(int periodNo,DateTime dateFrom,DateTime dateTo)
        {
            this.PeriodNo = periodNo;
            this.DateFrom = dateFrom;
            this.DateTo = dateTo;
        }

        private static string QueryFilter(FilterClause<DateTime> dateFrom,FilterClause<DateTime> dateTo,FilterClause<int> periodNo) 
        {
            string dateFromWhereClause = string.Empty;
            string dateToWhereClause = string.Empty;
            string periodNoWhereClause = string.Empty;

            if (dateFrom.IsFilter)
                dateFromWhereClause = " and PDateFrom = '" + dateFrom.Value.ToShortDateString() + "' ";
            if (dateTo.IsFilter)
                dateToWhereClause = " and PDateTo = '" + dateTo.Value.ToShortDateString() + "' ";
            if (periodNo.IsFilter)
                periodNoWhereClause = " and PPeriodNo = " + periodNo.Value + " ";

            string query = "SELECT PPeriodNo,PDateFrom,PDateTo " +
                           "FROM PPeriod " +
                           "where 1=1 " + dateFromWhereClause + dateToWhereClause + periodNoWhereClause;

            return query;
        }

        private static List<Period> GetDatas(Connection connection,string query) 
        {
            List<Period> result = new List<Period>();
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result.Add(new Period(Convert.ToInt32(d.Rows[i]["PPeriodNo"]),
                    Convert.ToDateTime(d.Rows[i]["PDateFrom"]), Convert.ToDateTime(d.Rows[i]["PDateTo"])));
            }
            return result;
        }

        private static Period GetData(Connection connection,string query) 
        {
            Period result = null;
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result = new Period(Convert.ToInt32(d.Rows[i]["PPeriodNo"]),
                    Convert.ToDateTime(d.Rows[i]["PDateFrom"]), Convert.ToDateTime(d.Rows[i]["PDateTo"]));
            }
            return result;
        }

        public static List<Period> GetAllPeriods(Connection connection) 
        {
            return GetDatas(connection,QueryFilter(new FilterClause<DateTime>(),
                new FilterClause<DateTime>(),new FilterClause<int>()));
        }

        public static Period GetPeriod(Connection connection,int periodNo)
        {
            return GetData(connection,QueryFilter(new FilterClause<DateTime>(),
                new FilterClause<DateTime>(),new FilterClause<int>(periodNo)));
        }

        public static Period GetPeriod(Connection connection,DateTime dateFrom,DateTime dateTo) 
        {
            return GetData(connection,QueryFilter(new FilterClause<DateTime>(dateFrom),
                new FilterClause<DateTime>(dateTo),new FilterClause<int>()));
        }
    }
}

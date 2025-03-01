using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeKeepingDataCode.Biometrics
{
    public class TimeSummaryDetail
    {
        public int TimeKey { get; set; }
        public DateTime Date { get; set; }
        public string RegTime { get; set; }
        public double SH { get; set; }
        public double LH { get; set; }
        public double RD { get; set; }
        public double OT { get; set; }
        public double MidNight { get; set; }

        public TimeSummaryDetail(int timeKey,DateTime date,string regTime,
            double sh,double lh,double rd,double ot,double midNight)
        {
            this.TimeKey = timeKey;
            this.Date = date;
            this.RegTime = regTime;
            this.SH = sh;
            this.LH = lh;
            this.RD = rd;
            this.OT = ot;
            this.MidNight = midNight;
        }

        private static string QueryFilter(FilterClause<int> timeKey,FilterClause<DateTime> dDate) 
        {
            string timeKeyWhereClause = string.Empty;
            string dDateWhereClause = string.Empty;

            if (timeKey.IsFilter)
                timeKeyWhereClause = " and TimeKey = " + timeKey.Value + " ";
            if (dDate.IsFilter)
                dDateWhereClause = " and DDate = '" + dDate.Value.ToShortDateString() + "' ";

            string query = "SELECT TimeKey,DDate,isnull(RegTime,'')RegTime, " +
                                  "SH,LH,RD,OT,MidNight " +
                           "FROM Time_Summary_Det " +
                           "where 1=1 " + timeKeyWhereClause + dDateWhereClause;

            return query;
        }

        private static string QueryFilterLocked(FilterClause<int> timeKey, FilterClause<DateTime> dDate)
        {
            string timeKeyWhereClause = string.Empty;
            string dDateWhereClause = string.Empty;

            if (timeKey.IsFilter)
                timeKeyWhereClause = " and TimeKey = " + timeKey.Value + " ";
            if (dDate.IsFilter)
                dDateWhereClause = " and DDate = '" + dDate.Value.ToShortDateString() + "' ";

            string query = "SELECT TimeKey,DDate,isnull(RegTime,'')RegTime, " +
                                  "SH,LH,RD,OT,MidNight " +
                           "FROM Time_Summary_Locked_Det " +
                           "where 1=1 " + timeKeyWhereClause + dDateWhereClause;

            return query;
        }

        private static List<TimeSummaryDetail> GetDatas(Connection connection,string query) 
        {
            List<TimeSummaryDetail> result = new List<TimeSummaryDetail>();
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result.Add(new TimeSummaryDetail(Convert.ToInt32(d.Rows[i]["TimeKey"]),
                    Convert.ToDateTime(d.Rows[i]["DDate"]), d.Rows[i]["RegTime"].ToString(),
                    Convert.ToDouble(d.Rows[i]["SH"]), Convert.ToDouble(d.Rows[i]["LH"]),
                    Convert.ToDouble(d.Rows[i]["RD"]), Convert.ToDouble(d.Rows[i]["OT"]),
                    Convert.ToDouble(d.Rows[i]["MidNight"])));
            }
            return result;
        }

        private static TimeSummaryDetail GetData(Connection connection,string query) 
        {
            TimeSummaryDetail result = null;
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result = new TimeSummaryDetail(Convert.ToInt32(d.Rows[i]["TimeKey"]),
                    Convert.ToDateTime(d.Rows[i]["DDate"]), d.Rows[i]["RegTime"].ToString(),
                    Convert.ToDouble(d.Rows[i]["SH"]), Convert.ToDouble(d.Rows[i]["LH"]),
                    Convert.ToDouble(d.Rows[i]["RD"]), Convert.ToDouble(d.Rows[i]["OT"]),
                    Convert.ToDouble(d.Rows[i]["MidNight"]));
            }
            return result;
        }

        public static List<TimeSummaryDetail> GetAllTimeSummaryDetails(Connection connection) 
        {
            return GetDatas(connection,QueryFilter(new FilterClause<int>(),new FilterClause<DateTime>()));
        }

        public static List<TimeSummaryDetail> GetAllTimeSummaryDetails(Connection connection,int timeKey)
        {
            return GetDatas(connection, QueryFilter(new FilterClause<int>(timeKey), new FilterClause<DateTime>()));
        }


        public static List<TimeSummaryDetail> GetAllLockedTimeSummaryDetails(Connection connection)
        {
            return GetDatas(connection, QueryFilterLocked(new FilterClause<int>(), new FilterClause<DateTime>()));
        }

        public static List<TimeSummaryDetail> GetAllLockedTimeSummaryDetails(Connection connection, int timeKey)
        {
            return GetDatas(connection, QueryFilterLocked(new FilterClause<int>(timeKey), new FilterClause<DateTime>()));
        }

        public static bool DeleteTimeSummaryByKey(Connection connection,int key) 
        {
            string query = "delete Time_Summary_Det where TimeKey = " + key + " ";

            return connection.Execute(query);
        }

        public static bool InsertTimeSummaryDetail(Connection connection,int key,List<TimeSummaryDetail> details)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < details.Count; i++)
            {
                sb.Append("insert Time_Summary_Det values " +
                          "(" + key + ",'" + details[i].Date.ToShortDateString() + 
                          "','" + Connection.SqlString(details[i].RegTime) + 
                          "'," + details[i].SH + "," + details[i].LH + 
                          "," + details[i].RD + "," + details[i].OT + "," + details[i].MidNight + ") ");
            }

            return connection.Execute(sb.ToString());
        }
    }
}

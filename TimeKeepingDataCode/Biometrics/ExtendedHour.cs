using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeKeepingDataCode.Biometrics
{
    public class ExtendedHour
    {
        public int Pk { get; set; }
        public string Description { get; set; }
        public DateTime EffectDate { get; set; }
        public DateTime TimeOut { get; set; }
        public string LastModified { get; set; }
        public string TimeOutString { get { return this.TimeOut.ToString("hh:mm tt"); } }

        public ExtendedHour(int pk,string description,DateTime effectDate,
            DateTime timeOut,string lastModified)
        {
            this.Pk = pk;
            this.Description = description;
            this.EffectDate = effectDate;
            this.TimeOut = timeOut;
            this.LastModified = lastModified;
        }

        private static string QueryFilter() 
        {
            string query = "SELECT PK,sTitle,eDate,tTime,LastModified " +
                           "FROM tbl_Extended_Hour " +
                           "where 1=1 ";

            return query;
        }

        private static List<ExtendedHour> GetDatas(Connection connection,string query) 
        {
            List<ExtendedHour> result = new List<ExtendedHour>();
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result.Add(new ExtendedHour(Convert.ToInt32(d.Rows[i]["PK"]), d.Rows[i]["sTitle"].ToString(),
                    Convert.ToDateTime(d.Rows[i]["eDate"]), Convert.ToDateTime(d.Rows[i]["tTime"]),
                    d.Rows[i]["LastModified"].ToString()));
            }
            return result;
        }

        private static ExtendedHour GetData(Connection connection, string query) 
        {
            ExtendedHour result = null;
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result = new ExtendedHour(Convert.ToInt32(d.Rows[i]["PK"]), d.Rows[i]["sTitle"].ToString(),
                    Convert.ToDateTime(d.Rows[i]["eDate"]), Convert.ToDateTime(d.Rows[i]["tTime"]),
                    d.Rows[i]["LastModified"].ToString());
            }
            return result;
        }

        public static List<ExtendedHour> GetExtendedHours(Connection connection) 
        {
            return GetDatas(connection,QueryFilter());
        }

        public static bool CreateExtended(Connection connection,ExtendedHour extended) 
        {
            string query = "insert tbl_Extended_Hour values ('" + Connection.SqlString(extended.Description) + 
                "','" + extended.EffectDate.ToShortDateString() + "','" + extended.TimeOut + 
                "','" + Connection.SqlString(extended.LastModified) + "') ";

            return connection.Execute(query);
        }

        public static bool UpdateExtended(Connection connection,ExtendedHour extended) 
        {
            string query = "update tbl_Extended_Hour " +
                           "set sTitle='" + Connection.SqlString(extended.Description) + "',eDate='" + extended.EffectDate.ToShortDateString() + "', " +
	                           "tTime='" + extended.TimeOut + "',LastModified='" + Connection.SqlString(extended.LastModified) + "' " +
                           "where PK=PK ";

            return connection.Execute(query);
        }

        public static bool DeleteExtended(Connection connection,ExtendedHour extended) 
        {
            string query = "delete tbl_Extended_Hour where PK =" + extended.Pk + " ";
            return connection.Execute(query);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeKeepingDataCode.Biometrics
{
    public class MidNight
    {
        public int Pk { get; set; }
        public string Description { get; set; }
        public DateTime EffectDate { get; set; }
        public DateTime TimeOut { get; set; }
        public int Locked { get; set; }
        public string LastModified { get; set;}
        public string TimeOutString { get { return this.TimeOut.ToString("hh:mm tt"); } }

        public MidNight(int pk,string description,DateTime effectDate,
            DateTime timeOut,int locked,string lastModified)
        {
            this.Pk = pk;
            this.Description = description;
            this.EffectDate = effectDate;
            this.TimeOut = timeOut;
            this.Locked = locked;
            this.LastModified = lastModified;
        }


        private static string QueryFilter() 
        {
            string query = "SELECT PK,Description,EffectDate,TimeOut,Locked,LastModified " +
                           "FROM MidNight " +
                           "where 1=1 ";

            return query;
        }

        private static List<MidNight> GetDatas(Connection connection,string query) 
        {
            List<MidNight> result = new List<MidNight>();
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result.Add(new MidNight(Convert.ToInt32(d.Rows[i]["PK"]), d.Rows[i]["Description"].ToString(),
                    Convert.ToDateTime(d.Rows[i]["EffectDate"]), Convert.ToDateTime(d.Rows[i]["TimeOut"]),
                    Convert.ToInt32(d.Rows[i]["Locked"]), d.Rows[i]["LastModified"].ToString()));
            }
            return result;
        }

        private static MidNight GetData(Connection connection,string query) 
        {
            MidNight result = null;
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result = new MidNight(Convert.ToInt32(d.Rows[i]["PK"]), d.Rows[i]["Description"].ToString(),
                    Convert.ToDateTime(d.Rows[i]["EffectDate"]), Convert.ToDateTime(d.Rows[i]["TimeOut"]),
                    Convert.ToInt32(d.Rows[i]["Locked"]), d.Rows[i]["LastModified"].ToString());
            }
            return result;
        }

        public static List<MidNight> GetAllMidNight(Connection connection) 
        {
            return GetDatas(connection,QueryFilter());
        }

        public static bool CreateMidNight(Connection connection,MidNight midNight) 
        {
            string query = "insert MidNight values ('" + Connection.SqlString(midNight.Description) + 
                "','" + midNight.EffectDate.ToShortDateString() + "','" + midNight.TimeOut + "',0,'" + 
                Connection.SqlString(midNight.LastModified) + "') ";

            return connection.Execute(query);
        }

        public static bool UpdateMidNight(Connection connection,MidNight midNight) 
        {
            string query = "update MidNight " +
                           "set Description='" + Connection.SqlString(midNight.Description) + "',EffectDate='" + midNight.EffectDate.ToShortDateString() + "', " +
	                           "TimeOut='" + midNight.TimeOut + "',Locked=" + midNight.Locked + ",LastModified='" + Connection.SqlString(midNight.LastModified) + "' " +
                           "where PK=" + midNight.Pk + " ";
            return connection.Execute(query);
        }

        public static bool DeleteMidNight(Connection connection,MidNight midNight) 
        {
            string query = "delete MidNight where PK =" + midNight.Pk + " ";
            return connection.Execute(query);
        }
    }
}

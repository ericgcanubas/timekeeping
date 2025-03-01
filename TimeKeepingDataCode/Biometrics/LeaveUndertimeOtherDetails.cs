using System;
using System.Collections.Generic;

namespace TimeKeepingDataCode.Biometrics
{
    public class LeaveUndertimeOtherDetails
    {
        public int Id { get; set; }
        public string Restday { get; set; }
        public string Holiday { get; set; }
        public string Leave { get; set; }
        public string Description { get; set; }

        public LeaveUndertimeOtherDetails(int id,string restday,
            string holiday,string leave,string description)
        {
            this.Id = id;
            this.Restday = restday;
            this.Holiday = holiday;
            this.Leave = leave;
            this.Description = description;
        }

        public static List<LeaveUndertimeOtherDetails> GetAllLeaveUndertimeOtherDetails(Connection connection) 
        {
            return GetDatas(connection,QueryFilter(new FilterClause<int>()));
        }

        public static List<LeaveUndertimeOtherDetails> GetAllLeaveUndertimeOtherDetails(Connection connection,int id)
        {
            return GetDatas(connection, QueryFilter(new FilterClause<int>(id)));
        }

        private static string QueryFilter(FilterClause<int> id) 
        {
            string idWhereClause = string.Empty;

            if (id.IsFilter)
                idWhereClause = " and PkLeaveUndertime = " + id.Value + " ";

            string query = "SELECT PkLeaveUndertime,Restday, " +
                                  "Holiday,Leave,Description " +
                           "FROM tbl_leaveUndertime_OtherDetails " +
                           "where 1=1 " + idWhereClause;
            return query;
        }

        private static List<LeaveUndertimeOtherDetails> GetDatas(Connection connection,string query) 
        {
            List<LeaveUndertimeOtherDetails> result = new List<LeaveUndertimeOtherDetails>();
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result.Add(new LeaveUndertimeOtherDetails(Convert.ToInt32(d.Rows[i]["PkLeaveUndertime"]),
                    d.Rows[i]["Restday"].ToString(), d.Rows[i]["Holiday"].ToString(),
                    d.Rows[i]["Leave"].ToString(), d.Rows[i]["Description"].ToString()));
            }
            return result;
        }

        private static LeaveUndertimeOtherDetails GetData(Connection connection,string query) 
        {
            LeaveUndertimeOtherDetails result = null;
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result = new LeaveUndertimeOtherDetails(Convert.ToInt32(d.Rows[i]["PkLeaveUndertime"]),
                    d.Rows[i]["Restday"].ToString(), d.Rows[i]["Holiday"].ToString(),
                    d.Rows[i]["Leave"].ToString(), d.Rows[i]["Description"].ToString());
            }
            return result;
        }
    }
}

using System;
using System.Collections.Generic;

namespace TimeKeepingDataCode.Biometrics
{
    public class LeaveUndertimeDetails
    {
        public int Id { get; set; }
        public int LUId { get; set; }
        public int Line { get; set; }
        public string Description { get; set; }
        public string Total { get; set; }
        public string Month1 { get; set; }
        public string Month2 { get; set; }
        public string Month3 { get; set; }

        public LeaveUndertimeDetails(int id,int luId,int line,string description,
            string total,string month1,string month2,string month3)
        {
            this.Id = id;
            this.LUId = luId;
            this.Line = line;
            this.Description = description;
            this.Total = total;
            this.Month1 = month1;
            this.Month2 = month2;
            this.Month3 = month3;
        }

        public static List<LeaveUndertimeDetails> GetLeaveUndertimeDetails(Connection connection) 
        {
            return GetDatas(connection,QueryFilter(new FilterClause<int>(),new FilterClause<int>(),new FilterClause<bool>()));
        }

        public static List<LeaveUndertimeDetails> GetLeaveUndertimeDetails(Connection connection,int luId) 
        {
            return GetDatas(connection,QueryFilter(new FilterClause<int>(),new FilterClause<int>(luId),new FilterClause<bool>(true)));
        }

        public static LeaveUndertimeDetails GetLeaveUndertimeDetail(Connection connection,int id) 
        {
            return GetData(connection,QueryFilter(new FilterClause<int>(id),new FilterClause<int>(),new FilterClause<bool>()));
        }

        private static string QueryFilter(FilterClause<int> id,FilterClause<int> luId,FilterClause<bool> isOrderBy) 
        {
            string idWhereClause = string.Empty;
            string luIdWhereClause = string.Empty;
            string isOrderbyWhereClause = string.Empty;

            if (id.IsFilter)
                idWhereClause = " and nID = " + luId.Value + " ";
            if(luId.IsFilter)
                luIdWhereClause = " and LU_nID = " + luId.Value + " ";
            if (isOrderBy.IsFilter)
                isOrderbyWhereClause = " order by nline";

            string query = "select nID,isnull(LU_nID,0)LU_nID,isnull(nLine,0)nLine, " +
                                  "isnull(sDesc,'')sDesc,isnull(sTotal,'')sTotal, " +
                                  "isnull(sMonth1,'')sMonth1,isnull(sMonth2,'')sMonth2, " +
                                  "isnull(sMonth3,'')sMonth3 " +
                           "from tbl_LEAVE_UNDERTIME_DETAILS " +
                           "where 1=1 " + idWhereClause + luIdWhereClause + isOrderbyWhereClause;
            return query;
        }

        private static List<LeaveUndertimeDetails> GetDatas(Connection connection,string query)
        {
            List<LeaveUndertimeDetails> result = new List<LeaveUndertimeDetails>();
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result.Add(new LeaveUndertimeDetails(Convert.ToInt32(d.Rows[i]["nID"]), Convert.ToInt32(d.Rows[i]["LU_nID"]),
                    Convert.ToInt32(d.Rows[i]["nLine"]), d.Rows[i]["sDesc"].ToString(), d.Rows[i]["sTotal"].ToString(),
                    d.Rows[i]["sMonth1"].ToString(), d.Rows[i]["sMonth2"].ToString(), d.Rows[i]["sMonth3"].ToString()));
            }
            return result;
        }

        private static LeaveUndertimeDetails GetData(Connection connection,string query) 
        {
            LeaveUndertimeDetails result = null;
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result = new LeaveUndertimeDetails(Convert.ToInt32(d.Rows[i]["nID"]), Convert.ToInt32(d.Rows[i]["LU_nID"]),
                    Convert.ToInt32(d.Rows[i]["nLine"]), d.Rows[i]["sDesc"].ToString(), d.Rows[i]["sTotal"].ToString(),
                    d.Rows[i]["sMonth1"].ToString(), d.Rows[i]["sMonth2"].ToString(), d.Rows[i]["sMonth3"].ToString());
            }
            return result;
        }
    }
}

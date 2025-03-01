using System;
using System.Collections.Generic;

namespace TimeKeepingDataCode.Biometrics
{
    public class ChangeRestdayDetails
    {
        public int Id { get; set; }
        public int CId { get; set; }
        public int Line { get; set; }
        public string Description { get; set; }
        public string Total { get; set; }
        public string Month1 { get; set; }
        public string Month2 { get; set; }
        public string Month3 { get; set; }

        public ChangeRestdayDetails(int id,int cId,int line,string description,
            string total,string month1,string month2,string month3)
        {
            this.Id = id;
            this.CId = cId;
            this.Line = line;
            this.Description = description;
            this.Total = total;
            this.Month1 = month1;
            this.Month2 = month2;
            this.Month3 = month3;
        }

        public static List<ChangeRestdayDetails> GetAllChangeRestdays(Connection connection) 
        {
            return GetDatas(connection,QueryFilter(new FilterClause<int>(),new FilterClause<int>()));
        }

        public static List<ChangeRestdayDetails> GetAllChangeRestdays(Connection connection,int cId)
        {
            return GetDatas(connection, QueryFilter(new FilterClause<int>(), new FilterClause<int>(cId)));
        }

        public static ChangeRestdayDetails GetChangeRestday(Connection connection,int id) 
        {
            return GetData(connection,QueryFilter(new FilterClause<int>(id),new FilterClause<int>()));
        }

        private static string QueryFilter(FilterClause<int> id,FilterClause<int> cId) 
        {
            string idWhereClause = string.Empty;
            string cIdWhereClause = string.Empty;

            if (id.IsFilter)
                idWhereClause = " and nID = " + id.Value + " ";
            if (cId.IsFilter)
                cIdWhereClause = " and CD_nID = " + cId.Value + " ";

            string query = "SELECT nID,isnull(CD_nID,0)CD_nID,isnull(nLine,0)nLine, " +
                                  "isnull(sDesc,'')sDesc,isnull(sTotal,'')sTotal, " +
                                  "isnull(sMonth1,'')sMonth1,isnull(sMonth2,'')sMonth2, " +
                                  "isnull(sMonth3,'')sMonth3 " +
                           "FROM tbl_CHANGERESTDAY_DETAILS " +
                           "where 1=1 " + idWhereClause + cIdWhereClause;
            return query;
        }

        private static List<ChangeRestdayDetails> GetDatas(Connection connection,string query)
        {
            List<ChangeRestdayDetails> result = new List<ChangeRestdayDetails>();
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result.Add(new ChangeRestdayDetails(Convert.ToInt32(d.Rows[i]["nID"]),
                    Convert.ToInt32(d.Rows[i]["CD_nID"]), Convert.ToInt32(d.Rows[i]["nLine"]),
                    d.Rows[i]["sDesc"].ToString(), d.Rows[i]["sTotal"].ToString(),
                    d.Rows[i]["sMonth1"].ToString(), d.Rows[i]["sMonth2"].ToString(),
                    d.Rows[i]["sMonth3"].ToString()));
            }
            return result;
        }

        private static ChangeRestdayDetails GetData(Connection connection,string query) 
        {
            ChangeRestdayDetails result = null;
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result = new ChangeRestdayDetails(Convert.ToInt32(d.Rows[i]["nID"]),
                    Convert.ToInt32(d.Rows[i]["CD_nID"]), Convert.ToInt32(d.Rows[i]["nLine"]),
                    d.Rows[i]["sDesc"].ToString(), d.Rows[i]["sTotal"].ToString(),
                    d.Rows[i]["sMonth1"].ToString(), d.Rows[i]["sMonth2"].ToString(),
                    d.Rows[i]["sMonth3"].ToString());
            }
            return result;
        }
    }
}

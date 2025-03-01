using System;
using System.Collections.Generic;

namespace TimeKeepingDataCode.Biometrics
{
    public class PRWDetails
    {
        public int Id { get; set; }
        public int PRWId { get; set; }
        public int Line { get; set; }
        public string Type { get; set; }
        public string Month1 { get; set; }
        public string Month2 { get; set; }
        public string Month3 { get; set; }
        public string Month4 { get; set; }
        public string Month5 { get; set; }
        public string Month6 { get; set; }
        public string Total { get; set; }

        public PRWDetails(int id,int prwId,int line,string type,
            string month1,string month2,string month3,string month4,
            string month5, string month6,string total)
        {
            this.Id = id;
            this.PRWId = prwId;
            this.Line = line;
            this.Type = type;
            this.Month1 = month1;
            this.Month2 = month2;
            this.Month3 = month3;
            this.Month4 = month4;
            this.Month5 = month5;
            this.Month6 = month6;
            this.Total = total;
        }

        public static List<PRWDetails> GetAllPRWDetails(Connection connection) 
        {
            return GetDatas(connection,QueryFilter(new FilterClause<int>(),new FilterClause<int>()));
        }

        public static List<PRWDetails> GetAllPRWDetails(Connection connection,int prwId)
        {
            return GetDatas(connection, QueryFilter(new FilterClause<int>(), new FilterClause<int>(prwId)));
        }

        public static PRWDetails GetPRWDetail(Connection connection,int id) 
        {
            return GetData(connection,QueryFilter( new FilterClause<int>(id),new FilterClause<int>()));
        }

        private static string QueryFilter(FilterClause<int> id,FilterClause<int> prwId) 
        {
            string idWhereClause = string.Empty;
            string prwIdWhereClause = string.Empty;

            if (id.IsFilter)
                idWhereClause = " and nID = " + id.Value + " ";
            if (prwId.IsFilter)
                prwIdWhereClause = " and PRW_nID = " + prwId.Value + " ";

            string query = "SELECT nID,isnull(PRW_nID,0)PRW_nID,isnull(nLine,0)nLine, " +
                                  "isnull(sType,'')sType,isnull(sMonth1,'')sMonth1, " +
                                  "isnull(sMonth2,'')sMonth2,isnull(sMonth3,'')sMonth3, " +
                                  "isnull(sMonth4,'')sMonth4,isnull(sMonth5,'')sMonth5, " +
                                  "isnull(sMonth6,'')sMonth6,isnull(sTotal,'')sTotal " +
                           "FROM tbl_PRW_GRID " +
                           "where 1=1 " + idWhereClause + prwIdWhereClause;
            return query;
        }

        private static List<PRWDetails> GetDatas(Connection connection,string query) 
        {
            List<PRWDetails> result = new List<PRWDetails>();
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result.Add(new PRWDetails(Convert.ToInt32(d.Rows[i]["nID"]),Convert.ToInt32(d.Rows[i]["PRW_nID"]),
                    Convert.ToInt32(d.Rows[i]["nLine"]),d.Rows[i]["sType"].ToString(),
                    d.Rows[i]["sMonth1"].ToString(),d.Rows[i]["sMonth2"].ToString(),
                    d.Rows[i]["sMonth3"].ToString(),d.Rows[i]["sMonth4"].ToString(),
                    d.Rows[i]["sMonth5"].ToString(),d.Rows[i]["sMonth6"].ToString(),
                    d.Rows[i]["sTotal"].ToString()));
            }
            return result;
        }

        private static PRWDetails GetData(Connection connection,string query) 
        {
            PRWDetails result = null;
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result = new PRWDetails(Convert.ToInt32(d.Rows[i]["nID"]), Convert.ToInt32(d.Rows[i]["PRW_nID"]),
                    Convert.ToInt32(d.Rows[i]["nLine"]), d.Rows[i]["sType"].ToString(),
                    d.Rows[i]["sMonth1"].ToString(), d.Rows[i]["sMonth2"].ToString(),
                    d.Rows[i]["sMonth3"].ToString(), d.Rows[i]["sMonth4"].ToString(),
                    d.Rows[i]["sMonth5"].ToString(), d.Rows[i]["sMonth6"].ToString(),
                    d.Rows[i]["sTotal"].ToString());
            }
            return result;
        }
    }
}

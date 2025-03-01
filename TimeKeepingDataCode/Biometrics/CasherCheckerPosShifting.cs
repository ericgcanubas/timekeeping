using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeKeepingDataCode.Biometrics
{
    public class CasherCheckerPosShifting
    {
        public int Id { get; set; }
        public int PosId { get; set; }
        public int CType { get; set; }
        public string LastModified { get; set; }

        public CasherCheckerPosShifting(int id,int posId,int cType,string lastModified)
        {
            this.Id = id;
            this.PosId = posId;
            this.CType = cType;
            this.LastModified = lastModified;
        }

        public static List<CasherCheckerPosShifting> GetAllCasherCheckerPosShifting(Connection connection) {
            return GetDatas(connection,QueryFilter(new FilterClause<int>(),new FilterClause<int>()));
        }

        public static List<CasherCheckerPosShifting> GetAllCasherCheckerPosShifting(Connection connection,int posId)
        {
            return GetDatas(connection, QueryFilter(new FilterClause<int>(), new FilterClause<int>(posId)));
        }

        public static CasherCheckerPosShifting GetCasherCheckerPosShifting(Connection connection,int id) {
            return GetData(connection,QueryFilter(new FilterClause<int>(id),new FilterClause<int>()));
        }

        private static string QueryFilter(FilterClause<int> id,FilterClause<int> posId) {
            string idWhereClause = string.Empty;
            string posIdWhereClause = string.Empty;

            if (id.IsFilter)
                idWhereClause = " and Id = " + id.Value + " ";
            if (posId.IsFilter)
                posIdWhereClause = " and PosId = " + posId.Value + " ";

            string query = "select a.Id,a.PosId,a.CType,a.LastModified " +
                           "from tbl_DCasherCheckerPosShifting a " +
                           "join tbl_DCasherCheckerPOS b on a.PosId = b.Id and b.IsOpen = 1 " +
                           "where 1=1 " +idWhereClause + posIdWhereClause;
            return query;
        }

        private static List<CasherCheckerPosShifting> GetDatas(Connection connection,string query) {
            List<CasherCheckerPosShifting> result = new List<CasherCheckerPosShifting>();
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result.Add(new CasherCheckerPosShifting(Convert.ToInt32(d.Rows[i]["Id"]), Convert.ToInt32(d.Rows[i]["PosId"]),
                    Convert.ToInt32(d.Rows[i]["CType"]), d.Rows[i]["LastModified"].ToString()));
            }
            return result;
        }

        private static CasherCheckerPosShifting GetData(Connection connection,string query) {
            CasherCheckerPosShifting result = null;
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result = new CasherCheckerPosShifting(Convert.ToInt32(d.Rows[i]["Id"]), Convert.ToInt32(d.Rows[i]["PosId"]),
                    Convert.ToInt32(d.Rows[i]["CType"]),d.Rows[i]["LastModified"].ToString());
            }
            return result;
        }

        public static bool UpdatePosShifting(Connection connection,List<CasherCheckerPosShifting> list) {
            StringBuilder sb = new StringBuilder();

            sb.Append("declare @tmpTable table (Id int,PosId int,CType int,LastModified varchar(100)) ");

            for (int i = 0; i < list.Count; i++)
            {
                sb.Append("insert @tmpTable values (" + list[i].Id + "," + list[i].PosId + "," + list[i].CType + "," + 
                    "'" + Connection.SqlString(list[i].LastModified) + "') ");
            }

            sb.Append("delete a " +
                      "from tbl_DCasherCheckerPosShifting a " +
                      "left join @tmpTable b on a.Id = b.Id " +
                      "where b.Id is null ");

            sb.Append("insert tbl_DCasherCheckerPosShifting " +
                      "select b.PosId,b.CType,b.LastModified " +
                      "from tbl_DCasherCheckerPosShifting a " +
                      "right join @tmpTable b on a.Id = b.Id " +
                      "where a.Id is null ");

            return connection.Execute(sb.ToString());
        }
    }
}

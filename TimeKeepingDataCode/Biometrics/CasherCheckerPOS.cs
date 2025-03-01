using System;
using System.Collections.Generic;

namespace TimeKeepingDataCode.Biometrics
{
    public class CasherCheckerPOS
    {
        public int Id { get; set; }
        public string POS { get; set; }
        public bool IsOpen { get; set; }
        public DateTime DateCreated { get; set; }
        public string AddedBy { get; set; }

        public CasherCheckerPOS(int id,string pos,bool isOpen,DateTime dateCreated,string addedBy)
        {
            this.Id = id;
            this.POS = pos;
            this.IsOpen = isOpen;
            this.DateCreated = dateCreated;
            this.AddedBy = addedBy;
        }

        public static List<CasherCheckerPOS> GetAllCasherCheckerPOS(Connection connection) {
            return GetDatas(connection,QueryFilter());
        }

        private static string QueryFilter() {

            string query = "select Id,POS,IsOpen,DateAdded,AddedBy " +
                           "from tbl_DCasherCheckerPOS ";
            return query;
        }

        private static List<CasherCheckerPOS> GetDatas(Connection connection,string query) {
            List<CasherCheckerPOS> result = new List<CasherCheckerPOS>();
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result.Add(new CasherCheckerPOS(Convert.ToInt32(d.Rows[i]["Id"]),
                    d.Rows[i]["POS"].ToString(), Convert.ToBoolean(d.Rows[i]["IsOpen"]),
                    Convert.ToDateTime(d.Rows[i]["DateAdded"]),
                    d.Rows[i]["AddedBy"].ToString()));
            }
            return result;
        }

        private static CasherCheckerPOS GetData(Connection connection,string query) {
            CasherCheckerPOS result = null;
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result = new CasherCheckerPOS(Convert.ToInt32(d.Rows[i]["Id"]),
                    d.Rows[i]["POS"].ToString(), Convert.ToBoolean(d.Rows[i]["IsOpen"]),
                    Convert.ToDateTime(d.Rows[i]["DateAdded"]),
                    d.Rows[i]["AddedBy"].ToString());
            }
            return result;
        }

        public static bool CreateCasherCheckerPOS(Connection connection,List<CasherCheckerPOS> list) {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                sb.Append("insert tbl_DCasherCheckerPOS(POS,AddedBy,IsOpen) " +
                          "values ('" + Connection.SqlString(list[i].POS.ToUpper()) + "','" + 
                          Connection.SqlString(list[i].AddedBy) + "','" + list[i].IsOpen + "') ");
            }
            return connection.Execute(sb.ToString());
        }

        public static bool UpdateCasherCheckerPOS(Connection connection,List<CasherCheckerPOS> list) {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                sb.Append("update tbl_DCasherCheckerPOS " +
                          "set POS='" + Connection.SqlString(list[i].POS) + "',IsOpen='" + list[i].IsOpen + "' " +
                          "where Id =" + list[i].Id + " ");
            }
            return connection.Execute(sb.ToString());
        }
    }
}

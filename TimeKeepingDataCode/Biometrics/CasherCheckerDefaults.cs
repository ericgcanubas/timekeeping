using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeKeepingDataCode.Biometrics
{
    public class CasherCheckerDefaults
    {
        public int Id { get; set; }
        public int Restday { get; set; }
        public int Shifting { get; set; }

        public CasherCheckerDefaults(int id,int restday,int shifting)
        {
            this.Id = id;
            this.Restday = restday;
            this.Shifting = shifting;
        }

        private static string QueryFilter() 
        {
            string query = "select Id,Restday,Shifting " +
                           "from tbl_DCasherCheckerDefaults ";
            return query;
        }

        private static CasherCheckerDefaults GetData(Connection connection,string query) 
        {
            CasherCheckerDefaults result = null;
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result = new CasherCheckerDefaults(Convert.ToInt32(d.Rows[i]["Id"]),
                    Convert.ToInt32(d.Rows[i]["Restday"]), Convert.ToInt32(d.Rows[i]["Shifting"]));
            }
            return result;
        }

        private static List<CasherCheckerDefaults> GetDatas(Connection connection,string query) 
        {
            List<CasherCheckerDefaults> result = new List<CasherCheckerDefaults>();
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result.Add(new CasherCheckerDefaults(Convert.ToInt32(d.Rows[i]["Id"]),
                    Convert.ToInt32(d.Rows[i]["Restday"]),Convert.ToInt32(d.Rows[i]["Shifting"])));
            }
            return result;
        }

        public static CasherCheckerDefaults GetDefaults(Connection connection) 
        {
            return GetData(connection,QueryFilter());
        }

        public static bool SaveDefaults(Connection connection,CasherCheckerDefaults defaults) 
        {
            string query = "delete tbl_DCasherCheckerDefaults " +
                           "insert tbl_DCasherCheckerDefaults values (" + defaults.Restday + "," + defaults.Shifting + ")";
            return connection.Execute(query);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeKeepingDataCode.PayrollSystem
{
    public class Area
    {
        public int Pk { get; set; }
        public string Description { get; set; }

        public Area(int pk,string description)
        {
            this.Pk = pk;
            this.Description = description;
        }

        private static string QueryFilter() 
        {
            string query = "select PK,Description from EEmployeeDiv ";

            return query;
        }

        private static List<Area> GetDatas(Connection connection,string query) 
        {
            List<Area> result = new List<Area>();
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result.Add(new Area(Convert.ToInt32
                    (d.Rows[i]["PK"]), d.Rows[i]["Description"].ToString()));
            }
            return result;
        }

        private static Area GetData(Connection connection,string query) 
        {
            Area result = null;
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result = new Area(Convert.ToInt32
                    (d.Rows[i]["PK"]), d.Rows[i]["Description"].ToString());
            }
            return result;
        }

        public static List<Area> GetAllArea(Connection connection)
        {
            return GetDatas(connection,QueryFilter());
        }
    }
}

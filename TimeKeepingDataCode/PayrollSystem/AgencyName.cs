using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeKeepingDataCode.PayrollSystem
{
    public class AgencyName
    {
        public string Name { get; set; }

        public AgencyName(string name)
        {
            this.Name = name;
        }

        private static string QueryFilter(FilterClause<string> agencyName) 
        {
            string agencyNameWhereClause = string.Empty;

            if (agencyName.IsFilter)
                agencyNameWhereClause = " and AgencyName = '" + agencyName.Value + "' ";

            string query = "select AgencyName " +
                           "from Agency_Name " +
                           "where 1=1 " + agencyNameWhereClause;
            return query;
        }

        private static List<AgencyName> GetDatas(Connection connection,string query) 
        {
            List<AgencyName> result = new List<AgencyName>();
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result.Add(new AgencyName(d.Rows[i]["AgencyName"].ToString()));
            }
            return result;
        }

        private static AgencyName GetData(Connection connection,string query) 
        {
            AgencyName result = null;
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result = new AgencyName(d.Rows[i]["AgencyName"].ToString());
            }
            return result;
        }

        public static List<AgencyName> GetAllAgencies(Connection connection) 
        {
            return GetDatas(connection,QueryFilter(new FilterClause<string>()));
        }

        public static AgencyName GetAgency(Connection connection,string agencyName) 
        {
            return GetData(connection,QueryFilter(new FilterClause<string>(agencyName.Trim())));
        }

        public static bool InsertAgency(Connection connection,AgencyName agency) 
        {
            return connection.Execute("insert Agency_Name values ('" + Connection.SqlString(agency.Name) + "')");
        }
    }
}

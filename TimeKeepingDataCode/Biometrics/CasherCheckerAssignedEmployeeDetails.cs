using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeKeepingDataCode.Biometrics
{
    public class CasherCheckerAssignedEmployeeDetails
    {
        public int Id { get; set; }
        public int CasherCheckerAssignedId { get; set; }
        public string CType { get; set; }
        public int EmpId { get; set; }
        public bool IsAssigned { get; set; }

        public CasherCheckerAssignedEmployeeDetails(int id,int casherCheckerId,string ctype,int empId,bool IsAssigned)
        {
            this.Id = id;
            this.CasherCheckerAssignedId = casherCheckerId;
            this.CType = ctype;
            this.EmpId = empId;
            this.IsAssigned = IsAssigned;
        }

        public static List<CasherCheckerAssignedEmployeeDetails> GetAllCasherCheckerEmployeeDetails(Connection connection) 
        {
            return GetDatas(connection, QueryFilter(new FilterClause<int>(), new FilterClause<int>()));
        }

        public static List<CasherCheckerAssignedEmployeeDetails> GetAllCasherCheckerEmployeeDetails(Connection connection,int casherCheckerAssignId)
        {
            return GetDatas(connection, QueryFilter(new FilterClause<int>(), new FilterClause<int>(casherCheckerAssignId)));
        }

        public static CasherCheckerAssignedEmployeeDetails GetCasherCheckerEmployeeDetail(Connection conneciton,int id) {
            return GetData(conneciton,QueryFilter(new FilterClause<int>(id),new FilterClause<int>()));
        }

        private static string QueryFilter(FilterClause<int> id,FilterClause<int> casherCheckerId)
        {
            string idWhereClause = string.Empty;
            string casherCheckerWhereClause = string.Empty;

            if (id.IsFilter)
                idWhereClause = " and Id = " + id.Value + " ";
            if (casherCheckerId.IsFilter)
                casherCheckerWhereClause = " and CasherCheckerAssignedId = " + casherCheckerId.Value + " ";

            string query = "select Id,CasherCheckerAssignedId,CType,EmpId,IsAssigned " +
                           "from tbl_DCasherCheckerAssignedScheduleEmployeeDetails " +
                           "where 1=1 " + idWhereClause + casherCheckerWhereClause;
            return query;
        }

        private static List<CasherCheckerAssignedEmployeeDetails> GetDatas(Connection connection,string query) 
        {
            List<CasherCheckerAssignedEmployeeDetails> result = new List<CasherCheckerAssignedEmployeeDetails>();
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result.Add(new CasherCheckerAssignedEmployeeDetails(Convert.ToInt32(d.Rows[i]["Id"]),
                    Convert.ToInt32(d.Rows[i]["CasherCheckerAssignedId"]), d.Rows[i]["CType"].ToString(), 
                    Convert.ToInt32(d.Rows[i]["EmpId"]),Convert.ToBoolean(d.Rows[i]["IsAssigned"])));
            }
            return result;
        }

        private static CasherCheckerAssignedEmployeeDetails GetData(Connection connection,string query) {

            CasherCheckerAssignedEmployeeDetails result = null;
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result = new CasherCheckerAssignedEmployeeDetails(Convert.ToInt32(d.Rows[i]["Id"]),
                    Convert.ToInt32(d.Rows[i]["CasherCheckerAssignedId"]), d.Rows[i]["CType"].ToString(),
                    Convert.ToInt32(d.Rows[i]["EmpId"]), Convert.ToBoolean(d.Rows[i]["IsAssigned"]));
            }
            return result;
        }
    }
}

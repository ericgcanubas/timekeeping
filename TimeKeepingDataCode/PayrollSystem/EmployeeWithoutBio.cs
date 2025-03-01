using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeKeepingDataCode.PayrollSystem
{
    public class EmployeeWithoutBio
    {
        public int EmpNo { get; set; }
        public DateTime EffectDate { get; set; }

        public EmployeeWithoutBio(int empNo,DateTime dateEffect)
        {
            this.EmpNo = empNo;
            this.EffectDate = dateEffect;
        }

        private static string QueryFilter(FilterClause<int> empNo) 
        {
            string empNoWhereClause = string.Empty;

            if (empNo.IsFilter)
                empNoWhereClause = " and EmpNo = " + empNo.Value + " ";

            string query = "SELECT EmpNo,EffectDate " +
                           "FROM EmployeeWithOutBio " +
                           "where 1=1 " + empNoWhereClause;

            return query;
        }

        private static List<EmployeeWithoutBio> GetDatas(Connection connection,string query) 
        {
            List<EmployeeWithoutBio> result = new List<EmployeeWithoutBio>();
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result.Add(new EmployeeWithoutBio(Convert.ToInt32(d.Rows[i]["EmpNo"]),
                    Convert.ToDateTime(d.Rows[i]["EffectDate"])));
            }
            return result;
        }

        private static EmployeeWithoutBio GetData(Connection connection,string query) 
        {
            EmployeeWithoutBio result = null;
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result = new EmployeeWithoutBio(Convert.ToInt32(d.Rows[i]["EmpNo"]),
                    Convert.ToDateTime(d.Rows[i]["EffectDate"]));
            }
            return result;
        }

        public static List<EmployeeWithoutBio> GetAllEmployeesWithoutBio(Connection connection) 
        {
            return GetDatas(connection,QueryFilter(new FilterClause<int>()));
        }

        public static EmployeeWithoutBio GetEmployeeWithoutBio(Connection connection,int empNo) 
        {
            return GetData(connection,QueryFilter(new FilterClause<int>(empNo)));
        }
    }
}

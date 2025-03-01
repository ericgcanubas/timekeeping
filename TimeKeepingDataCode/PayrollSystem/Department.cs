using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeKeepingDataCode.PayrollSystem
{
    public class Department
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public int DType { get; set; }

        public Department(int id,string department,int dType)
        {
            this.Id = id;
            this.DepartmentName = department;
            this.DType = dType;
        }

        private static string QueryFilter() 
        {
            string query = "select isnull(DDepartmentsNo,0)DDepartmentsNo, " +
                              "isnull(DDepartment,'')DDepartment,isnull(DType,0)DType " +
                           "from DDepartmental ";
            return query;
        }

        private static List<Department> GetDatas(Connection connection,string query) 
        {
            List<Department> result = new List<Department>();
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result.Add(new Department(Convert.ToInt32(d.Rows[i]["DDepartmentsNo"]),
                    d.Rows[i]["DDepartment"].ToString(), Convert.ToInt32(d.Rows[i]["DType"])));
            }
            return result;
        }

        private static Department GetData(Connection connection,string query) 
        {
            Department result = null;
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result = new Department(Convert.ToInt32(d.Rows[i]["DDepartmentsNo"]),
                    d.Rows[i]["DDepartment"].ToString(), Convert.ToInt32(d.Rows[i]["DType"]));
            }
            return result;
        }

        public static List<Department> GetAllDepartments(Connection connection) 
        {
            return GetDatas(connection,QueryFilter());
        }
    }
}

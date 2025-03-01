using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeKeepingDataCode.PayrollSystem
{
    public class ActiveEmployeeBioId
    {
        public int Pk { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public int MachineId { get; set; }

        public ActiveEmployeeBioId(int pk,string lastname,string firstname,
            string middlename,int machineId)
        {
            this.Pk = pk;
            this.Lastname = lastname;
            this.Firstname = firstname;
            this.Middlename = middlename;
            this.MachineId = machineId;
        }

        private static string QueryFilter(FilterClause<int> pk,FilterClause<int> machineId) {
            string pkWhereClause = string.Empty;
            string machineIdWhereClause = string.Empty;

            if (pk.IsFilter)
                pkWhereClause = " where b.PK = " + pk.Value + " ";
            if (machineId.IsFilter)
                machineIdWhereClause = " and a.MachineId = " + machineId.Value + " ";

            string query = "select a.PK,a.ELastName,a.EFirstName,a.EMiddleName, " +
                                  "a.MachineId " +
                           "from ( " +
                               "select a.PK,a.ELastName,a.EFirstName,a.EMiddleName, " +
                                      "c.EffectDate,c.MachineId, " +
                                      "Row= ROW_NUMBER() over (partition by a.Pk order by c.EffectDate desc) " +
                               "from ( " +
                                   "select b.PK,b.ELastName,b.EFirstName,b.EMiddleName,c.PEmploymentStatus, " +
                                       "Row = ROW_NUMBER() over (partition by b.Pk order by c.PEffectivityDate desc) " +
                                   "from PayrollSystem.dbo.tbl_Profile_IDNumber b " +
                                   "join PayrollSystem.dbo.tbl_Profile_Action c " +
                                       "on b.PK = c.PEmployeeNo " + pkWhereClause + " ) a " +
                               "left join PayrollSystem.dbo.EEmploymentStatus b " +
                                   "on a.PEmploymentStatus = b.EEmploymentStatus " +
                               "join Biometrics.dbo.EmployeeShifting c " +
                                   "on a.PK = c.EmpNo " +
                               "where a.Row = 1 and b.Eactive = 1) a " +
                           "where a.Row = 1 " + machineIdWhereClause;
            return query;
        }

        private static List<ActiveEmployeeBioId> GetDatas(Connection connection,string query) {
            List<ActiveEmployeeBioId> result = new List<ActiveEmployeeBioId>();
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result.Add(new ActiveEmployeeBioId(Convert.ToInt32(d.Rows[i]["PK"]),
                    d.Rows[i]["ELastName"].ToString(), d.Rows[i]["EFirstName"].ToString(),
                    d.Rows[i]["EMiddleName"].ToString(), Convert.ToInt32(d.Rows[i]["MachineId"])));
            }
            return result;
        }

        private static ActiveEmployeeBioId GetData(Connection connection,string query) {
            ActiveEmployeeBioId result = null;
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result = new ActiveEmployeeBioId(Convert.ToInt32(d.Rows[i]["PK"]),
                    d.Rows[i]["ELastName"].ToString(), d.Rows[i]["EFirstName"].ToString(),
                    d.Rows[i]["EMiddleName"].ToString(), Convert.ToInt32(d.Rows[i]["MachineId"]));
            }
            return result;
        }

        public static List<ActiveEmployeeBioId> GetAllActiveEmployeeBioId(Connection connection) 
        {
            return GetDatas(connection,QueryFilter(new FilterClause<int>(),new FilterClause<int>()));
        }

        public static List<ActiveEmployeeBioId> GetAllActiveEmployeeBioId(Connection connection, int machineId) {
            return GetDatas(connection,QueryFilter(new FilterClause<int>(),new FilterClause<int>(machineId)));
        }

        public static ActiveEmployeeBioId GetActiveEmployeeBioId(Connection connection,int empPk) {
            return GetData(connection,QueryFilter(new FilterClause<int>(empPk),new FilterClause<int>()));
        }
    }
}

using System;
using System.Collections.Generic;

namespace TimeKeepingDataCode.Biometrics
{
    public class TransactionLog
    {
        public int Pk { get; set; }
        public int EmpPk { get; set; }
        public int MachineNo { get; set; }
        public int MachineId { get; set; }
        public DateTime ActualDate { get; set; }
        public DateTime ActualTime {get; set;}
        public string InOutMode { get; set; }
        public string EntryMode { get; set; }
        public bool IsPosted { get; set; }
        public string EmployeeName { get; set; }

        public TransactionLog(int pk,int empPk,int machineNo,int machineId,
            DateTime actualDate,DateTime actualTime,string inOutMode,string entryMode,
            bool isPosted,string employeeName)
        {
            this.Pk = pk;
            this.EmpPk = empPk;
            this.MachineNo = machineNo;
            this.MachineId = machineId;
            this.ActualDate = actualDate;
            this.ActualTime = actualTime;
            this.InOutMode = inOutMode;
            this.EntryMode = entryMode;
            this.IsPosted = IsPosted;
            this.EmployeeName = employeeName;
        }

        public static List<TransactionLog> GetAllTransactionLog(Connection connection) 
        {
            return GetDatas(connection,QueryFilter(new FilterClause<int>(),new FilterClause<int>(),
                new FilterClause<DateTime>(),new FilterClause<bool>()));
        }

        public static List<TransactionLog> GetAllTransactionLog(Connection connection,DateTime date,int empPk)
        {
            return GetDatas(connection, QueryFilter(new FilterClause<int>(), new FilterClause<int>(empPk),
                new FilterClause<DateTime>(date), new FilterClause<bool>()));
        }

        private static string QueryFilter(FilterClause<int> pk,FilterClause<int> empPk,
            FilterClause<DateTime> actualDate,FilterClause<bool> isPosted) 
        {
            string pkWhereClause = string.Empty;
            string empPkWhereClause = string.Empty;
            string actualDateWhereClause = string.Empty;
            string isPostedWhereClause = string.Empty;

            if (pk.IsFilter)
                pkWhereClause = " and PK = " + pk.Value + " ";
            if (empPk.IsFilter)
                empPkWhereClause = " and EmpPK= " + empPk.Value + " ";
            if (actualDate.IsFilter)
                actualDateWhereClause = " and Actual_Date='" + actualDate.Value.ToShortDateString() + "' ";
            if (isPosted.IsFilter)
                isPostedWhereClause = " and Posted = '" + isPosted.Value + "' ";

            string query = "SELECT PK,EmpPK,MachineNo,MachineID,Actual_Date, " +
                                  "Actual_Time,InOutMode,EntryMode,Posted,EmployeeName " +
                           "FROM tbl_TransactionLog " +
                           "where 1=1 " + pkWhereClause + empPkWhereClause + actualDateWhereClause + isPostedWhereClause;
            return query;
        }

        private static List<TransactionLog> GetDatas(Connection connection,string query) 
        {
            List<TransactionLog> result = new List<TransactionLog>();
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result.Add(new TransactionLog(Convert.ToInt32(d.Rows[i]["PK"]), Convert.ToInt32(d.Rows[i]["EmpPK"]),
                    Convert.ToInt32(d.Rows[i]["MachineNo"]), Convert.ToInt32(d.Rows[i]["MachineID"]),
                    Convert.ToDateTime(d.Rows[i]["Actual_Date"]), Convert.ToDateTime(d.Rows[i]["Actual_Time"]),
                    d.Rows[i]["InOutMode"].ToString(), d.Rows[i]["EntryMode"].ToString(),
                    Convert.ToBoolean(d.Rows[i]["Posted"]), d.Rows[i]["EmployeeName"].ToString()));
            }
            return result;
        }

        private static TransactionLog GetData(Connection connection,string query) 
        {
            TransactionLog result = null;
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result = new TransactionLog(Convert.ToInt32(d.Rows[i]["PK"]), Convert.ToInt32(d.Rows[i]["EmpPK"]),
                    Convert.ToInt32(d.Rows[i]["MachineNo"]), Convert.ToInt32(d.Rows[i]["MachineID"]),
                    Convert.ToDateTime(d.Rows[i]["Actual_Date"]), Convert.ToDateTime(d.Rows[i]["Actual_Time"]),
                    d.Rows[i]["InOutMode"].ToString(), d.Rows[i]["EntryMode"].ToString(),
                    Convert.ToBoolean(d.Rows[i]["Posted"]), d.Rows[i]["EmployeeName"].ToString());
            }
            return result;
        }

        public static bool IsEmployeeHaveTransactionLog(Connection connection,DateTime date,int empPk)
        {
            var d = connection.GetData(QueryFilter(new FilterClause<int>(),new FilterClause<int>(empPk),
                new FilterClause<DateTime>(date),new FilterClause<bool>()));

            if (d.Rows.Count > 0)
                return true;
            else
                return false;
        }

        public static bool RepostTransactionLog(Connection connection,DateTime tranactionDate,int empPk,List<Tuple<int,string>> pair) 
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.Append("delete tbl_TimeRecord_Detail " +
                      "where EmployeeKey =" + empPk + " and Actual_Date = '" + tranactionDate.ToShortDateString() + "' ");

            sb.Append("delete tbl_TimeRecord " +
                      "where EmployeeKey =" + empPk + " and Actual_Date = '" + tranactionDate.ToShortDateString() + "' ");

            for (int i = 0; i < pair.Count; i++)
            {
                sb.Append("update tbl_TransactionLog " +
                          "set InOutMode = '" + Connection.SqlString(pair[i].Item2) + "',Posted = 0 " +
                          "where PK =" + pair[i].Item1 + " ");
            }

            return connection.Execute(sb.ToString());
        }
    }
}

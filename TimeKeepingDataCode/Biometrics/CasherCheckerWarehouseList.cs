using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeKeepingDataCode.Biometrics
{
    public class CasherCheckerWarehouseList
    {
        public int Id { get; set; }
        public int CasherCheckerId { get; set; }
        public string CType { get; set; }
        public int EmpId { get; set; }
        public string IdNumber { get; set; }
        public string EmpName { get; set; }
        public string Restday { get; set; }
        public int MondayShifting { get; set; }
        public int TuesdayShifting { get; set; }
        public int WednesdayShifting { get; set; }
        public int ThursdayShifting { get; set; }
        public int FridayShifting { get; set; }
        public int SaturdayShifitng { get; set; }
        public int SundayShifting { get; set; }

        public CasherCheckerWarehouseList(int id,int casherCheckerAssignedId,string ctype,
            int empId,string restday,int mondayShifting,int tuesdayShifting,int wednesdayShifting,
            int thursdayShifting,int fridayShifting,int saturdayShifting,int sundayShifting,string idNumber,string empName)
        {
            this.Id = id;
            this.CasherCheckerId = casherCheckerAssignedId;
            this.CType = ctype;
            this.EmpId = empId;
            this.Restday = restday;
            this.MondayShifting = mondayShifting;
            this.TuesdayShifting = tuesdayShifting;
            this.WednesdayShifting = wednesdayShifting;
            this.ThursdayShifting = thursdayShifting;
            this.FridayShifting = fridayShifting;
            this.SaturdayShifitng = saturdayShifting;
            this.SundayShifting = sundayShifting;
            this.IdNumber = idNumber;
            this.EmpName = empName;
        }

        private static string QueryFilter(FilterClause<int> id,FilterClause<int> checkerAssignId, FilterClause<int> empId) 
        {
            string idWhereClause = string.Empty;
            string checkerAssignIdWhereClause = string.Empty;
            string empIdWhereClause = string.Empty;

            if (id.IsFilter)
                idWhereClause = " and Id = " + id.Value + " ";
            if (checkerAssignId.IsFilter)
                checkerAssignIdWhereClause = " and CasherCheckerAssignedId = " + checkerAssignId.Value + " ";
            if (empId.IsFilter)
                empIdWhereClause = " and EmpId = " + empId.Value + " ";

            string query = "SELECT Id,CasherCheckerAssignedId,Ctype,EmpId, " +
                                  "Restday,MondayShifting,TuesdayShifting, " +
                                  "WednesdayShifting,ThursdayShifting, " +
                                  "FridayShifting,SaturdayShifting,SundayShifting,IdNumber,EmpName " +
                           "FROM tbl_DCasherCheckerWarehouseList " +
                           "where 1=1 " + idWhereClause + checkerAssignIdWhereClause + empIdWhereClause;
            return query;
        }

        private static List<CasherCheckerWarehouseList> GetDatas(Connection connection,string query) 
        {
            List<CasherCheckerWarehouseList> result = new List<CasherCheckerWarehouseList>();
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result.Add(new CasherCheckerWarehouseList(Convert.ToInt32(d.Rows[i]["Id"]),
                    Convert.ToInt32(d.Rows[i]["CasherCheckerAssignedId"]), d.Rows[i]["Ctype"].ToString(),
                    Convert.ToInt32(d.Rows[i]["EmpId"]), d.Rows[i]["Restday"].ToString(),
                    Convert.ToInt32(d.Rows[i]["MondayShifting"]), Convert.ToInt32(d.Rows[i]["TuesdayShifting"]),
                    Convert.ToInt32(d.Rows[i]["WednesdayShifting"]), Convert.ToInt32(d.Rows[i]["ThursdayShifting"]),
                    Convert.ToInt32(d.Rows[i]["FridayShifting"]), Convert.ToInt32(d.Rows[i]["SaturdayShifting"]),
                    Convert.ToInt32(d.Rows[i]["SundayShifting"]),d.Rows[i]["IdNumber"].ToString(),d.Rows[i]["EmpName"].ToString()));
            }
            return result;
        }

        private static CasherCheckerWarehouseList GetData(Connection connection,string query) 
        {
            CasherCheckerWarehouseList result = null;
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result = new CasherCheckerWarehouseList(Convert.ToInt32(d.Rows[i]["Id"]),
                    Convert.ToInt32(d.Rows[i]["CasherCheckerAssignedId"]), d.Rows[i]["Ctype"].ToString(),
                    Convert.ToInt32(d.Rows[i]["EmpId"]), d.Rows[i]["Restday"].ToString(),
                    Convert.ToInt32(d.Rows[i]["MondayShifting"]), Convert.ToInt32(d.Rows[i]["TuesdayShifting"]),
                    Convert.ToInt32(d.Rows[i]["WednesdayShifting"]), Convert.ToInt32(d.Rows[i]["ThursdayShifting"]),
                    Convert.ToInt32(d.Rows[i]["FridayShifting"]), Convert.ToInt32(d.Rows[i]["SaturdayShifting"]),
                    Convert.ToInt32(d.Rows[i]["SundayShifting"]),d.Rows[i]["IdNumber"].ToString(),d.Rows[i]["EmpName"].ToString());
            }
            return result;
        }

        public static List<CasherCheckerWarehouseList> GetAllCasherCheckerWarehouseDetails(Connection connection) 
        {
            return GetDatas(connection,QueryFilter(new FilterClause<int>(),new FilterClause<int>(),new FilterClause<int>()));
        }

        public static List<CasherCheckerWarehouseList> GetAllCasherCheckerWarehouseDetails(Connection connection,int assignId) 
        {
            return GetDatas(connection, QueryFilter(new FilterClause<int>(), new FilterClause<int>(assignId), new FilterClause<int>()));
        }

        public static CasherCheckerWarehouseList GetCasherCheckerWarehouse(Connection connection,int id) 
        {
            return GetData(connection,QueryFilter(new FilterClause<int>(id),new FilterClause<int>(),new FilterClause<int>()));
        }
    }
}

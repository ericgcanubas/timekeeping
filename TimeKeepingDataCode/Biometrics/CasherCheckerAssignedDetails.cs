using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeKeepingDataCode.Biometrics
{
    public class CasherCheckerAssignedDetails
    {
        public int Id { get; set; }
        public int CasherCheckerId { get; set; }
        public string CType { get; set; }
        public int EmpId { get; set; }
        public string IdNumber { get; set; }
        public string EmpName { get; set; }
        public string POS { get; set; }
        public string Restday { get; set; }
        public int MondayShifitng { get; set; }
        public int TuesdayShifting { get; set; }
        public int WednesdayShifting { get; set; }
        public int ThursdayShifting { get; set; }
        public int FridayShifting { get; set; }
        public int SaturdayShifting { get; set; }
        public int SundayShifting { get; set; }

        public CasherCheckerAssignedDetails(int id,int casherCheckerId,string ctype,int empId,
            string pos,string restday, int mondayShifting,int tuesdayShifting,int wednesdayShifting,
            int thursdayShifting,int fridayShifting,int saturdayShifting,int sundayShifting,string idNumber,string empName)
        {
            this.Id = id;
            this.CasherCheckerId = casherCheckerId;
            this.CType = ctype;
            this.EmpId = empId;
            this.POS = pos;
            this.Restday = restday;
            this.MondayShifitng = mondayShifting;
            this.TuesdayShifting = tuesdayShifting;
            this.WednesdayShifting = wednesdayShifting;
            this.ThursdayShifting = thursdayShifting;
            this.FridayShifting = fridayShifting;
            this.SaturdayShifting = saturdayShifting;
            this.SundayShifting = sundayShifting;
            this.IdNumber = idNumber;
            this.EmpName = empName;
        }

        public static List<CasherCheckerAssignedDetails> GetallCasherCheckerDetails(Connection connection) 
        {
            return GetDatas(connection,QueryFilter(new FilterClause<int>(),new FilterClause<int>()));
        }

        public static List<CasherCheckerAssignedDetails> GetallCasherCheckerDetails(Connection connection,int casherCheckerId)
        {
            return GetDatas(connection, QueryFilter(new FilterClause<int>(), new FilterClause<int>(casherCheckerId)));
        }

        public static CasherCheckerAssignedDetails GetCasherCheckerDetai(Connection connection,int id) 
        {
            return GetData(connection,QueryFilter(new FilterClause<int>(id),new FilterClause<int>()));
        }

        private static string QueryFilter(FilterClause<int>id,FilterClause<int> casherCheckerId) 
        {
            string idWhereClause = string.Empty;
            string casherCheckerWhereClause = string.Empty;

            if (id.IsFilter)
                idWhereClause = " and Id = " + id.Value + " ";
            if (casherCheckerId.IsFilter)
                casherCheckerWhereClause = " and CasherCheckerAssignedId=" + casherCheckerId.Value + " ";

            string query = "SELECT Id,CasherCheckerAssignedId,CType,EmpId, " +
	                              "POS,Restday,MondayShifting,TuesdayShifting, " +
	                              "WednesdayShifting,ThursdayShifting,FridayShifting, " +
	                              "SaturdayShifting,SundayShifting,IdNumber,EmpName " +
                           "FROM tbl_DCasherCheckerAssignedScheduleDetails " +
                           "where 1=1 " + idWhereClause + casherCheckerWhereClause;
            return query;
        }

        private static List<CasherCheckerAssignedDetails> GetDatas(Connection connection,string query) 
        {
            List<CasherCheckerAssignedDetails> result = new List<CasherCheckerAssignedDetails>();
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result.Add(new CasherCheckerAssignedDetails(Convert.ToInt32(d.Rows[i]["Id"]),
                    Convert.ToInt32(d.Rows[i]["CasherCheckerAssignedId"]), d.Rows[i]["CType"].ToString(),
                    Convert.ToInt32(d.Rows[i]["EmpId"]), d.Rows[i]["POS"].ToString(), d.Rows[i]["Restday"].ToString(),
                    Convert.ToInt32(d.Rows[i]["MondayShifting"]), Convert.ToInt32(d.Rows[i]["TuesdayShifting"]),
                    Convert.ToInt32(d.Rows[i]["WednesdayShifting"]), Convert.ToInt32(d.Rows[i]["ThursdayShifting"]),
                    Convert.ToInt32(d.Rows[i]["FridayShifting"]), Convert.ToInt32(d.Rows[i]["SaturdayShifting"]),
                    Convert.ToInt32(d.Rows[i]["SundayShifting"]),d.Rows[i]["IdNumber"].ToString(),d.Rows[i]["EmpName"].ToString()));
            }
            return result;
        }

        private static CasherCheckerAssignedDetails GetData(Connection connection,string query) 
        {
            CasherCheckerAssignedDetails result = null;
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result = new CasherCheckerAssignedDetails(Convert.ToInt32(d.Rows[i]["Id"]),
                    Convert.ToInt32(d.Rows[i]["CasherCheckerAssignedId"]), d.Rows[i]["CType"].ToString(),
                    Convert.ToInt32(d.Rows[i]["EmpId"]), d.Rows[i]["POS"].ToString(), d.Rows[i]["Restday"].ToString(),
                    Convert.ToInt32(d.Rows[i]["MondayShifting"]), Convert.ToInt32(d.Rows[i]["TuesdayShifting"]),
                    Convert.ToInt32(d.Rows[i]["WednesdayShifting"]), Convert.ToInt32(d.Rows[i]["ThursdayShifting"]),
                    Convert.ToInt32(d.Rows[i]["FridayShifting"]), Convert.ToInt32(d.Rows[i]["SaturdayShifting"]),
                    Convert.ToInt32(d.Rows[i]["SundayShifting"]),d.Rows[i]["IdNumber"].ToString(),d.Rows[i]["EmpName"].ToString());
            }
            return result;
        }
    }
}

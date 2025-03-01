using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeKeepingDataCode.PayrollSystem
{
    public class AgencyClearing
    {
        public int Pk { get; set; }
        public int EmpNo { get; set; }
        public int Department { get; set; }
        public int Section { get; set; }
        public int PClassStoreBack { get; set; }
        public int Period { get; set; }
        public double ClearingSession { get; set; }
        public double ClearingRate { get; set; }
        public double ClearingValue { get; set; }
        public double TmpClearingSession { get; set; }

        public AgencyClearing(int pk,int empNo,int department,int section,
            int pclassStoreBack,int period, double clearingSession,double clearingRate,
            double clearinValue,double tmpClearingSession)
        {
            this.Pk = pk;
            this.EmpNo = empNo;
            this.Department = department;
            this.Section = section;
            this.PClassStoreBack = pclassStoreBack;
            this.Period = period;
            this.ClearingSession = clearingSession;
            this.ClearingRate = clearingRate;
            this.ClearingValue = clearinValue;
            this.TmpClearingSession = tmpClearingSession;
        }

        public static string QueryFilter(FilterClause<int> pk,
            FilterClause<int> empNo,FilterClause<int> period) 
        {
            string pkWhereClause = string.Empty;
            string empNoWhereClause = string.Empty;
            string periodWhereClause = string.Empty;

            if (pk.IsFilter)
                pkWhereClause = " and Pk = " + pk.Value + " ";
            if (empNo.IsFilter)
                empNoWhereClause = " and EmpNo = " + empNo.Value + " ";
            if (period.IsFilter)
                periodWhereClause = " and DPeriod = " + period.Value + " ";

            string query = "select Pk,EmpNo,DDepartment, " +
                                  "DSection,PClassStore_Back,DPeriod, " +
                                  "ClearingSession,ClearingRate, " +
                                  "ClearingValue,tmpClearingSession " +
                           "from Agency_Clearing " +
                           "where 1=1 " + pkWhereClause + empNoWhereClause + periodWhereClause;
            return query;
        }

        private static List<AgencyClearing> GetDatas(Connection connection,string query) 
        {
            List<AgencyClearing> result = new List<AgencyClearing>();
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result.Add(new AgencyClearing(Convert.ToInt32(d.Rows[i]["Pk"]), Convert.ToInt32(d.Rows[i]["EmpNo"]),
                    Convert.ToInt32(d.Rows[i]["DDepartment"]), Convert.ToInt32(d.Rows[i]["DSection"]),
                    Convert.ToInt32(d.Rows[i]["PClassStore_Back"]), Convert.ToInt32(d.Rows[i]["DPeriod"]),
                    Convert.ToDouble(d.Rows[i]["ClearingSession"]), Convert.ToDouble(d.Rows[i]["ClearingRate"]),
                    Convert.ToDouble(d.Rows[i]["ClearingValue"]), Convert.ToDouble(d.Rows[i]["tmpClearingSession"])));
            }
            return result;
        }

        private static AgencyClearing GetData(Connection connection,string query)
        {
            AgencyClearing result = null;
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result = new AgencyClearing(Convert.ToInt32(d.Rows[i]["Pk"]), Convert.ToInt32(d.Rows[i]["EmpNo"]),
                    Convert.ToInt32(d.Rows[i]["DDepartment"]), Convert.ToInt32(d.Rows[i]["DSection"]),
                    Convert.ToInt32(d.Rows[i]["PClassStore_Back"]), Convert.ToInt32(d.Rows[i]["DPeriod"]),
                    Convert.ToDouble(d.Rows[i]["ClearingSession"]), Convert.ToDouble(d.Rows[i]["ClearingRate"]),
                    Convert.ToDouble(d.Rows[i]["ClearingValue"]), Convert.ToDouble(d.Rows[i]["tmpClearingSession"]));
            }
            return result;
        }

        public static AgencyClearing GetAgencyClearing(Connection connection,int empNo,int period) 
        {
            return GetData(connection,QueryFilter(new FilterClause<int>(),new FilterClause<int>(empNo),new FilterClause<int>(period)));
        }

        public static bool DeleteAgencyClearing(Connection connection,AgencyClearing agencyClearing) 
        {
            string query = "DELETE FROM Agency_Clearing WHERE EmpNo = " + agencyClearing.EmpNo + " AND DPeriod = " + agencyClearing.Period + " ";

            return connection.Execute(query);
        }

        public static bool InsertClearing(Connection connection,AgencyClearing agencyClearing) 
        {
            string query = "insert Agency_Clearing values (" + agencyClearing.EmpNo + "," + 
                           agencyClearing.Department + "," + agencyClearing.Section + ", " +
	                       "" + agencyClearing.PClassStoreBack + "," + agencyClearing.Period + 
                           "," + agencyClearing.ClearingSession + "," + agencyClearing.ClearingRate +  ", " +
	                       "" + agencyClearing.ClearingValue + "," + agencyClearing.TmpClearingSession + ") ";

            return connection.Execute(query);
        }

        public static AgencyClearing CreateEmptyAgencyClearing() 
        {
            return new AgencyClearing(0,0,0,0,0,0,0,0,0,0);
        }
    }
}

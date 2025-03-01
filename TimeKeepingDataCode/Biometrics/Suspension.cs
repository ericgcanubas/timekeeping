using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeKeepingDataCode.Biometrics
{
    public class Suspension
    {
        public int Pk { get; set; }
        public string CntrlNo { get; set; }
        public DateTime EntryDate { get; set; }
        public int EmpNo { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string EffectDates { get; set; }
        public string Remarks { get; set; }
        public bool IsPosted { get; set; }
        public string LastModified { get; set; }

        public Suspension(int pk,string cntrlNo,DateTime entryDate,int empNo,
            DateTime dateFrom,DateTime dateTo,string effectDates,string remarks,
            bool isPosted,string lastModified)
        {
            this.Pk = pk;
            this.CntrlNo = cntrlNo;
            this.EntryDate = entryDate;
            this.EmpNo = empNo;
            this.DateFrom = dateFrom;
            this.DateTo = dateTo;
            this.EffectDates = effectDates;
            this.Remarks = remarks;
            this.IsPosted = isPosted;
            this.LastModified = lastModified;
        }

        private static string QueryFilter(FilterClause<DateTime> dateEffect,FilterClause<int> pk,FilterClause<int> empNo) 
        {
            string dateEffectWhereClause = string.Empty;
            string pkWhereClause = string.Empty;
            string empNoWhereClause = string.Empty;

            if (dateEffect.IsFilter)
                dateEffectWhereClause = " and EffectDates like '%" + dateEffect.Value.ToShortDateString() + "%' ";
            if (pk.IsFilter)
                pkWhereClause = " and PK = " + pk.Value + " ";
            if (empNo.IsFilter)
                empNoWhereClause = " and EmpNo = " + empNo.Value + " ";

            string query = "SELECT PK,CtrlNo,DDate,EmpNo,isnull(DateFrom,'1901-01-01')DateFrom, " +
                                  "isnull(DateTo,'1901-01-01')DateTo,isnull(EffectDates,'')EffectDates, " +
                                  "isnull(Remarks,'')Remarks,Posted,isnull(LastModified,'')LastModified " +
                           "FROM Suspension " +
                           "where 1=1 " + dateEffectWhereClause + pkWhereClause + empNoWhereClause;
            return query;
        }

        private static List<Suspension> GetDatas(Connection connection,string query)
        {
            List<Suspension> result = new List<Suspension>();
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result.Add(new Suspension(Convert.ToInt32(d.Rows[i]["PK"]), d.Rows[i]["CtrlNo"].ToString(),
                    Convert.ToDateTime(d.Rows[i]["DDate"]), Convert.ToInt32(d.Rows[i]["EmpNo"]),
                    Convert.ToDateTime(d.Rows[i]["DateFrom"]), Convert.ToDateTime(d.Rows[i]["DateTo"]),
                    d.Rows[i]["EffectDates"].ToString(), d.Rows[i]["Remarks"].ToString(),
                    Convert.ToBoolean(d.Rows[i]["Posted"]), d.Rows[i]["LastModified"].ToString()));
            }
            return result;
        }

        private static Suspension GetData(Connection connection, string query)
        {
            Suspension result = null;
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result = new Suspension(Convert.ToInt32(d.Rows[i]["PK"]), d.Rows[i]["CtrlNo"].ToString(),
                    Convert.ToDateTime(d.Rows[i]["DDate"]), Convert.ToInt32(d.Rows[i]["EmpNo"]),
                    Convert.ToDateTime(d.Rows[i]["DateFrom"]), Convert.ToDateTime(d.Rows[i]["DateTo"]),
                    d.Rows[i]["EffectDates"].ToString(), d.Rows[i]["Remarks"].ToString(),
                    Convert.ToBoolean(d.Rows[i]["Posted"]), d.Rows[i]["LastModified"].ToString());
            }
            return result;
        }

        public static List<Suspension> GetAllSuspensions(Connection connection) 
        {
            return GetDatas(connection,QueryFilter(new FilterClause<DateTime>(),new FilterClause<int>(),new FilterClause<int>()));
        }

        public static List<Suspension> GetAllSuspensions(Connection connection,int empNo,DateTime dateEffect)
        {
            return GetDatas(connection, QueryFilter(new FilterClause<DateTime>(dateEffect), new FilterClause<int>(), new FilterClause<int>(empNo)));
        }

        public static Suspension GetSuspension(Connection connection,int pk) 
        {
            return GetData(connection,QueryFilter(new FilterClause<DateTime>(),new FilterClause<int>(pk),new FilterClause<int>()));
        }

        public static bool IsSuspended(Connection connection,int empNo,DateTime dateEffect) 
        {
            bool result = false;

            var suspensions = GetAllSuspensions(connection,empNo,dateEffect);
            for (int i = 0; i < suspensions.Count; i++)
            {
                if (suspensions[i].IsPosted)
                {
                    result = true;
                    break;
                }
            }

            return result;
        }
    }
}

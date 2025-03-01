using System;
using System.Collections.Generic;
using System.Text;

namespace TimeKeepingDataCode.Biometrics
{
    public class PRW
    {
        public int Id { get; set; }
        public int CntrlNo { get; set; }
        public DateTime TransactionDate { get; set; }
        public int Type { get; set; }
        public int EmpPk { get; set; }
        public string EmpName { get; set; }
        public string Section { get; set; }
        public string Position { get; set; }
        public string AllDates { get; set; }
        public string Reason { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string ATDNo { get; set; }
        public decimal Amount { get; set; }
        public string Transno { get; set; }
        public string VerifiedBy { get; set; }
        public string RecommendedBy { get; set; }
        public string NotedBy1 { get; set; }
        public string ApprovedBy1 { get; set; }
        public string ReleaseBy { get; set;}
        public int DiscActType { get; set; }
        public string SuspensionFor { get; set; }
        public string SuspensionSched { get; set; }
        public DateTime TerminationDate { get; set; }
        public string Remarks { get; set; }
        public string PreparedBy { get; set; }
        public string NotedBy2 { get; set; }
        public string ApprovedBy2 { get; set; }
        public string ConfirmBy { get; set; }
        public bool IsPosted { get; set; }
        public string LastUpdated { get; set; }
        public string NoDaysMins { get; set; }
        public int Freq { get; set; }

        public PRW(int id,int cntrlNo,DateTime transactionDate,int type,int empPk,
            string empName,string section,string position,string allDates,string reason,
            DateTime dateStart,DateTime dateEnd,string atdNo,decimal amount,string transNo,
            string verifiedBy,string recommendedBy,string notedBy1,string approvedBy1,
            string releaseBy,int discActionType,string suspensionFor,string suspensionSched,
            DateTime terminationDate,string remarks,string preparedBy,string notedBy2,
            string approvedBy2,string confirmBy,bool isPosted,string lastUpdated,
            string noDaysMins,int freq)
        {
            this.Id = id;
            this.CntrlNo = cntrlNo;
            this.TransactionDate = transactionDate;
            this.Type = type;
            this.EmpPk = empPk;
            this.EmpName = empName;
            this.Section = section;
            this.Position = position;
            this.AllDates = allDates;
            this.Reason = reason;
            this.DateStart = dateStart;
            this.DateEnd = dateEnd;
            this.ATDNo = atdNo;
            this.Amount = amount;
            this.Transno = transNo;
            this.VerifiedBy = verifiedBy;
            this.RecommendedBy = recommendedBy;
            this.NotedBy1 = notedBy1;
            this.ApprovedBy1 = approvedBy1;
            this.ReleaseBy = releaseBy;
            this.DiscActType = discActionType;
            this.SuspensionFor = suspensionFor;
            this.SuspensionSched = suspensionSched;
            this.TerminationDate = terminationDate;
            this.Remarks = remarks;
            this.PreparedBy = preparedBy;
            this.NotedBy2 = notedBy2;
            this.ApprovedBy2 = approvedBy2;
            this.ConfirmBy = confirmBy;
            this.IsPosted = isPosted;
            this.LastUpdated = lastUpdated;
            this.NoDaysMins = noDaysMins;
            this.Freq = freq;
        }

        public static List<PRW> GetAllPRW(Connection connection) 
        {
            return GetDatas(connection,QueryFilter(new FilterClause<int>(),new FilterClause<int>()));
        }

        public static List<PRW> GetAllPRW(Connection connection,int empId)
        {
            return GetDatas(connection, QueryFilter(new FilterClause<int>(), new FilterClause<int>(empId)));
        }

        public static PRW GetPRW(Connection connection,int id) 
        {
            return GetData(connection,QueryFilter(new FilterClause<int>(id),new FilterClause<int>()));
        }

        private static string QueryFilter(FilterClause<int> id,FilterClause<int> empId)
        {
            string idWhereClause = string.Empty;
            string empIdWhereClause = string.Empty;

            if (id.IsFilter)
                idWhereClause = " and PRW_nID = " + id.Value + " ";
            if (empId.IsFilter)
                empIdWhereClause = " and EmpPK = " + empId.Value + " ";

            string query = "SELECT PRW_nID,isnull(nCtrlNo,0)nCtrlNo,isnull(dTransDate,'1901-01-01')dTransDate, " +
                                  "isnull(nType,0)nType,isnull(EmpPK,0)EmpPK,isnull(sEmpName,'')sEmpName, " +
                                  "isnull(sSection,'')sSection,isnull(sBrand,'')sBrand,isnull(sALDates,'')sALDates, " +
                                  "isnull(sReasons,'')sReasons,isnull(dStarting,'1901-01-01')dStarting, " +
                                  "isnull(dEnding,'1901-01-01')dEnding,isnull(sATDNo,'')sATDNo, " +
                                  "isnull(nAmount,0)nAmount,isnull(sTransNo,'')sTransNo,isnull(sVerBy,'')sVerBy, " +
                                  "isnull(sRecBy,'')sRecBy,isnull(sNotBy1,'')sNotBy1,isnull(sAppBy,'')sAppBy, " +
                                  "isnull(sRelBy,'')sRelBy,isnull(nDiscActType,0)nDiscActType, " +
                                  "isnull(sSuspensionFor,'')sSuspensionFor,isnull(sSuspensionSked,'')sSuspensionSked, " +
                                  "isnull(dTerminationDate,'1901-01-01')dTerminationDate,isnull(sRemarks,'')sRemarks, " +
                                  "isnull(sPreBy,'')sPreBy,isnull(sNotBy2,'')sNotBy2,isnull(sAppBy2,'')sAppBy2, " +
                                  "isnull(sConfrm,'')sConfrm,isnull(nPosted,0)nPosted,isnull(sLastUpdatedBy,'')sLastUpdatedBy, " +
                                  "isnull(sNoOfDaysMins,'')sNoOfDaysMins,isnull(nFreq,0)nFreq " +
                           "FROM tbl_PRW_NEW " +
                           "where 1=1 " + idWhereClause + empIdWhereClause;
            return query;
        }

        private static List<PRW> GetDatas(Connection connection,string query) 
        {
            List<PRW> result = new List<PRW>();
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result.Add(new PRW(Convert.ToInt32(d.Rows[i]["PRW_nID"]), Convert.ToInt32(d.Rows[i]["nCtrlNo"]),
                    Convert.ToDateTime(d.Rows[i]["dTransDate"]), Convert.ToInt32(d.Rows[i]["nType"]),
                    Convert.ToInt32(d.Rows[i]["EmpPK"]), d.Rows[i]["sEmpName"].ToString(),
                    d.Rows[i]["sSection"].ToString(), d.Rows[i]["sBrand"].ToString(), d.Rows[i]["sALDates"].ToString(),
                    d.Rows[i]["sReasons"].ToString(), Convert.ToDateTime(d.Rows[i]["dStarting"]),
                    Convert.ToDateTime(d.Rows[i]["dEnding"]), d.Rows[i]["sATDNo"].ToString(),
                    Convert.ToDecimal(d.Rows[i]["nAmount"]), d.Rows[i]["sTransNo"].ToString(),
                    d.Rows[i]["sVerBy"].ToString(), d.Rows[i]["sRecBy"].ToString(), d.Rows[i]["sNotBy1"].ToString(),
                    d.Rows[i]["sAppBy"].ToString(), d.Rows[i]["sRelBy"].ToString(), Convert.ToInt32(d.Rows[i]["nDiscActType"]),
                    d.Rows[i]["sSuspensionFor"].ToString(), d.Rows[i]["sSuspensionSked"].ToString(),
                    Convert.ToDateTime(d.Rows[i]["dTerminationDate"]), d.Rows[i]["sRemarks"].ToString(),
                    d.Rows[i]["sPreBy"].ToString(), d.Rows[i]["sNotBy2"].ToString(), d.Rows[i]["sAppBy2"].ToString(),
                    d.Rows[i]["sConfrm"].ToString(), Convert.ToBoolean(d.Rows[i]["nPosted"]), d.Rows[i]["sLastUpdatedBy"].ToString(),
                    d.Rows[i]["sNoOfDaysMins"].ToString(), Convert.ToInt32(d.Rows[i]["nFreq"])));
            }
            return result;
        }

        private static PRW GetData(Connection connection,string query) 
        {
            PRW result = null;
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result = new PRW(Convert.ToInt32(d.Rows[i]["PRW_nID"]), Convert.ToInt32(d.Rows[i]["nCtrlNo"]),
                    Convert.ToDateTime(d.Rows[i]["dTransDate"]), Convert.ToInt32(d.Rows[i]["nType"]),
                    Convert.ToInt32(d.Rows[i]["EmpPK"]), d.Rows[i]["sEmpName"].ToString(),
                    d.Rows[i]["sSection"].ToString(), d.Rows[i]["sBrand"].ToString(), d.Rows[i]["sALDates"].ToString(),
                    d.Rows[i]["sReasons"].ToString(), Convert.ToDateTime(d.Rows[i]["dStarting"]),
                    Convert.ToDateTime(d.Rows[i]["dEnding"]), d.Rows[i]["sATDNo"].ToString(),
                    Convert.ToDecimal(d.Rows[i]["nAmount"]), d.Rows[i]["sTransNo"].ToString(),
                    d.Rows[i]["sVerBy"].ToString(), d.Rows[i]["sRecBy"].ToString(), d.Rows[i]["sNotBy1"].ToString(),
                    d.Rows[i]["sAppBy"].ToString(), d.Rows[i]["sRelBy"].ToString(), Convert.ToInt32(d.Rows[i]["nDiscActType"]),
                    d.Rows[i]["sSuspensionFor"].ToString(), d.Rows[i]["sSuspensionSked"].ToString(),
                    Convert.ToDateTime(d.Rows[i]["dTerminationDate"]), d.Rows[i]["sRemarks"].ToString(),
                    d.Rows[i]["sPreBy"].ToString(), d.Rows[i]["sNotBy2"].ToString(), d.Rows[i]["sAppBy2"].ToString(),
                    d.Rows[i]["sConfrm"].ToString(), Convert.ToBoolean(d.Rows[i]["nPosted"]), d.Rows[i]["sLastUpdatedBy"].ToString(),
                    d.Rows[i]["sNoOfDaysMins"].ToString(), Convert.ToInt32(d.Rows[i]["nFreq"]));
            }
            return result;
        }

        public static bool CreatePRW(Connection connection,PRW prw,List<PRWDetails> details) 
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("declare @cntrl int = (select top 1 nCtrlNo from tbl_PRW_NEW order by PRW_nID desc) ");

            sb.Append("insert tbl_PRW_NEW values(@cntrl+1,'" + prw.TransactionDate.ToShortDateString() + "'," + prw.Type + 
                      "," + prw.EmpPk + ",'" + Connection.SqlString(prw.EmpName) + "','" + Connection.SqlString(prw.Section) + 
                      "','" + Connection.SqlString(prw.Position) + "','" + Connection.SqlString(prw.AllDates) + 
                      "','" + Connection.SqlString(prw.Reason) + "','" + prw.DateStart.ToShortDateString() + 
                      "','" + prw.DateEnd.ToShortDateString() + "','" + Connection.SqlString(prw.ATDNo) + "'," + prw.Amount + 
                      ",'" + Connection.SqlString(prw.Transno) + "','" + Connection.SqlString(prw.VerifiedBy) + 
                      "','" + Connection.SqlString(prw.RecommendedBy) + "','" + Connection.SqlString(prw.NotedBy1) + 
                      "','" + Connection.SqlString(prw.ApprovedBy1) + "','" + Connection.SqlString(prw.ReleaseBy) + 
                      "'," + prw.DiscActType + ",'" + Connection.SqlString(prw.SuspensionFor) + "','" + Connection.SqlString(prw.SuspensionSched) + "', " +
	                  "'" + prw.TerminationDate.ToShortDateString() + "','" + Connection.SqlString(prw.Remarks) + 
                      "','" + Connection.SqlString(prw.PreparedBy) + "','" + Connection.SqlString(prw.NotedBy2) + 
                      "','" + Connection.SqlString(prw.ApprovedBy2) + "','" + Connection.SqlString(prw.ConfirmBy) + 
                      "',0,'" + Connection.SqlString(prw.LastUpdated) + "','" + Connection.SqlString(prw.NoDaysMins) + "'," + prw.Freq + ") ");

            sb.Append("declare @id int = (select MAX(PRW_nID) from tbl_PRW_NEW) ");

            for (int i = 0; i < details.Count; i++)
            {
                sb.Append("insert tbl_PRW_GRID values (@id," + details[i].Line + ",'" + Connection.SqlString(details[i].Type) + "', " +
	                      "'" + Connection.SqlString(details[i].Month1) + "','" + Connection.SqlString(details[i].Month2) + 
                          "','" + Connection.SqlString(details[i].Month3) + "','" + Connection.SqlString(details[i].Month4) + 
                          "','" + Connection.SqlString(details[i].Month5) + "','" + 
                          Connection.SqlString(details[i].Month6) + "','" + Connection.SqlString(details[i].Total) + "') ");
            }

            return connection.Execute(sb.ToString());
        }

        public static bool UpdatePRW(Connection connection,PRW prw,List<PRWDetails> details) 
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("update tbl_PRW_NEW " +
                      "set nType=" + prw.Type + ",sALDates='" + Connection.SqlString(prw.AllDates) + "',sReasons='" + 
                          Connection.SqlString(prw.Reason) + "',dStarting='" + prw.DateStart.ToShortDateString() + 
                          "',dEnding='" + prw.DateEnd.ToShortDateString() + "',sATDNo='" + Connection.SqlString(prw.ATDNo) + "', " +
	                      "sVerBy='" + Connection.SqlString(prw.VerifiedBy) + "',sRecBy='" + Connection.SqlString(prw.RecommendedBy) + 
                          "',sNotBy1='" + Connection.SqlString(prw.NotedBy1) + "',sAppBy='" + Connection.SqlString(prw.ApprovedBy1) + 
                          "',sRelBy='" + Connection.SqlString(prw.ReleaseBy) + "',nDiscActType=" + prw.DiscActType + ",sSuspensionFor='" + 
                          Connection.SqlString(prw.SuspensionFor) + "',sSuspensionSked='" + Connection.SqlString(prw.SuspensionSched) + 
                          "',dTerminationDate='" + prw.TerminationDate.ToShortDateString() + "',sRemarks='" + Connection.SqlString(prw.Remarks) + 
                          "',sPreBy='" + Connection.SqlString(prw.PreparedBy) + "',sNotBy2='" + Connection.SqlString(prw.NotedBy2) + 
                          "',sAppBy2='" + Connection.SqlString(prw.ApprovedBy2) + "',sConfrm='" + Connection.SqlString(prw.ConfirmBy) + 
                          "',sLastUpdatedBy='" + Connection.SqlString(prw.LastUpdated) + "',sNoOfDaysMins='" + Connection.SqlString(prw.NoDaysMins) + "', " +
	                      "nFreq=" + prw.Freq + " " +
                      "where PRW_nID =" + prw.Id + " ");

            for (int i = 0; i < details.Count; i++)
            {
                sb.Append("update tbl_PRW_GRID " +
                          "set sType='" + Connection.SqlString(details[i].Type) + "',sMonth1='" + Connection.SqlString(details[i].Month1) + 
                              "',sMonth2='" + Connection.SqlString(details[i].Month2) + "',sMonth3='" + Connection.SqlString(details[i].Month3) + 
                              "',sMonth4='" + Connection.SqlString(details[i].Month4) + "',sMonth5='" + Connection.SqlString(details[i].Month5) + 
                              "',sMonth6='" + Connection.SqlString(details[i].Month6) + "',sTotal='" + Connection.SqlString(details[i].Total) + "' " +
                          "where PRW_nID=" + prw.Id + " and nLine=" + details[i].Line + " ");
            }

            return connection.Execute(sb.ToString());
        }

        public static bool PostPRW(Connection connection,PRW prw) 
        {
            string query = "update tbl_PRW_NEW " +
                           "set nPosted=1,sLastUpdatedBy='" + Connection.SqlString(prw.LastUpdated) + "' " +
                           "where PRW_nID=" + prw.Id + " ";

            return connection.Execute(query);
        }
    }
}

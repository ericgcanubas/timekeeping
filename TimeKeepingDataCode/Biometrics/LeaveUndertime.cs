using System;
using System.Collections.Generic;
using System.Text;

namespace TimeKeepingDataCode.Biometrics
{
    public class LeaveUndertime
    {
        public int Id { get; set; }
        public int CntrlNo { get; set; }
        public DateTime TransactionDate { get; set; }
        public int Type { get; set; }
        public int EmpPk { get; set; }
        public string EmployeeName { get; set; }
        public string Section { get; set; }
        public string Position { get; set; }
        public DateTime EffectiveDate { get; set; }
        public string EffectDates { get; set; }
        public string ResumetoWork { get; set; }
        public string Reason { get; set; }
        public string CoordinatedBy { get; set; }
        public string CheckedBy { get; set; }
        public string FiledBy { get; set; }
        public string NotedBy { get; set; }
        public string VerifiedBy { get; set; }
        public string ApprovedBy { get; set; }
        public string LastModified { get; set; }
        public bool IsPosted { get; set; }
        public string NoDaysMins { get; set; }
        public bool IsCancelled { get; set; }
        public string CancelledReason { get; set; }

        public LeaveUndertime(int id,int cntrlNo,DateTime transactionDate,int type,int empPk,
            string employeeName,string section,string position,DateTime effectiveDate,string effectDates,
            string resumeToWork,string reason,string coordinatedBy,string checkedBy,string filedBy,
            string notedBy,string verifiedBy,string approvedBy,string lastModifiedBy,bool isPosted,
            string noDaysMins,bool isCancelled,string cancelledReason)
        {
            this.Id = id;
            this.CntrlNo = cntrlNo;
            this.TransactionDate = transactionDate;
            this.Type = type;
            this.EmpPk = empPk;
            this.EmployeeName = employeeName;
            this.Section = section;
            this.Position = position;
            this.EffectiveDate = effectiveDate;
            this.EffectDates = effectDates;
            this.ResumetoWork = resumeToWork;
            this.Reason = reason;
            this.CoordinatedBy = coordinatedBy;
            this.CheckedBy = checkedBy;
            this.FiledBy = filedBy;
            this.NotedBy = notedBy;
            this.VerifiedBy = verifiedBy;
            this.ApprovedBy = approvedBy;
            this.LastModified = lastModifiedBy;
            this.IsPosted = isPosted;
            this.NoDaysMins = noDaysMins;
            this.IsCancelled = isCancelled;
            this.CancelledReason = cancelledReason;
        }

        public static List<LeaveUndertime> GetAllLeaveUndertime(Connection connection) 
        {
            return GetDatas(connection,QueryFilter(new FilterClause<int>(),new FilterClause<int>()));
        }

        public static List<LeaveUndertime> GetAllLeaveUndertime(Connection connection,int empNo) 
        {
            return GetDatas(connection,QueryFilter(new FilterClause<int>(),new FilterClause<int>(empNo)));
        }

        public static LeaveUndertime GetLeaveUndertime(Connection connection,int id) 
        {
            return GetData(connection,QueryFilter(new FilterClause<int>(id),new FilterClause<int>()));
        }

        private static string QueryFilter(FilterClause<int> id,FilterClause<int> empNo) 
        {
            string idWhereClause = string.Empty;
            string empNoWhereClause = string.Empty;

            if (id.IsFilter)
                idWhereClause = " and LU_nID = " + id.Value + " ";
            if (empNo.IsFilter)
                empNoWhereClause = " and EmpPK = " + empNo.Value + " ";

            string query = "SELECT LU_nID,isnull(nCtrlNo,0)nCtrlNo,isnull(dTransDate,'1901-01-01')dTransDate, " +
                                  "isnull(nType,0)nType,isnull(EmpPK,0)EmpPK,isnull(sEmpName,'')sEmpName, " +
                                  "isnull(sSection,'')sSection,isnull(sBrand,'')sBrand, " +
                                  "isnull(dEffectDate,'1901-01-01')dEffectDate,isnull(EffectDates,'')EffectDates, " +
                                  "isnull(sResumeToWork,'')sResumeToWork,isnull(sReason,'')sReason, " +
                                  "isnull(sCoordinated,'')sCoordinated,isnull(sCheckBy,'')sCheckBy, " +
                                  "isnull(sFiledBy,'')sFiledBy,isnull(sNotedBy,'')sNotedBy, " +
                                  "isnull(sVerifiedBy,'')sVerifiedBy,isnull(sApprovedBy,'')sApprovedBy, " +
                                  "isnull(sLastUpdatedBy,'')sLastUpdatedBy,isnull(nPosted,0)nPosted, " +
                                  "isnull(sNoOfDaysMin,'')sNoOfDaysMin,isnull(nCancelled,0)nCancelled, " +
                                  "isnull(sReasonCanc,'')sReasonCanc " +
                           "FROM tbl_LEAVE_UNDERTIME " +
                           "where 1=1 " + idWhereClause + empNoWhereClause;

            return query;
        }

        private static List<LeaveUndertime> GetDatas(Connection connection,string query) 
        {
            List<LeaveUndertime> result = new List<LeaveUndertime>();
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result.Add(new LeaveUndertime(Convert.ToInt32(d.Rows[i]["LU_nID"]), Convert.ToInt32(d.Rows[i]["nCtrlNo"]),
                    Convert.ToDateTime(d.Rows[i]["dTransDate"]), Convert.ToInt32(d.Rows[i]["nType"]),
                    Convert.ToInt32(d.Rows[i]["EmpPK"]), d.Rows[i]["sEmpName"].ToString(), d.Rows[i]["sSection"].ToString(),
                    d.Rows[i]["sBrand"].ToString(), Convert.ToDateTime(d.Rows[i]["dEffectDate"]),
                    d.Rows[i]["EffectDates"].ToString(), d.Rows[i]["sResumeToWork"].ToString(),
                    d.Rows[i]["sReason"].ToString(), d.Rows[i]["sCoordinated"].ToString(), d.Rows[i]["sCheckBy"].ToString(),
                    d.Rows[i]["sFiledBy"].ToString(), d.Rows[i]["sNotedBy"].ToString(), d.Rows[i]["sVerifiedBy"].ToString(),
                    d.Rows[i]["sApprovedBy"].ToString(), d.Rows[i]["sLastUpdatedBy"].ToString(),
                    Convert.ToBoolean(d.Rows[i]["nPosted"]), d.Rows[i]["sNoOfDaysMin"].ToString(),
                    Convert.ToBoolean(d.Rows[i]["nCancelled"]), d.Rows[i]["sReasonCanc"].ToString()));
            }
            return result;
        }

        private static LeaveUndertime GetData(Connection connection,string query) 
        {
            LeaveUndertime result = null;
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result = new LeaveUndertime(Convert.ToInt32(d.Rows[i]["LU_nID"]), Convert.ToInt32(d.Rows[i]["nCtrlNo"]),
                    Convert.ToDateTime(d.Rows[i]["dTransDate"]), Convert.ToInt32(d.Rows[i]["nType"]),
                    Convert.ToInt32(d.Rows[i]["EmpPK"]), d.Rows[i]["sEmpName"].ToString(), d.Rows[i]["sSection"].ToString(),
                    d.Rows[i]["sBrand"].ToString(), Convert.ToDateTime(d.Rows[i]["dEffectDate"]),
                    d.Rows[i]["EffectDates"].ToString(), d.Rows[i]["sResumeToWork"].ToString(),
                    d.Rows[i]["sReason"].ToString(), d.Rows[i]["sCoordinated"].ToString(), d.Rows[i]["sCheckBy"].ToString(),
                    d.Rows[i]["sFiledBy"].ToString(), d.Rows[i]["sNotedBy"].ToString(), d.Rows[i]["sVerifiedBy"].ToString(),
                    d.Rows[i]["sApprovedBy"].ToString(), d.Rows[i]["sLastUpdatedBy"].ToString(),
                    Convert.ToBoolean(d.Rows[i]["nPosted"]), d.Rows[i]["sNoOfDaysMin"].ToString(),
                    Convert.ToBoolean(d.Rows[i]["nCancelled"]), d.Rows[i]["sReasonCanc"].ToString());
            }
            return result;
        }

        public static bool IsLeave(Connection connection,DateTime date,int empId) 
        {
            string query = "select a.EmpPK " +
                           "from tbl_LEAVE_UNDERTIME a " +
                           "where a.nType = 1 and a.EffectDates like '%" + date.ToString("MM/dd/yyyy") + "%' " +
                           "and a.nPosted = 1 and a.nCancelled = 0 and a.EmpPK =" + empId + " ";
            if (connection.GetData(query).Rows.Count > 0)
                return true;
            else
                return false;
        }

        public static bool CreateLeaveUndertime(Connection connection,LeaveUndertime leaveUndertime,
            List<LeaveUndertimeDetails> details,List<LeaveUndertimeOtherDetails> otherDetails) 
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("declare @cntrlNo int = (select top 1 nCtrlNo from tbl_LEAVE_UNDERTIME order by LU_nID desc); ");

            sb.Append("insert tbl_LEAVE_UNDERTIME values(@cntrlNo +1,'" + leaveUndertime.TransactionDate.ToShortDateString() + "', " +
	                  "" + leaveUndertime.Type + "," + leaveUndertime.EmpPk + ",'" + Connection.SqlString(leaveUndertime.EmployeeName) + 
                      "','" + Connection.SqlString(leaveUndertime.Section) + "','" + Connection.SqlString(leaveUndertime.Position) + 
                      "','" + leaveUndertime.EffectiveDate.ToShortDateString() + "','" + Connection.SqlString(leaveUndertime.EffectDates) + 
                      "','" + Connection.SqlString(leaveUndertime.ResumetoWork) + "','" + Connection.SqlString(leaveUndertime.Reason) + 
                      "','" + Connection.SqlString(leaveUndertime.CoordinatedBy) + "','" + Connection.SqlString(leaveUndertime.CheckedBy) + 
                      "','" + Connection.SqlString(leaveUndertime.FiledBy) + "','" + Connection.SqlString(leaveUndertime.NotedBy) + 
                      "','" + Connection.SqlString(leaveUndertime.VerifiedBy) + "','" + Connection.SqlString(leaveUndertime.ApprovedBy) + "', " +
	                  "'" + Connection.SqlString(leaveUndertime.LastModified) + "','0','" + Connection.SqlString(leaveUndertime.NoDaysMins) + "','0','') ");

            sb.Append("declare @id int = (select MAX(LU_nID) from tbl_LEAVE_UNDERTIME) ");

            for (int i = 0; i < details.Count; i++)
            {
                sb.Append("insert tbl_LEAVE_UNDERTIME_DETAILS values " +
	                      "(@id,'" + details[i].Line + "','" + Connection.SqlString(details[i].Description) + 
                          "','" + Connection.SqlString(details[i].Total) + "','" + Connection.SqlString(details[i].Month1) + 
                          "','" + Connection.SqlString(details[i].Month2) + "','" + Connection.SqlString(details[i].Month3) + "') ");
            }

            for (int i = 0; i < otherDetails.Count; i++)
            {
                sb.Append("insert tbl_leaveUndertime_OtherDetails values " +
	                      "(@id,'" + Connection.SqlString(otherDetails[i].Restday) + "','" + Connection.SqlString(otherDetails[i].Holiday) + 
                          "','" + Connection.SqlString(otherDetails[i].Leave) + "','" + Connection.SqlString(otherDetails[i].Description) + "') ");
            }

            return connection.Execute(sb.ToString());
        }

        public static bool UpdateLeaveUndertime(Connection connection,LeaveUndertime leaveUndertime,
            List<LeaveUndertimeDetails> details,List<LeaveUndertimeOtherDetails> otherDetails) 
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("update tbl_LEAVE_UNDERTIME " +
                      "set nType =" +leaveUndertime.Type + ",dEffectDate='" + leaveUndertime.EffectiveDate.ToShortDateString() + 
                          "',EffectDates='" + Connection.SqlString(leaveUndertime.EffectDates) + 
                          "',sResumeToWork='" + Connection.SqlString(leaveUndertime.ResumetoWork) + "',sReason='" + Connection.SqlString(leaveUndertime.Reason) + 
                          "',sCoordinated='" + Connection.SqlString(leaveUndertime.CoordinatedBy) + "',sCheckBy='" + Connection.SqlString(leaveUndertime.CheckedBy) + 
                          "',sFiledBy='" + Connection.SqlString(leaveUndertime.FiledBy) + "',sNotedBy='" + Connection.SqlString(leaveUndertime.NotedBy) + "', " +
	                      "sVerifiedBy='" + Connection.SqlString(leaveUndertime.VerifiedBy) + "',sApprovedBy='" + Connection.SqlString(leaveUndertime.ApprovedBy) + 
                          "',sLastUpdatedBy='" + Connection.SqlString(leaveUndertime.LastModified) + "',sNoOfDaysMin='" + Connection.SqlString(leaveUndertime.NoDaysMins) + "' " +
                      "where LU_nID =" + leaveUndertime.Id + " ");

            for (int i = 0; i < details.Count; i++)
            {
                sb.Append("update tbl_LEAVE_UNDERTIME_DETAILS " +
                          "set sDesc ='" + Connection.SqlString(details[i].Description) + "',sTotal='" + Connection.SqlString(details[i].Total) + 
                          "',sMonth1='" + Connection.SqlString(details[i].Month1) + "',sMonth2='" + Connection.SqlString(details[i].Month2) + 
                          "',sMonth3=sMonth3 where LU_nID = " + details[i].LUId + " and nLine = " + details[i].Line + " ");
            }

            sb.Append("delete from tbl_leaveUndertime_OtherDetails " +
                      "where PkLeaveUndertime = " + leaveUndertime.Id + " ");

            for (int i = 0; i < otherDetails.Count; i++)
            {
                sb.Append("insert tbl_leaveUndertime_OtherDetails values(" + leaveUndertime.Id + ",'" + Connection.SqlString(otherDetails[i].Restday) + 
                            "','" + Connection.SqlString(otherDetails[i].Holiday) + "','" + Connection.SqlString(otherDetails[i].Leave) + 
                            "','" + Connection.SqlString(otherDetails[i].Description) + "') ");
            }

            return connection.Execute(sb.ToString());
        }

        public static bool CancelLeaveUndertime(Connection connection,LeaveUndertime leaveUndertime) 
        {
            string query = "update tbl_LEAVE_UNDERTIME " +
                           "set nCancelled=1,sReasonCanc='" + Connection.SqlString(leaveUndertime.CancelledReason) + "', " +
                               "sLastUpdatedBy='" + Connection.SqlString(leaveUndertime.LastModified) + "' " +
                           "where LU_nID=" + leaveUndertime.Id + " ";

            return connection.Execute(query);
        }

        public static bool PostLeaveUndertime(Connection connection,LeaveUndertime leaveUndertime) 
        {
            string query = "update tbl_LEAVE_UNDERTIME " +
                           "set nPosted=1,sLastUpdatedBy='" + Connection.SqlString(leaveUndertime.LastModified) + "' " +
                           "where LU_nID=" + leaveUndertime.Id + " ";

            return connection.Execute(query);
        }

        public static List<int> GetLeaveEmpIds(Connection connection,DateTime dateEffect) 
        {
            string query = "select EmpPK " +
                           "from tbl_LEAVE_UNDERTIME " +
                           "where nType = 1 and nPosted = 1 and nCancelled = 0 " +
                             "and EffectDates like '%" + dateEffect.ToString("MM/dd/yyyy") + "' ";
            List<int> result = new List<int>();
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result.Add(Convert.ToInt32(d.Rows[i]["EmpPK"]));
            }
            return result;
        }
    }
}

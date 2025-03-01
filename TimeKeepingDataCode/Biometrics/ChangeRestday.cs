using System;
using System.Collections.Generic;
using System.Text;

namespace TimeKeepingDataCode.Biometrics
{
    public class ChangeRestday
    {
        public int CdId { get; set; }
        public int CntrlNo { get; set; }
        public DateTime TrasactionDate { get; set; }
        public int EmpPk { get; set; }
        public string EmpName { get; set; }
        public string ReqDayFrom { get; set; }
        public string ReqDayTo { get; set; }
        public DateTime ReqDateFrom { get; set; }
        public DateTime ReqDateTo { get; set; }
        public string ExDayFrom { get; set; }
        public string ExDayTo { get; set; }
        public DateTime ExDateFrom { get; set; }
        public DateTime ExDateTo { get; set; }
        public int RestDayFrom { get; set; }
        public int RestDayTo { get; set; }
        public string Reason { get; set; }
        public string Coordinated { get; set; }
        public string RecommendedApprovedBy { get; set; }
        public string NotedBy { get; set; }
        public string ApprovedBy { get; set; }
        public string LastUpdatedBy { get; set; }
        public bool IsPosted { get; set; }
        public string ExWithName { get; set; }
        public int EmpPkWith { get; set; }
        public bool IsCancelled { get; set; }
        public string ReasonCancelled { get; set; }
        public string RefNid { get; set; }

        public ChangeRestday(int cdId,int cntrlNo,DateTime transactionDate,int empPK,
            string empName,string reqdayFrom,string reqdayTo,DateTime reqDateFrom,
            DateTime reqDateTo,string exDayFrom,string exDayTo,DateTime exDateFrom,
            DateTime exDateTo,int restdayFrom,int restdayTo,string reason,string coordinated,
            string recommendedApproved,string notedby,string approvedBy,string lastUpdated,
            bool isPosted,string exWithName,int empPkWith,bool isCancelled,string reasonCancelled,
            string refnId)
        {
            this.CdId = cdId;
            this.CntrlNo = cntrlNo;
            this.TrasactionDate = transactionDate;
            this.EmpPk = empPK;
            this.EmpName = empName;
            this.ReqDayFrom = reqdayFrom;
            this.ReqDayTo = reqdayTo;
            this.ReqDateFrom = reqDateFrom;
            this.ReqDateTo = reqDateTo;
            this.ExDayFrom = exDayFrom;
            this.ExDayTo = exDayTo;
            this.ExDateFrom = exDateFrom;
            this.ExDateTo = exDateTo;
            this.RestDayFrom = restdayFrom;
            this.RestDayTo = restdayTo;
            this.Reason = reason;
            this.Coordinated = coordinated;
            this.RecommendedApprovedBy = recommendedApproved;
            this.NotedBy = notedby;
            this.ApprovedBy = approvedBy;
            this.LastUpdatedBy = lastUpdated;
            this.IsPosted = isPosted;
            this.ExWithName = exWithName;
            this.EmpPkWith = empPkWith;
            this.IsCancelled = isCancelled;
            this.ReasonCancelled = reasonCancelled;
            this.RefNid = refnId;
        }


        public static List<ChangeRestday> GetAllChangeRestdays(Connection connection) 
        {
            return GetDatas(connection,QueryFilter(new FilterClause<int>(),new FilterClause<int>()));
        }

        public static List<ChangeRestday> GetAllChangeRestdays(Connection connection,int empPk)
        {
            return GetDatas(connection, QueryFilter(new FilterClause<int>(), new FilterClause<int>(empPk)));
        }

        public static ChangeRestday GetChangeRestday(Connection connection,int id)
        {
            return GetData(connection,QueryFilter(new FilterClause<int>(id),new FilterClause<int>()));
        }

        private static string QueryFilter(FilterClause<int> id,FilterClause<int> empNo) 
        {
            string idWhereClause = string.Empty;
            string empNoWhereClause = string.Empty;

            if (id.IsFilter)
                idWhereClause = " and CD_nID = " + id.Value + " ";
            if (empNo.IsFilter)
                empNoWhereClause = " and EmpPK = " + empNo.Value + " ";

            string query = "SELECT CD_nID,isnull(nCtrlNo,0)nCtrlNo,isnull(dTransDate,'1901-01-01')dTransDate, " +
                                  "isnull(EmpPK,0)EmpPK,isnull(sEmpName,'')sEmpName,isnull(sReqDayFrom,'')sReqDayFrom, " +
                                  "isnull(sReqDayTo,'')sReqDayTo,isnull(dReqDateFrom,'1901-01-01')dReqDateFrom, " +
                                  "isnull(dReqDateTo,'1901-01-01')dReqDateTo,isnull(sExDayFrom,'')sExDayFrom, " +
                                  "isnull(sExDayTo,'')sExDayTo,isnull(dExDateFrom,'1901-01-01')dExDateFrom, " +
                                  "isnull(dExDateTo,'1901-01-01')dExDateTo,RestDayFrom,isnull(RestDay,0)RestDay, " +
                                  "isnull(sReason,'')sReason,isnull(sCoordinated,'')sCoordinated,isnull(sRecmAppBy,'')sRecmAppBy, " +
                                  "isnull(sNotedBy,'')sNotedBy,isnull(sApprovBy,'')sApprovBy, " +
                                  "isnull(sLastUpdatedBy,'')sLastUpdatedBy,isnull(nPosted,0)nPosted, " +
                                  "isnull(sExWith,'')sExWith,isnull(EmpPKWith,0)EmpPKWith,isnull(nCancelled,0)nCancelled, " +
                                  "isnull(sReasonCanc,'')sReasonCanc,isnull(RefCD_nID,'')RefCD_nID " +
                           "FROM tbl_CHANGERESTDAY " +
                           "where 1=1 " + idWhereClause + empNoWhereClause;

            return query;
        }

        private static List<ChangeRestday> GetDatas(Connection connection,string query) 
        {
            List<ChangeRestday> result = new List<ChangeRestday>();
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result.Add(new ChangeRestday(Convert.ToInt32(d.Rows[i]["CD_nID"]), Convert.ToInt32(d.Rows[i]["nCtrlNo"]),
                    Convert.ToDateTime(d.Rows[i]["dTransDate"]), Convert.ToInt32(d.Rows[i]["EmpPK"]),
                    d.Rows[i]["sEmpName"].ToString(), d.Rows[i]["sReqDayFrom"].ToString(), d.Rows[i]["sReqDayTo"].ToString(),
                    Convert.ToDateTime(d.Rows[i]["dReqDateFrom"]), Convert.ToDateTime(d.Rows[i]["dReqDateTo"]),
                    d.Rows[i]["sExDayFrom"].ToString(), d.Rows[i]["sExDayTo"].ToString(),
                    Convert.ToDateTime(d.Rows[i]["dExDateFrom"]), Convert.ToDateTime(d.Rows[i]["dExDateTo"]),
                    Convert.ToInt32(d.Rows[i]["RestDayFrom"]), Convert.ToInt32(d.Rows[i]["RestDay"]),
                    d.Rows[i]["sReason"].ToString(), d.Rows[i]["sCoordinated"].ToString(),
                    d.Rows[i]["sRecmAppBy"].ToString(), d.Rows[i]["sNotedBy"].ToString(),
                    d.Rows[i]["sApprovBy"].ToString(), d.Rows[i]["sLastUpdatedBy"].ToString(),
                    Convert.ToBoolean(d.Rows[i]["nPosted"]), d.Rows[i]["sExWith"].ToString(),
                    Convert.ToInt32(d.Rows[i]["EmpPKWith"]), Convert.ToBoolean(d.Rows[i]["nCancelled"]),
                    d.Rows[i]["sReasonCanc"].ToString(), d.Rows[i]["RefCD_nID"].ToString()));
            }
            return result;
        }

        private static ChangeRestday GetData(Connection connection,string query) 
        {
            ChangeRestday result = null;
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result = new ChangeRestday(Convert.ToInt32(d.Rows[i]["CD_nID"]), Convert.ToInt32(d.Rows[i]["nCtrlNo"]),
                    Convert.ToDateTime(d.Rows[i]["dTransDate"]), Convert.ToInt32(d.Rows[i]["EmpPK"]),
                    d.Rows[i]["sEmpName"].ToString(), d.Rows[i]["sReqDayFrom"].ToString(), d.Rows[i]["sReqDayTo"].ToString(),
                    Convert.ToDateTime(d.Rows[i]["dReqDateFrom"]), Convert.ToDateTime(d.Rows[i]["dReqDateTo"]),
                    d.Rows[i]["sExDayFrom"].ToString(), d.Rows[i]["sExDayTo"].ToString(),
                    Convert.ToDateTime(d.Rows[i]["dExDateFrom"]), Convert.ToDateTime(d.Rows[i]["dExDateTo"]),
                    Convert.ToInt32(d.Rows[i]["RestDayFrom"]), Convert.ToInt32(d.Rows[i]["RestDay"]),
                    d.Rows[i]["sReason"].ToString(), d.Rows[i]["sCoordinated"].ToString(),
                    d.Rows[i]["sRecmAppBy"].ToString(), d.Rows[i]["sNotedBy"].ToString(),
                    d.Rows[i]["sApprovBy"].ToString(), d.Rows[i]["sLastUpdatedBy"].ToString(),
                    Convert.ToBoolean(d.Rows[i]["nPosted"]), d.Rows[i]["sExWith"].ToString(),
                    Convert.ToInt32(d.Rows[i]["EmpPKWith"]), Convert.ToBoolean(d.Rows[i]["nCancelled"]),
                    d.Rows[i]["sReasonCanc"].ToString(), d.Rows[i]["RefCD_nID"].ToString());
            }
            return result;
        }

        public static bool CreateChangeRestday(Connection connection,ChangeRestday changeRd,List<ChangeRestdayDetails> details) 
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("declare @cntrlNo int = (select top 1 nCtrlNo from tbl_CHANGERESTDAY order by CD_nID desc); ");

            sb.Append("insert tbl_CHANGERESTDAY values (@cntrlNo + 1,'" + changeRd.TrasactionDate + "'," + changeRd.EmpPk + 
                      ",'" + Connection.SqlString(changeRd.EmpName) + "','" + Connection.SqlString(changeRd.ReqDayFrom) + "', " +
	                  "'" + Connection.SqlString(changeRd.ReqDayTo) + "','" + changeRd.ReqDateFrom.ToShortDateString() + 
                      "','" + changeRd.ReqDateTo.ToShortDateString() + "','" + Connection.SqlString(changeRd.ExDayFrom) + 
                      "','" + Connection.SqlString(changeRd.ExDayTo) + "','" + changeRd.ExDateFrom.ToShortDateString() + 
                      "','" + changeRd.ExDateTo.ToShortDateString() + "'," + changeRd.RestDayFrom + "," + changeRd.RestDayTo + 
                      ",'" + Connection.SqlString(changeRd.Reason) + "','" + Connection.SqlString(changeRd.Coordinated) + 
                      "','" + Connection.SqlString(changeRd.RecommendedApprovedBy) + "','" + Connection.SqlString(changeRd.NotedBy) + 
                      "','" + Connection.SqlString(changeRd.ApprovedBy) + "','" + Connection.SqlString(changeRd.LastUpdatedBy) + 
                      "',0,'" + Connection.SqlString(changeRd.ExWithName) + "'," + changeRd.EmpPkWith + ",0,'','" + changeRd.RefNid + "') ");

            sb.Append("declare @Pk int = (select MAx(CD_nID) from tbl_CHANGERESTDAY); ");

            for (int i = 0; i < details.Count; i++)
            {
                sb.Append("insert tbl_CHANGERESTDAY_DETAILS values (@Pk," + details[i].Line + ",'"  + Connection.SqlString(details[i].Description) + 
                    "','" + Connection.SqlString(details[i].Total) + "','" + Connection.SqlString(details[i].Month1) + 
                    "','" + Connection.SqlString(details[i].Month2) + "','" + Connection.SqlString(details[i].Month3) + "') ");
            }

            return connection.Execute(sb.ToString());
        }

        public static bool UpdateChangeRestday(Connection connection,ChangeRestday changeRD,List<ChangeRestdayDetails> details) 
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("update tbl_CHANGERESTDAY " +
                      "set sReqDayFrom='" + Connection.SqlString(changeRD.ReqDayFrom)  + "',sReqDayTo='" + Connection.SqlString(changeRD.ReqDayTo) + 
                          "',dReqDateFrom='" + changeRD.ReqDateFrom.ToShortDateString() + "',dReqDateTo='" + changeRD.ReqDateTo.ToShortDateString() + 
                          "',sExDayFrom='" + Connection.SqlString(changeRD.ExDayFrom) + "',sExDayTo='" + Connection.SqlString(changeRD.ExDayTo) + 
                          "',dExDateFrom='" + changeRD.ExDateFrom.ToShortDateString() + "',dExDateTo='" + changeRD.ExDateTo.ToShortDateString() + 
                          "',RestDayFrom=" + changeRD.RestDayFrom + ",RestDay=" + changeRD.RestDayTo + ",sReason='" + Connection.SqlString(changeRD.Reason) + 
                          "',sCoordinated='" + Connection.SqlString(changeRD.Coordinated) + "',sRecmAppBy='" + Connection.SqlString(changeRD.RecommendedApprovedBy) + 
                          "',sNotedBy='" + Connection.SqlString(changeRD.NotedBy) + "',sApprovBy='" + Connection.SqlString(changeRD.ApprovedBy) + "', " +
	                      "sLastUpdatedBy='" + Connection.SqlString(changeRD.LastUpdatedBy) + "',sExWith='" + Connection.SqlString(changeRD.ExWithName) + 
                          "',EmpPKWith=" + changeRD.EmpPkWith + ",RefCD_nID='" + Connection.SqlString(changeRD.RefNid) + "' " +
                      "where CD_nID =" + changeRD.CdId +" ");

            for (int i = 0; i < details.Count; i++)
            {
                sb.Append("update tbl_CHANGERESTDAY_DETAILS " +
                          "set sDesc='" + Connection.SqlString(details[i].Description) + "',sTotal='" + Connection.SqlString(details[i].Total) + 
                              "',sMonth1='" + Connection.SqlString(details[i].Month1) + "',sMonth2='" + Connection.SqlString(details[i].Month2) + 
                              "',sMonth3='" + Connection.SqlString(details[i].Month3) + "' " +
                          "where CD_nID=" + changeRD.CdId + " and nLine=" + details[i].Line + " ");
            }

            return connection.Execute(sb.ToString());
        }

        public static bool CancelChangeRestday(Connection connection,ChangeRestday changeRd) {

            string query = "update tbl_CHANGERESTDAY " +
                           "set nCancelled=1,sReasonCanc='" + Connection.SqlString(changeRd.ReasonCancelled) + "', "+
	                           "sLastUpdatedBy='" + Connection.SqlString(changeRd.LastUpdatedBy) + "' " +
                           "where CD_nID=" + changeRd.CdId + " ";

            return connection.Execute(query);
        }

        public static bool PostTransaction(Connection connection,ChangeRestday changeRd)
        {
            string query = "update tbl_CHANGERESTDAY " +
                           "set nPosted=1,sLastUpdatedBy='" + Connection.SqlString(changeRd.LastUpdatedBy) + "' " +
                           "where CD_nID=" + changeRd.CdId + " ";

            return connection.Execute(query);
        }
    }
}

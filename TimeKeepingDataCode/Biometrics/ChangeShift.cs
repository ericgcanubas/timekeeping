using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeKeepingDataCode.Biometrics
{
    public class ChangeShift
    {
        public int Id { get; set; }
        public string CntrlNo { get; set; }
        public DateTime DateApply { get; set; }
        public int EmpNo { get; set; }
        public string RefNo { get; set; }
        public DateTime DateEffect { get; set; }
        public TimeSpan TimeFrom { get; set; }
        public TimeSpan TimeTo { get; set; }
        public string Remarks { get; set; }
        public string NotedBy { get; set; }
        public string ApprovedBy { get; set; }
        public bool IsPosted { get; set; }
        public bool IsCancelled { get; set; }
        public string LastModified { get; set; }

        public ChangeShift(int id,string cntrlNo,DateTime dateApply,int empNo,string refNo,
            DateTime dateEffect,TimeSpan timeFrom,TimeSpan timeTo,string remarks,string notedBy,
            string approvedBy,bool isPosted,bool isCancelled,string lastModified)
        {
            this.Id = id;
            this.CntrlNo = cntrlNo;
            this.DateApply = dateApply;
            this.EmpNo = empNo;
            this.RefNo = refNo;
            this.DateEffect = dateEffect;
            this.TimeFrom = timeFrom;
            this.TimeTo = timeTo;
            this.Remarks = remarks;
            this.NotedBy = notedBy;
            this.ApprovedBy = approvedBy;
            this.IsPosted = isPosted;
            this.IsCancelled = isCancelled;
            this.LastModified = lastModified;
        }

        public static List<ChangeShift> GetAllChangeShift(Connection connection) 
        {
            return GetDatas(connection,QueryFilter(new FilterClause<int>(),new FilterClause<DateTime>(),
                new FilterClause<int>(),new FilterClause<bool>()));
        }

        public static List<ChangeShift> GetAllChangeShift(Connection connection,int empNo) 
        {
            return GetDatas(connection,QueryFilter(new FilterClause<int>(),new FilterClause<DateTime>(),
                new FilterClause<int>(empNo),new FilterClause<bool>()));
        }

        public static List<ChangeShift> GetAllChangeShift(Connection connection,int empNo,bool isPosted) 
        {
            return GetDatas(connection,QueryFilter(new FilterClause<int>(),new FilterClause<DateTime>(),
                new FilterClause<int>(empNo),new FilterClause<bool>(isPosted)));
        }

        public static List<ChangeShift> GetAllChangeShift(Connection connection, int empNo,DateTime dateCreated)
        {
            return GetDatas(connection, QueryFilter(new FilterClause<int>(), new FilterClause<DateTime>(dateCreated),
                new FilterClause<int>(empNo), new FilterClause<bool>()));
        }

        public static List<ChangeShift> GetAllChangeShift(Connection connection, int empNo, DateTime dateCreated,bool isPosted)
        {
            return GetDatas(connection, QueryFilter(new FilterClause<int>(), new FilterClause<DateTime>(dateCreated),
                new FilterClause<int>(empNo), new FilterClause<bool>(isPosted)));
        }

        public static ChangeShift GetChangeShift(Connection connection,int id) 
        {
            return GetData(connection,QueryFilter(new FilterClause<int>(id),new FilterClause<DateTime>(),
                new FilterClause<int>(),new FilterClause<bool>()));
        }

        private static string QueryFilter(FilterClause<int> id,FilterClause<DateTime> dateApply,
            FilterClause<int> empNo,FilterClause<bool> isposted) 
        {
            string idWhereClause = string.Empty;
            string dateApplyWhereClause = string.Empty;
            string empNoWhereClause = string.Empty;
            string isPostedWhereClause = string.Empty;

            if (id.IsFilter)
                idWhereClause = " and Id = " + id.Value + " ";
            if (dateApply.IsFilter)
                dateApplyWhereClause = " and DateApply = '" + dateApply.Value + "' ";
            if (empNo.IsFilter)
                empNoWhereClause = " and EmpNo = " + empNo.Value + " ";
            if(isposted.IsFilter)
                isPostedWhereClause = " and IsPosted = '" + isposted.Value + "' ";

            string query = "select Id,CtrlNo,DateApply,EmpNo,isnull(RefNo,'')RefNo,DateEffect, " +
                                  "TimeFrom,TimeTo,Remarks,isnull(NotedBy,'')NotedBy,ApprovedBy, " +
                                  "IsPosted,IsCancelled,LastModified " +
                           "from tbl_DChangeShift " +
                           "where 1=1 " + idWhereClause + dateApplyWhereClause + empNoWhereClause + isPostedWhereClause;
            return query;
        }

        private static List<ChangeShift> GetDatas(Connection connection,string query) 
        {
            List<ChangeShift> result = new List<ChangeShift>();
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result.Add(new ChangeShift(Convert.ToInt32(d.Rows[i]["Id"]), d.Rows[i]["CtrlNo"].ToString(),
                    Convert.ToDateTime(d.Rows[i]["DateApply"]), Convert.ToInt32(d.Rows[i]["EmpNo"]),
                    d.Rows[i]["RefNo"].ToString(), Convert.ToDateTime(d.Rows[i]["DateEffect"]),
                    Convert.ToDateTime(d.Rows[i]["TimeFrom"].ToString()).TimeOfDay, 
                    Convert.ToDateTime(d.Rows[i]["TimeTo"].ToString()).TimeOfDay,
                    d.Rows[i]["Remarks"].ToString(), d.Rows[i]["NotedBy"].ToString(),
                    d.Rows[i]["ApprovedBy"].ToString(), Convert.ToBoolean(d.Rows[i]["IsPosted"]),
                    Convert.ToBoolean(d.Rows[i]["IsCancelled"]),d.Rows[i]["LastModified"].ToString()));
            }
            return result;
        }

        private static ChangeShift GetData(Connection connection,string query) 
        {
            ChangeShift result = null;
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result = new ChangeShift(Convert.ToInt32(d.Rows[i]["Id"]), d.Rows[i]["CtrlNo"].ToString(),
                    Convert.ToDateTime(d.Rows[i]["DateApply"]), Convert.ToInt32(d.Rows[i]["EmpNo"]),
                    d.Rows[i]["RefNo"].ToString(), Convert.ToDateTime(d.Rows[i]["DateEffect"]),
                    Convert.ToDateTime(d.Rows[i]["TimeFrom"].ToString()).TimeOfDay, 
                    Convert.ToDateTime(d.Rows[i]["TimeTo"].ToString()).TimeOfDay,
                    d.Rows[i]["Remarks"].ToString(), d.Rows[i]["NotedBy"].ToString(),
                    d.Rows[i]["ApprovedBy"].ToString(), Convert.ToBoolean(d.Rows[i]["IsPosted"]), 
                    Convert.ToBoolean(d.Rows[i]["IsCancelled"]),d.Rows[i]["LastModified"].ToString());
            }
            return result;
        }

        public static string GenerateNewControlNo(Connection connection) {
            string query = "declare @ctrlNo varchar(12)= (select top 1 CtrlNo from tbl_DChangeShift order by Id desc); " +
                           "if @ctrlNo is null " +
	                           "begin " +
		                           "set @ctrlNo = cast(DATEPART(YEAR,GETDATE()) as varchar(4)) + '00000001'; " +
	                           "end; " +
                           "else " +
	                           "begin " +
		                           "if LEFT(@ctrlNo,4) != cast(DATEPART(YEAR,GETDATE()) as varchar(4)) " +
			                           "begin " +
				                           "set @ctrlNo = cast(DATEPART(YEAR,GETDATE()) as varchar(4)) + '00000001'; " +
			                           "end; " +
		                           "else " +
			                           "begin " +
				                           "declare @newCntrl varchar(8) = cast((cast(RIGHT(@ctrlNo,8) as int) + 1) as varchar(8)); " +
                                           "set @ctrlNo = LEFT(@ctrlNo,4) + left('00000000',8-LEN(@newCntrl)) + @newCntrl; " +
			                           "end; " +
	                           "end; " +
                           "select @ctrlNo NewControlNo ";

            var d = connection.GetData(query);

            return d.Rows[0]["NewControlNo"].ToString();
        }

        public static bool CreateChangeShift(Connection connection,ChangeShift changeShift) {
            string query = "declare @ctrlNo varchar(12)= (select top 1 CtrlNo from tbl_DChangeShift order by Id desc); " +
                           "if @ctrlNo is null " +
	                           "begin " +
		                           "set @ctrlNo = cast(DATEPART(YEAR,GETDATE()) as varchar(4)) + '00000001'; " +
	                           "end; " +
                           "else " +
	                           "begin " +
		                           "if LEFT(@ctrlNo,4) != cast(DATEPART(YEAR,GETDATE()) as varchar(4)) " +
			                           "begin " +
				                           "set @ctrlNo = cast(DATEPART(YEAR,GETDATE()) as varchar(4)) + '00000001'; " +
			                           "end; " +
		                           "else " +
			                           "begin " +
				                           "declare @newCntrl varchar(8) = cast((cast(RIGHT(@ctrlNo,8) as int) + 1) as varchar(8)); " +
                                           "set @ctrlNo = LEFT(@ctrlNo,4) + left('00000000',8-LEN(@newCntrl)) + @newCntrl; " +
			                           "end; " +
	                           "end; " +
                           "insert tbl_DChangeShift (CtrlNo,EmpNo,RefNo,DateEffect,TimeFrom, " +
	                           "TimeTo,Remarks,NotedBy,ApprovedBy,LastModified) " +
                           "values " +
	                           "(@ctrlNo," + changeShift.EmpNo + ",'" + Connection.SqlString(changeShift.RefNo) + 
                               "','" + changeShift.DateEffect + "','" + changeShift.TimeFrom + "', " +
	                           "'" + changeShift.TimeTo + "','" + Connection.SqlString(changeShift.Remarks) + 
                               "','" + Connection.SqlString(changeShift.NotedBy) + "','" + 
                               Connection.SqlString(changeShift.ApprovedBy) + "','" + Connection.SqlString(changeShift.LastModified) + "') ";
            return connection.Execute(query);
        }

        public static bool UpdateChangeShift(Connection connection,ChangeShift changeShift) {
            string query = "update tbl_DChangeShift " + 
                           "set RefNo='" + Connection.SqlString(changeShift.RefNo) + "',DateEffect='" + changeShift.DateEffect + "',TimeFrom='" + changeShift.TimeFrom + "', " +
	                           "TimeTo='" + changeShift.TimeTo + "',Remarks='" + Connection.SqlString(changeShift.Remarks) + "',NotedBy='" + Connection.SqlString(changeShift.NotedBy) + "', " +
	                           "ApprovedBy='" + Connection.SqlString(changeShift.ApprovedBy) + "',LastModified='" + Connection.SqlString(changeShift.LastModified) + "' " +
                           "where Id=" + changeShift.Id + " ";

            return connection.Execute(query);
        }

        public static bool PostChangeShift(Connection connection,ChangeShift changeShift) {
            string query = "update tbl_DChangeShift " +
                           "set IsPosted=1,LastModified='" + Connection.SqlString(changeShift.LastModified) + "' " +
                           "where Id=" + changeShift.Id + " ";
            return connection.Execute(query);
        }

        public static bool CancelChangeShift(Connection connection,ChangeShift changeShift) 
        {
            string query = "update tbl_DChangeShift " +
                           "set IsCancelled=1,LastModified='" + Connection.SqlString(changeShift.LastModified) + "' " +
                           "where Id=" + changeShift.Id + " ";

            return connection.Execute(query);
        }
    }
}

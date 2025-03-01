using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeKeepingDataCode.Biometrics
{
    public class CasherCheckerAssignSchedule
    {
        public int Id { get; set; }
        public string TransactionNo { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateEffect { get; set; }
        public string ApprovedBy { get; set; }
        public bool IsPosted { get; set; }
        public bool IsCancelled { get; set; }
        public string CancelledReason { get; set; }
        public string CreatedBy { get; set; }
        public string LastModified { get; set; }

        public CasherCheckerAssignSchedule(int id,string transactionNo,DateTime dateCreated,
            DateTime dateEffect,string approvedBy,bool isPosted,bool isCancelled,
            string cancelledReason,string createdBy,string lastModified)
        {
            this.Id = id;
            this.TransactionNo = transactionNo;
            this.DateCreated = dateCreated;
            this.DateEffect = dateEffect;
            this.ApprovedBy = approvedBy;
            this.IsPosted = isPosted;
            this.IsCancelled = isCancelled;
            this.CancelledReason = cancelledReason;
            this.CreatedBy = createdBy;
            this.LastModified = lastModified;
        }

        public static List<CasherCheckerAssignSchedule> GetAllCasherCheckerSchedule(Connection connection) 
        {
            return GetDatas(connection,QueryFilter(new FilterClause<int>(),
                new FilterClause<string>(),new FilterClause<DateTime>()));
        }

        public static List<CasherCheckerAssignSchedule> GetAllCasherCheckerSchedule(Connection connection,int top)
        {
            return GetDatas(connection,QueryFilterPaging(new FilterClause<int>(top),new FilterClause<int>()));
        }

        public static List<CasherCheckerAssignSchedule> GetAllCasherCheckerSchedule(Connection connection, int top, int id)
        {
            return GetDatas(connection, QueryFilterPaging(new FilterClause<int>(top), new FilterClause<int>(id)));
        }

        private static string QueryFilter(FilterClause<int> id,FilterClause<string> transactionNo,
            FilterClause<DateTime> dateCreated) 
        {
            string idWhereClause = string.Empty;
            string transactionNoWhereClause = string.Empty;
            string dateCreatedWhereClause = string.Empty;

            if (id.IsFilter)
                idWhereClause = " and Id = " + id.Value + " ";
            if (transactionNo.IsFilter)
                transactionNoWhereClause = " and TransactionNo = " + transactionNo.Value + " ";
            if (dateCreated.IsFilter)
                dateCreatedWhereClause = " and DateCreated = '" + dateCreated.Value + "' ";

            string query = "select Id,TransactionNo,DateCreated,DateEffect, " +
                                  "isnull(ApprovedBy,'')ApprovedBy,IsPosted,IsCancelled, " +
                                  "isnull(CancelledReason,'')CancelledReason, " +
                                  "CreatedBy,isnull(LastModified,'')LastModified " +
                           "from tbl_DCasherCheckerAssignedSchedule " +
                           "where 1=1 ";
            return query;
        }

        private static string QueryFilterPaging(FilterClause<int> top,FilterClause<int> id) {
            string topWhereClause = string.Empty;
            string idWhereClause = string.Empty;

            if (top.IsFilter)
                topWhereClause = " top " + top.Value;
            if (id.IsFilter)
                idWhereClause = " where Id > " + id.Value + " ";

            string query = "select " + topWhereClause + " Id,TransactionNo,DateCreated,DateEffect, " +
                                  "isnull(ApprovedBy,'')ApprovedBy,IsPosted,IsCancelled, " +
                                  "isnull(CancelledReason,'')CancelledReason, " +
                                  "CreatedBy,isnull(LastModified,'')LastModified " +
                           "from tbl_DCasherCheckerAssignedSchedule " + idWhereClause +
                           "order by Id desc ";
            return query;
        }

        private static List<CasherCheckerAssignSchedule> GetDatas(Connection connection,string query) 
        {
            List<CasherCheckerAssignSchedule> result = new List<CasherCheckerAssignSchedule>();
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result.Add(new CasherCheckerAssignSchedule(Convert.ToInt32(d.Rows[i]["Id"]),
                    d.Rows[i]["TransactionNo"].ToString(), Convert.ToDateTime(d.Rows[i]["DateCreated"]),
                    Convert.ToDateTime(d.Rows[i]["DateEffect"]), d.Rows[i]["ApprovedBy"].ToString(),
                    Convert.ToBoolean(d.Rows[i]["IsPosted"]), Convert.ToBoolean(d.Rows[i]["IsCancelled"]),
                    d.Rows[i]["CancelledReason"].ToString(), d.Rows[i]["CreatedBy"].ToString(),
                    d.Rows[i]["LastModified"].ToString()));
            }
            return result;
        }

        private static CasherCheckerAssignSchedule GetData(Connection connection,string query) {
            CasherCheckerAssignSchedule result = null;
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result = new CasherCheckerAssignSchedule(Convert.ToInt32(d.Rows[i]["Id"]),
                    d.Rows[i]["TransactionNo"].ToString(), Convert.ToDateTime(d.Rows[i]["DateCreated"]),
                    Convert.ToDateTime(d.Rows[i]["DateEffect"]), d.Rows[i]["ApprovedBy"].ToString(),
                    Convert.ToBoolean(d.Rows[i]["IsPosted"]), Convert.ToBoolean(d.Rows[i]["IsCancelled"]),
                    d.Rows[i]["CancelledReason"].ToString(), d.Rows[i]["CreatedBy"].ToString(),
                    d.Rows[i]["LastModified"].ToString());
            }
            return result;
        }

        public static bool CreateCasherCheckerSchedule(Connection connection,CasherCheckerAssignSchedule assigneSchedule,
            List<CasherCheckerAssignedDetails> details,List<CasherCheckerAssignedEmployeeDetails> employees) 
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("declare @transactionNo varchar(10) = " +
	                  "(select top 1 TransactionNo from tbl_DCasherCheckerAssignedSchedule order by Id desc); ");
            sb.Append("declare @generatedTransactionNo varchar(10); ");

            sb.Append("if @transactionNo is null " +
	                      "begin " +
		                      "set @generatedTransactionNo = cast(DATEPART(YY,GetDate()) as varchar(4)) + '000001'; " +
	                      "end; " +
                      "else " +
	                      "begin " +
		                      "if Left(@transactionNo,4) = cast(DATEPART(YY,GetDate()) as varchar(4)) " +
			                      "begin " +
				                      "declare @gen varchar(6) = cast((cast(RIGHT(@transactionNo,6) as int) + 1) as varchar(6)); " +
				                      "set @generatedTransactionNo = Left(@transactionNo,4) + left('000000',6-LEN(@gen)) + @gen; " +
			                      "end; " +
		                      "else " +
			                      "begin " +
				                      "set @generatedTransactionNo = cast(DATEPART(YY,GetDate()) as varchar(4)) + '000001'; " +
			                      "end; " +
	                      "end; ");

            sb.Append("insert tbl_DCasherCheckerAssignedSchedule " +
	                      "(TransactionNo,DateEffect,ApprovedBy,CreatedBy) " +
                      "values (@generatedTransactionNo,'" + assigneSchedule.DateEffect + "','" + 
                      Connection.SqlString(assigneSchedule.ApprovedBy) + "','" + Connection.SqlString(assigneSchedule.CreatedBy) + "') ");

            sb.Append("declare @Id int = (select MAX(Id) from tbl_DCasherCheckerAssignedSchedule); ");

            for (int i = 0; i < details.Count; i++)
            {
                sb.Append("insert tbl_DCasherCheckerAssignedScheduleDetails " +
                          "values (@Id,'" + Connection.SqlString(details[i].CType) + "'," + details[i].EmpId + 
                          ",'" + Connection.SqlString(details[i].POS) + "','" + Connection.SqlString(details[i].Restday) + 
                          "'," + details[i].MondayShifitng + "," + details[i].TuesdayShifting + "," + details[i].WednesdayShifting + 
                          "," + details[i].ThursdayShifting + "," + details[i].FridayShifting + "," +  
                          details[i].SaturdayShifting+ "," + details[i].SundayShifting + ",'" + 
                          Connection.SqlString(details[i].IdNumber) + "','" + Connection.SqlString(details[i].EmpName) + "') ");
            }

            for (int i = 0; i < employees.Count; i++)
            {
                sb.Append("insert tbl_DCasherCheckerAssignedScheduleEmployeeDetails values " + 
                    "(@Id,'" + employees[i].CType + "'," + employees[i].EmpId + ",'" + employees[i].IsAssigned + "') ");
            }

            return connection.Execute(sb.ToString());
        }

        public static bool UpdateCasherCheckerSchedule(Connection connection, CasherCheckerAssignSchedule assigneSchedule,
            List<CasherCheckerAssignedEmployeeDetails> employeeDetails, List<CasherCheckerAssignedDetails> details) 
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("update tbl_DCasherCheckerAssignedSchedule " +
                      "set DateEffect='" + assigneSchedule.DateEffect + "',ApprovedBy='" + 
                      Connection.SqlString(assigneSchedule.ApprovedBy) + "', " +
	                      "LastModified='" + Connection.SqlString(assigneSchedule.LastModified) + "' " +
                      "where Id=" + assigneSchedule.Id + " ");

            sb.Append("declare @tmpEmployeeDetails table(Id int,CasherCheckerId int, " +
	                  "CType varchar(20),EmpId int,IsAssigned bit) ");

            for (int i = 0; i < employeeDetails.Count; i++)
            {
                sb.Append("insert @tmpEmployeeDetails values(0," + assigneSchedule.Id + ",'" + 
                    Connection.SqlString(employeeDetails[i].CType) + "'," + employeeDetails[i].EmpId + ",'" + employeeDetails[i].IsAssigned + "') ");
            }

            sb.Append("update a " +
                      "set a.IsAssigned=b.IsAssigned " +
                      "from tbl_DCasherCheckerAssignedScheduleEmployeeDetails a " +
                      "join @tmpEmployeeDetails b on a.CasherCheckerAssignedId=b.CasherCheckerId and a.EmpId=b.EmpId ");

            sb.Append("declare @tmpDetails table(Id int,CasherCheckerId int,Ctype varchar(10), " +
                          "EmpId int,POS varchar(5),Restday varchar(20),Monday int,Tuesday int, " +
                          "Wednesday int,Thursday int,Friday int,Saturday int,Sunday int,IdNumber varchar(100),EmpName varchar(100)) ");

            for (int i = 0; i < details.Count; i++)
            {
                sb.Append("insert @tmpDetails values(" + details[i].Id + "," + assigneSchedule.Id + ",'" +
                          Connection.SqlString(details[i].CType) + "'," + details[i].EmpId + ",'" + Connection.SqlString(details[i].POS) +
                          "','" + Connection.SqlString(details[i].Restday) + "'," + details[i].MondayShifitng +
                          "," + details[i].TuesdayShifting + "," + details[i].WednesdayShifting + "," + details[i].ThursdayShifting +
                          "," + details[i].FridayShifting + "," + details[i].SaturdayShifting + "," + 
                          details[i].SundayShifting + ",'" + Connection.SqlString(details[i].IdNumber) + "','" + Connection.SqlString(details[i].EmpName) + "') ");
            }

            sb.Append("delete a " +
                      "from tbl_DCasherCheckerAssignedScheduleDetails a " +
                      "left join @tmpDetails b on a.CasherCheckerAssignedId = b.CasherCheckerId and a.EmpId = b.EmpId " +
                      "where b.CasherCheckerId is null and b.EmpId is null and a.CasherCheckerAssignedId = " + assigneSchedule.Id + " ");

            sb.Append("update a " +
                      "set a.CType=b.Ctype,a.POS=b.POS,a.Restday=b.Restday, " +
	                      "a.MondayShifting=b.Monday,a.TuesdayShifting=b.Tuesday, " +
	                      "a.WednesdayShifting=b.Wednesday,a.ThursdayShifting=b.Thursday, " +
	                      "a.FridayShifting=b.Friday,a.SaturdayShifting=b.Saturday, " +
	                      "a.SundayShifting=b.Sunday " +
                      "from tbl_DCasherCheckerAssignedScheduleDetails a " +
                      "join @tmpDetails b on a.CasherCheckerAssignedId = b.CasherCheckerId and a.EmpId = b.EmpId ");

            sb.Append("insert tbl_DCasherCheckerAssignedScheduleDetails " +
                      "select " + assigneSchedule.Id + ",b.Ctype,b.EmpId,b.POS,b.Restday,b.Monday,b.Tuesday, " +
	                         "b.Wednesday,b.Thursday,b.Friday,b.Saturday,b.Sunday,b.IdNumber,b.EmpName " +
                      "from tbl_DCasherCheckerAssignedScheduleDetails a " +
                      "right join @tmpDetails b on a.CasherCheckerAssignedId = b.CasherCheckerId and a.EmpId = b.EmpId " +
                      "where a.CasherCheckerAssignedId is null and a.EmpId is null and a.CasherCheckerAssignedId = " + assigneSchedule.Id + " ");

            sb.Append("declare @tmpWarehouse table (Id int,CasherCheckerAssignId int, " +
	                  "Ctype varchar(10),EmpId int,Restday varchar(20), " +
	                  "MondayShifting int,TuesdayShifting int,WednesdayShifting int, " +
	                  "ThursdayShifting int,FridayShifting int,SaturdayShifting int, " +
	                  "SundayShifting int,IdNumber varchar(100),EmpName varchar(100)); ");

            return connection.Execute(sb.ToString());
        }

        public static CasherCheckerAssignSchedule Empty {
            get {
                return new CasherCheckerAssignSchedule(0,string.Empty,new DateTime(),
                    new DateTime(),string.Empty,false,false,string.Empty,string.Empty,string.Empty);
            }
        }

        public static bool PostAssignedSchedule(Connection connection,CasherCheckerAssignSchedule assignedSchedule) 
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("declare @id int = " + assignedSchedule.Id + "; " +
                      "declare @createdBy varchar(50) = '" + assignedSchedule.CreatedBy + " - " + connection.ServerDate() + "' ");

            sb.Append("update tbl_DCasherCheckerAssignedSchedule " +
                      "set IsPosted = 1 " +
                      "where Id = @id; ");

            sb.Append("declare @dateEffect date = (select DateEffect from tbl_DCasherCheckerAssignedSchedule where Id = @id); ");

            sb.Append("insert EmployeeShifting (EmpNo,EmpId,EmpName,Monday,Tuesday,Wednesday, " +
	                      "Thursday,Friday,Saturday,Sunday,MachineId,MachineNo, " +
                          "EffectDate,LastModified,Restday) " +
                      "select a.EmpId,a.IdNumber,a.EmpName,a.MondayShifting,a.TuesdayShifting,a.WednesdayShifting, " +
	                         "a.ThursdayShifting,a.FridayShifting,a.SaturdayShifting,a.SundayShifting, " +
                             "a.MachineId,a.MachineNo,@dateEffect DateEffect,@createdBy LastModified, " +
	                         "Restday = case when a.Restday = 'monday' then 1 " +
					                        "when a.Restday = 'tuesday' then 2 " +
					                        "when a.Restday = 'wednesday' then 3 " +
					                        "when a.Restday = 'thursday' then 4 " +
					                        "when a.Restday = 'friday'  then 5 " +
					                        "when a.Restday = 'saturday' then 6 " +
					                        "when a.Restday = 'sunday' then 7 " +
				                      "end " +
                      "from ( " +
                          "SELECT a.EmpId,a.IdNumber,a.EmpName,a.Restday,a.MondayShifting,a.TuesdayShifting, " +
		                         "a.WednesdayShifting,a.ThursdayShifting,a.FridayShifting, " +
		                         "a.SaturdayShifting,a.SundayShifting,b.MachineId,b.MachineNo, " +
		                         "Row = ROW_NUMBER() over (partition by a.EmpId order by b.EffectDate desc) " +
	                      "FROM tbl_DCasherCheckerAssignedScheduleDetails a " +
                          "join EmployeeShifting b on a.EmpId = b.EmpNo " + 
	                      "where CasherCheckerAssignedId = @id ) a " +
                      "where a.Row = 1 ");

            sb.Append("insert EmployeeShifting(EmpNo,EmpId,EmpName,Monday,Tuesday,Wednesday, " +
	                      "Thursday,Friday,Saturday,Sunday,MachineId,MachineNo, " +
                          "EffectDate,LastModified,Restday) " +
                      "select a.EmpId,a.IdNumber,a.EmpName,a.MondayShifting,a.TuesdayShifting,a.WednesdayShifting, " +
	                         "a.ThursdayShifting,a.FridayShifting,a.SaturdayShifting,a.SundayShifting, " +
                             "a.MachineId,a.MachineNo,@dateEffect DateEffect,@createdBy LastModified, " +
	                         "Restday = case when a.Restday = 'monday' then 1 " +
					                        "when a.Restday = 'tuesday' then 2 " +
					                        "when a.Restday = 'wednesday' then 3 " +
					                        "when a.Restday = 'thursday' then 4 " +
					                        "when a.Restday = 'friday'  then 5 " +
					                        "when a.Restday = 'saturday' then 6 " +
					                        "when a.Restday = 'sunday' then 7 " +
				                      "end " +
                      "from ( " +
                          "SELECT a.EmpId,a.IdNumber,a.EmpName,a.Restday,a.MondayShifting,a.TuesdayShifting, " +
		                         "a.WednesdayShifting,a.ThursdayShifting,a.FridayShifting, " +
		                         "a.SaturdayShifting,a.SundayShifting,b.MachineId,b.MachineNo, " +
		                         "Row = ROW_NUMBER() over (partition by a.EmpId order by b.EffectDate desc) " +
	                      "FROM tbl_DCasherCheckerWarehouseList a " +
                          "join EmployeeShifting b on a.EmpId = b.EmpNo " +
	                      "where CasherCheckerAssignedId = @id ) a " +
                      "where a.Row = 1 ");

            return connection.Execute(sb.ToString());
        }

        public static bool CancelAssignedSchedule(Connection connection,CasherCheckerAssignSchedule schedule) 
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("declare @id int = " + schedule.Id + "; ");

            sb.Append("update tbl_DCasherCheckerAssignedSchedule " +
                      "set IsCancelled = 1 " +
                      "where Id = @id ");

            if (schedule.IsPosted) 
            {
                sb.Append("delete c " +
                          "from tbl_DCasherCheckerAssignedSchedule a " +
                          "join tbl_DCasherCheckerAssignedScheduleDetails b " +
	                           "on a.Id = b.CasherCheckerAssignedId " +
                          "join EmployeeShifting c on " +
	                           "b.EmpId = c.EmpNo and cast(a.DateEffect as date) = cast(c.EffectDate as date) " +
                          "where a.Id = @id ");

                sb.Append("delete c " +
                          "from tbl_DCasherCheckerAssignedSchedule a " +
                          "join tbl_DCasherCheckerWarehouseList b " +
                             "on a.Id = b.CasherCheckerAssignedId " +
                          "join EmployeeShifting c on " +
                             "b.EmpId = c.EmpNo and cast(a.DateEffect as date) = cast(c.EffectDate as date) " +
                          "where a.Id = @id ");
            }

            return connection.Execute(sb.ToString());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace TimeKeepingDataCode.Biometrics
{
    public class WholeDayChangeShift
    {
        public int Pk { get; set; }
        public string ControlNo { get; set; }
        public DateTime DateApply { get; set; }
        public int EmpNo { get; set; }
        public string RefNo { get; set; }
        public int Shift { get; set; }
        public DateTime DateEffective { get; set; }
        public string Remarks { get; set; }
        public string NotedBy { get; set; }
        public string ApprovedBy { get; set; }
        public bool IsPosted { get; set; }
        public int Activate { get; set; }
        public string LastModified { get; set; }

        public WholeDayChangeShift(int pk, string cntrlNo,DateTime dateApply,
             int empNo,string refNo,int shift,DateTime dateEffect,string remarks,
            string notedBy,string approvedBy,bool isPosted,int activate,string lastModified)
        {
            this.Pk = pk;
            this.ControlNo = cntrlNo;
            this.DateApply = dateApply;
            this.EmpNo = empNo;
            this.RefNo = refNo;
            this.Shift = shift;
            this.DateEffective = dateEffect;
            this.Remarks = remarks;
            this.NotedBy = notedBy;
            this.ApprovedBy = approvedBy;
            this.IsPosted = isPosted;
            this.Activate = activate;
            this.LastModified = lastModified;
        }

        public static List<WholeDayChangeShift> GetAllChangeShift(Connection connection) 
        {
            return GetDatas(connection,QueryFilter(new FilterClause<int>(),new FilterClause<int>(),new FilterClause<DateTime>()));
        }

        public static List<WholeDayChangeShift> GetAllChangeShift(Connection connection, int empNo) 
        {
            return GetDatas(connection,QueryFilter(new FilterClause<int>(),new FilterClause<int>(empNo),new FilterClause<DateTime>()));
        }

        public static List<WholeDayChangeShift> GetAllChangeShift(Connection connection, int empNo,DateTime dateEffect)
        {
            return GetDatas(connection, QueryFilter(new FilterClause<int>(), new FilterClause<int>(empNo), new FilterClause<DateTime>(dateEffect)));
        }

        public static WholeDayChangeShift GetChangeShift(Connection connection,int pk)
        {
            return GetData(connection,QueryFilter(new FilterClause<int>(pk),new FilterClause<int>(),new FilterClause<DateTime>()));
        }

        private static string QueryFilter(FilterClause<int> pk,FilterClause<int> empNo,FilterClause<DateTime> effectDate) 
        {
            string pkWhereClause = string.Empty;
            string empNoWhereClause = string.Empty;
            string effectDateWhereClause = string.Empty;

            if (pk.IsFilter)
                pkWhereClause = " and PK =" + pk.Value + " ";
            if (empNo.IsFilter)
                empNoWhereClause = " and EmpNo =" + empNo.Value + " ";
            if (effectDate.IsFilter)
                effectDateWhereClause = " and EffectDate = '" + effectDate.Value + "' ";

            string result = "SELECT PK,CtrlNo,DDate,EmpNo,isnull(RefNo,'')RefNo,Shift,EffectDate, " +
                                  "isnull(Remarks,'')Remarks,isnull(NotedBy,'')NotedBy, " +
                                  "isnull(ApprovedBy,'')ApprovedBy,isnull(Posted,'')Posted, " +
                                  "isnull(Activate,'')Activate,isnull(LastModified,'')LastModified " +
                            "FROM ChangeShift " +
                            "where 1=1 " + pkWhereClause + empNoWhereClause + effectDateWhereClause;
            return result;
        }

        private static List<WholeDayChangeShift> GetDatas(Connection connection, string query) 
        {
            List<WholeDayChangeShift> result = new List<WholeDayChangeShift>();
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result.Add(new WholeDayChangeShift(Convert.ToInt32(d.Rows[i]["PK"]), d.Rows[i]["CtrlNo"].ToString(),
                    Convert.ToDateTime(d.Rows[i]["DDate"]), Convert.ToInt32(d.Rows[i]["EmpNo"]),
                    d.Rows[i]["RefNo"].ToString(), Convert.ToInt32(d.Rows[i]["Shift"]),
                    Convert.ToDateTime(d.Rows[i]["EffectDate"]), d.Rows[i]["Remarks"].ToString(),
                    d.Rows[i]["NotedBy"].ToString(), d.Rows[i]["ApprovedBy"].ToString(),
                    Convert.ToBoolean(d.Rows[i]["Posted"]), Convert.ToInt32(d.Rows[i]["Activate"]),
                    d.Rows[i]["LastModified"].ToString()));
            }
            return result;
        }

        private static WholeDayChangeShift GetData(Connection connection,string query) 
        {
            WholeDayChangeShift result = null;
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result = new WholeDayChangeShift(Convert.ToInt32(d.Rows[i]["PK"]), d.Rows[i]["CtrlNo"].ToString(),
                    Convert.ToDateTime(d.Rows[i]["DDate"]), Convert.ToInt32(d.Rows[i]["EmpNo"]),
                    d.Rows[i]["RefNo"].ToString(), Convert.ToInt32(d.Rows[i]["Shift"]),
                    Convert.ToDateTime(d.Rows[i]["EffectDate"]), d.Rows[i]["Remarks"].ToString(),
                    d.Rows[i]["NotedBy"].ToString(), d.Rows[i]["ApprovedBy"].ToString(),
                    Convert.ToBoolean(d.Rows[i]["Posted"]), Convert.ToInt32(d.Rows[i]["Activate"]),
                    d.Rows[i]["LastModified"].ToString());
            }
            return result;
        }

        public static string GenerateNewControlNo(Connection connection) 
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("declare @lastCntrlNo varchar(10) = (select top 1 CtrlNo from ChangeShift order by PK desc); ");
            sb.Append("declare @resultCntrlNo varchar(10); ");

            sb.Append("if(@lastCntrlNo is null) " +
	                       "begin " +
		                       "set @resultCntrlNo = cast(DATEPART(Year,GetDate()) as varchar(4)) + '000001'; " +
	                       "end; " +
                      "else " +
	                       "begin " +
		                       "if(Left(@lastCntrlNo,4) != cast(DATEPART(Year,GETDATE()) as varchar(4))) " +
			                       "begin " +
				                       "set @resultCntrlNo = cast(DATEPART(Year,GetDate()) as varchar(4)) + '000001'; " +
			                       "end " +
		                       "else " +
			                       "declare @n varchar(6) = cast(cast(Right(@lastCntrlNo,6) as int) + 1 as varchar(6)); " +
			                       "set @resultCntrlNo = LEFT(@lastCntrlNo,4) + LEft('000000',6 - LEN(@n)) + @n " +
	                       "end; ");
            sb.Append("select @resultCntrlNo GeneratedCntrlNo ");

            var d = connection.GetData(sb.ToString());
            if (d.Rows.Count > 0)
                return d.Rows[0]["GeneratedCntrlNo"].ToString();
            else
                return string.Empty;
        }

        public static bool CreateWholeChangeShift(Connection connection,WholeDayChangeShift wholeChangeShift) 
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("declare @lastCntrlNo varchar(10) = (select top 1 CtrlNo from ChangeShift order by PK desc); ");
            sb.Append("declare @resultCntrlNo varchar(10); ");
            sb.Append("if(@lastCntrlNo is null) " +
	                      "begin " +
		                      "set @resultCntrlNo = cast(DATEPART(Year,GetDate()) as varchar(4)) + '000001'; " +
	                      "end; " +
                      "else " +
	                      "begin " +
		                      "if(Left(@lastCntrlNo,4) != cast(DATEPART(Year,GETDATE()) as varchar(4))) " +
			                      "begin " +
				                      "set @resultCntrlNo = cast(DATEPART(Year,GetDate()) as varchar(4)) + '000001'; " +
			                      "end " +
		                      "else " +
			                      "declare @n varchar(6) = cast(cast(Right(@lastCntrlNo,6) as int) + 1 as varchar(6)); " +
			                      "set @resultCntrlNo = LEFT(@lastCntrlNo,4) + LEft('000000',6 - LEN(@n)) + @n " +
	                      "end; ");
            sb.Append("insert ChangeShift (CtrlNo,DDate,EmpNo,RefNo,Shift,EffectDate,Remarks,NotedBy,ApprovedBy) values (@resultCntrlNo,GETDATE()," + wholeChangeShift.EmpNo + 
                        ",'" + Connection.SqlString(wholeChangeShift.RefNo) + "'," + wholeChangeShift.Shift + 
                        ",'" + wholeChangeShift.DateEffective + "','" + Connection.SqlString(wholeChangeShift.Remarks) + 
                        "','" + Connection.SqlString(wholeChangeShift.NotedBy) + "','" + Connection.SqlString(wholeChangeShift.ApprovedBy) + "' ) ");

            return connection.Execute(sb.ToString());
        }

        public static bool UpdateChangeShift(Connection connection,WholeDayChangeShift wholeDayChangeShift)
        {
            string query = "update ChangeShift " +
                           "set RefNo='" + Connection.SqlString(wholeDayChangeShift.RefNo) + "',Shift=" + wholeDayChangeShift.Shift + 
                           ",EffectDate='" + wholeDayChangeShift.DateEffective.ToShortDateString() + "', " +
	                            "Remarks='" + Connection.SqlString(wholeDayChangeShift.Remarks) + "',NotedBy='" + 
                                Connection.SqlString(wholeDayChangeShift.NotedBy) + "',ApprovedBy='" + Connection.SqlString(wholeDayChangeShift.ApprovedBy) + "', " +
	                            "LastModified='" + Connection.SqlString(wholeDayChangeShift.LastModified) + "' " +
                           "where PK=" + wholeDayChangeShift.Pk + " ";

            return connection.Execute(query);
        }

        public static bool PostChangeShift(Connection connection,WholeDayChangeShift wholeDayChangeshift) 
        {
            string query = "update ChangeShift " +
                           "set Posted = 1,LastModified='" + Connection.SqlString(wholeDayChangeshift.LastModified) + "' " +
                           "where PK = " + wholeDayChangeshift.Pk + " ";

            return connection.Execute(query);
        }

        public static bool UnPostChangeShift(Connection connection,WholeDayChangeShift wholeDayChangeShift ) 
        {
            string query = "update ChangeShift set Posted = 0 " +
                           "where PK =" + wholeDayChangeShift.Pk + " ";
            return connection.Execute(query);
        }

        //public stat
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeKeepingDataCode.Biometrics
{
    public class TimeSummary
    {
        #region Declarations
        public int Pk { get; set; }
        public int EmpNo { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int EmpPam { get; set; }
        public double TotalHours { get; set; }
        public double SL { get; set; }
        public double SH { get; set; }
        public double LH { get; set; }
        public double SH_OT { get; set; }
        public double LH_OT { get; set; }
        public double RD { get; set; }
        public double REG_OT { get; set; }
        public double MidNight { get; set; }
        public double Clearing { get; set; }
        public bool IsLocked { get; set; }
        public bool IsUploaded { get; set; }
        public bool IsUnLocked { get; set; }
        public string LastModified { get; set; }
        public int Hired { get; set; }
        public string AgencyName { get; set; }
        public int DepId { get; set; }
        public string DepartmentName { get; set; }
        public int SectSort { get; set; }
        public int SectionId { get; set; }
        public string SectionName { get; set; }
        public int PClass_Back { get; set; }
        public int EGroup { get; set; }
        public string Supplier { get; set; }
        public int PostId { get; set; }
        public int EmpStatus { get; set; }
        public string TIN { get; set; }
        public DateTime DateHired { get; set; }
        public int Compensation { get; set; }
        public string PostName { get; set; }
        public string Remarks { get; set; }
        public string AdjustmentCntrlNo { get; set; }
        public DateTime KanusaLast { get; set; }
        #endregion

        public TimeSummary(int pk,int empNo,DateTime dateFrom,DateTime dateTo,
            int empPam,double totalHours,double sl,double sh,double lh,double sh_ot,
            double lh_ot,double rd,double reg_out,double midNight,double clearing,
            bool isLocked,bool isUploaded,bool isUnLocked,string lastModified,
            int hired,string agencyName,int depId,string departmentName,int secSort,
            int sectionId,string sectionName,int pcClass_back,int egroup,
            string supplier,int postId,int empStatus,string tin,DateTime dateHired,
            int compensation,string postname,string remarks,string adjustmentCntrlNo,
            DateTime kanusLast)
        {
            this.Pk = pk;
            this.EmpNo = empNo;
            this.DateFrom = dateFrom;
            this.DateTo = dateTo;
            this.EmpPam = empPam;
            this.TotalHours = totalHours;
            this.SL = sl;
            this.SH = sh;
            this.LH = lh; this.SH_OT = sh_ot;
            this.LH_OT = lh_ot;
            this.RD = rd;
            this.REG_OT = reg_out;
            this.MidNight = midNight;
            this.Clearing = clearing;
            this.IsLocked = isLocked;
            this.IsUploaded = isUploaded;
            this.IsUnLocked = isUnLocked;
            this.LastModified = lastModified;
            this.Hired = hired;
            this.AgencyName = agencyName;
            this.DepId = depId;
            this.DepartmentName = departmentName;
            this.SectSort = secSort;
            this.SectionId = sectionId;
            this.SectionName = sectionName;
            this.PClass_Back = pcClass_back;
            this.EGroup = egroup;
            this.Supplier = supplier;
            this.PostId = postId;
            this.EmpStatus = empStatus;
            this.TIN = tin;
            this.DateHired = dateHired;
            this.Compensation = compensation;
            this.PostName = postname;
            this.Remarks = remarks;
            this.AdjustmentCntrlNo = adjustmentCntrlNo;
            this.KanusaLast = kanusLast;
        }

        private static string QueryFilter(FilterClause<int> pk,FilterClause<int> empNo,FilterClause<DateTime> dateFrom,FilterClause<DateTime> dateTo)
        {
            string pkWhereClause = string.Empty;
            string empNoWhereClause = string.Empty;
            string dateFromWhereClause = string.Empty;
            string dateToWhereClause = string.Empty;

            if (pk.IsFilter)
                pkWhereClause = " and PK = " + pk.Value + " ";
            if (empNo.IsFilter)
                empNoWhereClause = " and EmpNo = " + empNo.Value + " ";
            if (dateFrom.IsFilter)
                dateFromWhereClause = " and DateFrom = '" + dateFrom.Value.ToShortDateString() + "' ";
            if (dateTo.IsFilter)
                dateToWhereClause = "  and DateTo = '" + dateTo.Value.ToShortDateString() + "' ";

            string query = "SELECT PK,EmpNo,DateFrom,DateTo,EmpPam,NoHours,SL, " +
                                  "SH,LH,SH_OT,LH_OT,RD,REG_OT,MidNight,Clearing,Locked, " +
                                  "Uploaded,Unlocked,isnull(LastModified,'')LastModified,Hired, " +
                                  "AgencyName,DeptID,DeptName,SectSort,SectID,SectName, " +
                                  "PClass_Back,EGroup,Supplier,PostID,EmpStatus,Tin, " +
                                  "isnull(DateHired,'1901-01-01')DateHired,Compensation, " +
                                  "PostName,Remarks,isnull(AdjustmentCtrl,'')AdjustmentCtrl, " +
                                  "KanusaLast " +
                           "FROM Time_Summary " +
                           "where 1=1 " + pkWhereClause + empNoWhereClause + dateFromWhereClause + dateToWhereClause;

            return query;
        }

        private static string QueryFilterLocked(FilterClause<int> pk, FilterClause<int> empNo, FilterClause<DateTime> dateFrom, FilterClause<DateTime> dateTo)
        {
            string pkWhereClause = string.Empty;
            string empNoWhereClause = string.Empty;
            string dateFromWhereClause = string.Empty;
            string dateToWhereClause = string.Empty;

            if (pk.IsFilter)
                pkWhereClause = " and PK = " + pk.Value + " ";
            if (empNo.IsFilter)
                empNoWhereClause = " and EmpNo = " + empNo.Value + " ";
            if (dateFrom.IsFilter)
                dateFromWhereClause = " and DateFrom = '" + dateFrom.Value.ToShortDateString() + "' ";
            if (dateTo.IsFilter)
                dateToWhereClause = "  and DateTo = '" + dateTo.Value.ToShortDateString() + "' ";

            string query = "SELECT PK,EmpNo,DateFrom,DateTo,EmpPam,NoHours,SL, " +
                                  "SH,LH,SH_OT,LH_OT,RD,REG_OT,MidNight,Clearing,Locked, " +
                                  "Uploaded,Unlocked,isnull(LastModified,'')LastModified,Hired, " +
                                  "AgencyName,DeptID,DeptName,SectSort,SectID,SectName, " +
                                  "PClass_Back,EGroup,Supplier,PostID,EmpStatus,Tin, " +
                                  "isnull(DateHired,'1901-01-01')DateHired,Compensation, " +
                                  "PostName,Remarks,isnull(AdjustmentCtrl,'')AdjustmentCtrl, " +
                                  "KanusaLast " +
                           "FROM Time_Summary_Locked " +
                           "where 1=1 " + pkWhereClause + empNoWhereClause + dateFromWhereClause + dateToWhereClause;

            return query;
        }

        private static List<TimeSummary> GetDatas(Connection connection,string query) 
        {
            List<TimeSummary> result = new List<TimeSummary>();
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result.Add(new TimeSummary(Convert.ToInt32(d.Rows[i]["pk"]), Convert.ToInt32(d.Rows[i]["EmpNo"]),
                    Convert.ToDateTime(d.Rows[i]["DateFrom"]), Convert.ToDateTime(d.Rows[i]["DateTo"]),
                    Convert.ToInt32(d.Rows[i]["EmpPam"]), Convert.ToDouble(d.Rows[i]["NoHours"]),
                    Convert.ToDouble(d.Rows[i]["SL"]), Convert.ToDouble(d.Rows[i]["SH"]),
                    Convert.ToDouble(d.Rows[i]["LH"]), Convert.ToDouble(d.Rows[i]["SH_OT"]),
                    Convert.ToDouble(d.Rows[i]["LH_OT"]), Convert.ToDouble(d.Rows[i]["RD"]),
                    Convert.ToDouble(d.Rows[i]["REG_OT"]), Convert.ToDouble(d.Rows[i]["MidNight"]),
                    Convert.ToDouble(d.Rows[i]["Clearing"]), Convert.ToBoolean(d.Rows[i]["Locked"]),
                    Convert.ToBoolean(d.Rows[i]["Uploaded"]), Convert.ToBoolean(d.Rows[i]["Unlocked"]),
                    d.Rows[i]["LastModified"].ToString(), Convert.ToInt32(d.Rows[i]["Hired"]),
                    d.Rows[i]["AgencyName"].ToString(), Convert.ToInt32(d.Rows[i]["DeptID"]),
                    d.Rows[i]["DeptName"].ToString(), Convert.ToInt32(d.Rows[i]["SectSort"]),
                    Convert.ToInt32(d.Rows[i]["SectID"]), d.Rows[i]["SectName"].ToString(),
                    Convert.ToInt32(d.Rows[i]["PClass_Back"]), Convert.ToInt32(d.Rows[i]["EGroup"]),
                    d.Rows[i]["Supplier"].ToString(), Convert.ToInt32(d.Rows[i]["postId"]),
                    Convert.ToInt32(d.Rows[i]["EmpStatus"]), d.Rows[i]["Tin"].ToString(),
                    Convert.ToDateTime(d.Rows[i]["DateHired"]), Convert.ToInt32(d.Rows[i]["Compensation"]),
                    d.Rows[i]["PostName"].ToString(), d.Rows[i]["Remarks"].ToString(),
                    d.Rows[i]["AdjustmentCtrl"].ToString(), Convert.ToDateTime(d.Rows[i]["KanusaLast"])));
            }
            return result;
        }

        private static TimeSummary GetData(Connection connection,string query)
        {
            TimeSummary result = null;
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result = new TimeSummary(Convert.ToInt32(d.Rows[i]["pk"]), Convert.ToInt32(d.Rows[i]["EmpNo"]),
                    Convert.ToDateTime(d.Rows[i]["DateFrom"]), Convert.ToDateTime(d.Rows[i]["DateTo"]),
                    Convert.ToInt32(d.Rows[i]["EmpPam"]), Convert.ToDouble(d.Rows[i]["NoHours"]),
                    Convert.ToDouble(d.Rows[i]["SL"]), Convert.ToDouble(d.Rows[i]["SH"]),
                    Convert.ToDouble(d.Rows[i]["LH"]), Convert.ToDouble(d.Rows[i]["SH_OT"]),
                    Convert.ToDouble(d.Rows[i]["LH_OT"]), Convert.ToDouble(d.Rows[i]["RD"]),
                    Convert.ToDouble(d.Rows[i]["REG_OT"]), Convert.ToDouble(d.Rows[i]["MidNight"]),
                    Convert.ToDouble(d.Rows[i]["Clearing"]), Convert.ToBoolean(d.Rows[i]["Locked"]),
                    Convert.ToBoolean(d.Rows[i]["Uploaded"]), Convert.ToBoolean(d.Rows[i]["Unlocked"]),
                    d.Rows[i]["LastModified"].ToString(), Convert.ToInt32(d.Rows[i]["Hired"]),
                    d.Rows[i]["AgencyName"].ToString(), Convert.ToInt32(d.Rows[i]["DeptID"]),
                    d.Rows[i]["DeptName"].ToString(), Convert.ToInt32(d.Rows[i]["SectSort"]),
                    Convert.ToInt32(d.Rows[i]["SectID"]), d.Rows[i]["SectName"].ToString(),
                    Convert.ToInt32(d.Rows[i]["PClass_Back"]), Convert.ToInt32(d.Rows[i]["EGroup"]),
                    d.Rows[i]["Supplier"].ToString(), Convert.ToInt32(d.Rows[i]["postId"]),
                    Convert.ToInt32(d.Rows[i]["EmpStatus"]), d.Rows[i]["Tin"].ToString(),
                    Convert.ToDateTime(d.Rows[i]["DateHired"]), Convert.ToInt32(d.Rows[i]["Compensation"]),
                    d.Rows[i]["PostName"].ToString(), d.Rows[i]["Remarks"].ToString(),
                    d.Rows[i]["AdjustmentCtrl"].ToString(), Convert.ToDateTime(d.Rows[i]["KanusaLast"]));
            }
            return result;
        }

        public static List<TimeSummary> GetAllTimeSummary(Connection connection) 
        {
            return GetDatas(connection,QueryFilter(new FilterClause<int>(),new FilterClause<int>(),
                new FilterClause<DateTime>(),new FilterClause<DateTime>()));
        }

        public static List<TimeSummary> GetAllTimeSummary(Connection connection,int empNo)
        {
            return GetDatas(connection, QueryFilter(new FilterClause<int>(), new FilterClause<int>(empNo),
                new FilterClause<DateTime>(), new FilterClause<DateTime>()));
        }

        public static List<TimeSummary> GetAllTimeSummary(Connection connection, int empNo,DateTime dateFrom,DateTime dateTo)
        {
            return GetDatas(connection, QueryFilter(new FilterClause<int>(), new FilterClause<int>(empNo),
                new FilterClause<DateTime>(dateFrom), new FilterClause<DateTime>(dateTo)));
        }

        public static TimeSummary GetTimeSummary(Connection connection, int empNo, DateTime dateFrom, DateTime dateTo)
        {
            return GetData(connection, QueryFilter(new FilterClause<int>(), new FilterClause<int>(empNo),
                new FilterClause<DateTime>(dateFrom), new FilterClause<DateTime>(dateTo)));
        }


        public static List<TimeSummary> GetAllLockedTimeSummary(Connection connection)
        {
            return GetDatas(connection, QueryFilterLocked(new FilterClause<int>(), new FilterClause<int>(),
                new FilterClause<DateTime>(), new FilterClause<DateTime>()));
        }

        public static List<TimeSummary> GetAllLockedTimeSummary(Connection connection, int empNo)
        {
            return GetDatas(connection, QueryFilterLocked(new FilterClause<int>(), new FilterClause<int>(empNo),
                new FilterClause<DateTime>(), new FilterClause<DateTime>()));
        }

        public static List<TimeSummary> QueryFilterLocked(Connection connection, int empNo, DateTime dateFrom, DateTime dateTo)
        {
            return GetDatas(connection, QueryFilterLocked(new FilterClause<int>(), new FilterClause<int>(empNo),
                new FilterClause<DateTime>(dateFrom), new FilterClause<DateTime>(dateTo)));
        }

        public static TimeSummary GetLockedTimeSummary(Connection connection, int empNo, DateTime dateFrom, DateTime dateTo)
        {
            return GetData(connection, QueryFilterLocked(new FilterClause<int>(), new FilterClause<int>(empNo),
                new FilterClause<DateTime>(dateFrom), new FilterClause<DateTime>(dateTo)));
        }

        public static bool DeleteTimeSummary(Connection connection,int empNo,DateTime dateFrom,DateTime dateTo)
        {
            string query = "delete Time_Summary " +
                           "where EmpNo =" + empNo + " and DateFrom = '" + 
                           dateFrom.ToShortDateString() + "' and DateTo = '" + dateTo.ToShortDateString() + "' ";

            return connection.Execute(query);
        }

        public static bool UpdateTimeSummary(Connection connection,TimeSummary timeSummary) 
        {
            string query = "update Time_Summary " +
                           "set EmpNo = " + timeSummary.EmpNo + ", " +
	                           "DateFrom='" + timeSummary.DateFrom.ToShortDateString() + "', " +
	                           "DateTo='" + timeSummary.DateTo.ToShortDateString() + "', " +
	                           "EmpPam=" + timeSummary.EmpPam + ", " +
	                           "NoHours=" + timeSummary.TotalHours + ", " +
	                           "SL=" + timeSummary.SL + ",SH=" + timeSummary.SH + ",LH=" + timeSummary.LH + ", " +
	                           "SH_OT=" + timeSummary.SH_OT + ",LH_OT=" + timeSummary.LH_OT + ", " +
	                           "RD=" + timeSummary.RD + ",REG_OT=" + timeSummary.REG_OT + ", " +
	                           "MidNight=" + timeSummary.MidNight + ",Clearing=" + timeSummary.Clearing + ", " +
	                           "Locked=" + Convert.ToInt32(timeSummary.IsLocked) + ",Uploaded=" + Convert.ToInt32(timeSummary.IsUploaded) + ", " +
	                           "Unlocked=" + Convert.ToInt32(timeSummary.IsUnLocked) + ", " +
	                           "LastModified='" +  Connection.SqlString(timeSummary.LastModified) + "', " +
	                           "Hired=" + timeSummary.Hired + ",AgencyName='" + Connection.SqlString(timeSummary.AgencyName) + "', " +
	                           "DeptID=" + timeSummary.DepId + ",DeptName='" + Connection.SqlString(timeSummary.DepartmentName) + "', " +
	                           "SectSort=" + timeSummary.SectSort + ",SectID=" + timeSummary.SectionId + ", " +
	                           "SectName='" + Connection.SqlString(timeSummary.SectionName) + "',PClass_Back=" + timeSummary.PClass_Back + ", " +
	                           "EGroup=" + timeSummary.EGroup + ",Supplier='" + Connection.SqlString(timeSummary.Supplier) + "', " +
	                           "PostID=" + timeSummary.PostId + ",EmpStatus=" + timeSummary.EmpStatus + ", " +
	                           "Tin='" + Connection.SqlString(timeSummary.TIN) + "',DateHired='" + timeSummary.DateHired.ToShortDateString() + "', " +
	                           "Compensation=" + timeSummary.Compensation + ",PostName='" + Connection.SqlString(timeSummary.PostName) + "', " +
	                           "Remarks='" + Connection.SqlString(timeSummary.Remarks) + "',AdjustmentCtrl='" + Connection.SqlString(timeSummary.AdjustmentCntrlNo) + "', " +
	                           "KanusaLast='" + timeSummary.KanusaLast.ToShortDateString() + "' " +
                           "where PK =" + timeSummary.Pk + " ";

            return connection.Execute(query);
        }

        public static bool InsertTimeSummary(Connection connection,TimeSummary timeSummary) 
        {
            string query = "insert Time_Summary values (" + timeSummary.EmpNo + ",'" + timeSummary.DateFrom.ToShortDateString() + 
                           "','" + timeSummary.DateTo.ToShortDateString() + "'," + timeSummary.EmpPam + ", " +
	                       "" + timeSummary.TotalHours + "," + timeSummary.SL +"," + timeSummary.SH + 
                           "," + timeSummary.LH + "," + timeSummary.SH_OT + "," + timeSummary.LH_OT + 
                           "," + timeSummary.RD + "," + timeSummary.REG_OT + "," + timeSummary.MidNight + ", " +
	                       "" + timeSummary.Clearing + "," + Convert.ToInt32(timeSummary.IsLocked) + 
                           "," + Convert.ToInt32(timeSummary.IsUploaded) + "," + Convert.ToInt32(timeSummary.IsUnLocked) + 
                           ",'" + Connection.SqlString(timeSummary.LastModified) + "'," + timeSummary.Hired + 
                           ",'" + Connection.SqlString(timeSummary.AgencyName) + "'," + timeSummary.DepId + 
                           ",'" + Connection.SqlString(timeSummary.DepartmentName) + "'," + timeSummary.SectSort + ", " +
	                       "" + timeSummary.SectionId + ",'" + Connection.SqlString(timeSummary.SectionName) + 
                           "'," + timeSummary.PClass_Back + "," + timeSummary.EGroup + ",'" + Connection.SqlString(timeSummary.Supplier) + "', " +
	                       "" + timeSummary.PostId + "," + timeSummary.EmpStatus + ",'" + Connection.SqlString(timeSummary.TIN) + 
                           "','" + timeSummary.DateHired.ToShortDateString() + "'," + timeSummary.Compensation + ", " +
	                       "'" + Connection.SqlString(timeSummary.PostName) + "','" + Connection.SqlString(timeSummary.Remarks) + 
                           "','" + Connection.SqlString(timeSummary.AdjustmentCntrlNo) + "','" + timeSummary.KanusaLast.ToShortDateString() + "') ";

            return connection.Execute(query);
        }

        public static TimeSummary CreateEmptyTimeSummary() 
        {
            return new TimeSummary(0, 0, new DateTime(1901, 1, 1), new DateTime(1901, 1, 1), 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, false, false, false, string.Empty, 0, string.Empty, 0, string.Empty,
                0, 0, string.Empty, 0,0, string.Empty, 0, 0, string.Empty, new DateTime(1901, 1, 1),
                0, string.Empty, string.Empty, string.Empty, new DateTime(1901,1,1));
        }
    }
}

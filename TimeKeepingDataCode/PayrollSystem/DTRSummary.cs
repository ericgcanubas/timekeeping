using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeKeepingDataCode.PayrollSystem
{
    public class DTRSummary
    {
        public int PK { get; set; }
        public int CntrlNo { get; set; }
        public int Series { get; set; }
        public int EmpNo { get; set; }
        public string EmpName { get; set; }
        public int Period { get; set; }
        public int Dept { get; set; }
        public int Sect { get; set; }
        public string Supplier { get; set; }
        public int Position { get; set; }
        public int EmpStatus { get; set; }
        public double NoHours { get; set; }
        public double NoColaHours { get; set; }
        public double AgencyHours { get; set; }
        public double GuardRegHours { get; set; }
        public double SickLeave { get; set; }
        public double SH { get; set; }
        public double LH { get; set; }
        public double SH_OT { get; set; }
        public double LH_OT { get; set; }
        public double RD { get; set; }
        public double Reg_OT { get; set; }
        public double MidNight { get; set; }
        public double Clearing { get; set; }
        public double Adjustment { get; set; }
        public string LastModifiedDTR { get; set; }
        public int CurrentPAM { get; set; }
        public int Locked { get; set; }
        public int UnLocked { get; set; }
        public int Uploaded { get; set; }
        public int Bio { get; set; }

        public DTRSummary(int pk,int cntrlNo,int series,int empNo,
            string empName,int period,int dept,int sect,string supplier,
            int position,int empStatus,double noHours,double noColaHours,
            double agencyHours,double guardrRegHours,double sickLeave,
            double sh,double lh,double sh_ot,double lh_ot,double rd,double reg_out,
            double midNight,double clearing,double adjustment,string lastModifiedDTR,
            int currentPAM,int locked,int unLocked,int uploaded,int bio)
        {
            this.PK = pk;
            this.CntrlNo = cntrlNo;
            this.Series = series;
            this.EmpNo = empNo;
            this.EmpName = empName;
            this.Period = period;
            this.Dept = dept;
            this.Sect = sect;
            this.Supplier = supplier;
            this.Position = position;
            this.EmpStatus = empStatus;
            this.NoHours = noHours;
            this.NoColaHours = noColaHours;
            this.AgencyHours = agencyHours;
            this.GuardRegHours = guardrRegHours;
            this.SickLeave = sickLeave;
            this.SH = sh;
            this.LH = lh;
            this.SH_OT = sh_ot;
            this.LH_OT = lh_ot;
            this.RD = rd;
            this.Reg_OT = reg_out;
            this.MidNight = midNight;
            this.Clearing = clearing;
            this.Adjustment = adjustment;
            this.LastModifiedDTR = lastModifiedDTR;
            this.CurrentPAM = currentPAM;
            this.Locked = locked;
            this.UnLocked = unLocked;
            this.Uploaded = uploaded;
            this.Bio = bio;
        }

        private static string QueryFilter() 
        {
            string query = "select PK,CtrlNo,Series,EmpNo,isnull(Emp_Name,'')Emp_Name,Period, " +
                                  "Dept,Sect,isnull(Supplier,'')Supplier,Position_P,EmpStatus, " +
                                  "NoofHours,NoofHoursCola,AgencyHours,GuardRegHours,SickLeave, " +
                                  "SH,LH,SH_OT,LH_OT,RD,Reg_OT,MidNight,Clearing,Adjustment, " +
                                  "isnull(LastModifiedDTR,'')LastModifiedDTR,CurrentPAM, " +
                                  "Locked,Unlocked,Uploaded,Bio " +
                           "FROM DTRSummary " +
                           "where 1=1 ";

            return query;
        }

        private static List<DTRSummary> GetDatas(Connection connection,string query) 
        {
            List<DTRSummary> result = new List<DTRSummary>();
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result.Add(new DTRSummary(Convert.ToInt32(d.Rows[i]["PK"]), Convert.ToInt32(d.Rows[i]["CtrlNo"]),
                    Convert.ToInt32(d.Rows[i]["Series"]), Convert.ToInt32(d.Rows[i]["EmpNo"]), d.Rows[i]["Emp_Name"].ToString(),
                    Convert.ToInt32(d.Rows[i]["Period"]), Convert.ToInt32(d.Rows[i]["Dept"]), Convert.ToInt32(d.Rows[i]["Sect"]),
                    d.Rows[i]["Supplier"].ToString(), Convert.ToInt32(d.Rows[i]["Position_P"]), Convert.ToInt32(d.Rows[i]["EmpStatus"]),
                    Convert.ToDouble(d.Rows[i]["NoofHours"]), Convert.ToDouble(d.Rows[i]["NoofHoursCola"]), Convert.ToDouble(d.Rows[i]["AgencyHours"]),
                    Convert.ToDouble(d.Rows[i]["GuardRegHours"]), Convert.ToDouble(d.Rows[i]["SickLeave"]),
                    Convert.ToDouble(d.Rows[i]["SH"]), Convert.ToDouble(d.Rows[i]["LH"]), Convert.ToDouble(d.Rows[i]["SH_OT"]),
                    Convert.ToDouble(d.Rows[i]["LH_OT"]), Convert.ToDouble(d.Rows[i]["RD"]), Convert.ToDouble(d.Rows[i]["Reg_OT"]),
                    Convert.ToDouble(d.Rows[i]["MidNight"]), Convert.ToDouble(d.Rows[i]["Clearing"]),
                    Convert.ToDouble(d.Rows[i]["Adjustment"]), d.Rows[i]["LastModifiedDTR"].ToString(),
                    Convert.ToInt32(d.Rows[i]["CurrentPAM"]), Convert.ToInt32(d.Rows[i]["Locked"]),
                    Convert.ToInt32(d.Rows[i]["Unlocked"]), Convert.ToInt32(d.Rows[i]["Uploaded"]),
                    Convert.ToInt32(d.Rows[i]["Bio"])));
            }
            return result;
        }

        private static DTRSummary GetData(Connection connection, string query)
        {
            DTRSummary result = null;
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result = new DTRSummary(Convert.ToInt32(d.Rows[i]["PK"]), Convert.ToInt32(d.Rows[i]["CtrlNo"]),
                    Convert.ToInt32(d.Rows[i]["Series"]), Convert.ToInt32(d.Rows[i]["EmpNo"]), d.Rows[i]["Emp_Name"].ToString(),
                    Convert.ToInt32(d.Rows[i]["Period"]), Convert.ToInt32(d.Rows[i]["Dept"]), Convert.ToInt32(d.Rows[i]["Sect"]),
                    d.Rows[i]["Supplier"].ToString(), Convert.ToInt32(d.Rows[i]["Position_P"]), Convert.ToInt32(d.Rows[i]["EmpStatus"]),
                    Convert.ToDouble(d.Rows[i]["NoofHours"]), Convert.ToDouble(d.Rows[i]["NoofHoursCola"]), Convert.ToDouble(d.Rows[i]["AgencyHours"]),
                    Convert.ToDouble(d.Rows[i]["GuardRegHours"]), Convert.ToDouble(d.Rows[i]["SickLeave"]),
                    Convert.ToDouble(d.Rows[i]["SH"]), Convert.ToDouble(d.Rows[i]["LH"]), Convert.ToDouble(d.Rows[i]["SH_OT"]),
                    Convert.ToDouble(d.Rows[i]["LH_OT"]), Convert.ToDouble(d.Rows[i]["RD"]), Convert.ToDouble(d.Rows[i]["Reg_OT"]),
                    Convert.ToDouble(d.Rows[i]["MidNight"]), Convert.ToDouble(d.Rows[i]["Clearing"]),
                    Convert.ToDouble(d.Rows[i]["Adjustment"]), d.Rows[i]["LastModifiedDTR"].ToString(),
                    Convert.ToInt32(d.Rows[i]["CurrentPAM"]), Convert.ToInt32(d.Rows[i]["Locked"]),
                    Convert.ToInt32(d.Rows[i]["Unlocked"]), Convert.ToInt32(d.Rows[i]["Uploaded"]),
                    Convert.ToInt32(d.Rows[i]["Bio"]));
            }
            return result;
        }

        public static bool DeleteDTRSummary(Connection connection,int empNo,int periodNo,int bio) 
        {
            return connection.Execute("DELETE DTRSummary WHERE (EmpNo = " + empNo + ") AND (Period = " + periodNo + ") AND (Bio = " + bio + ") ");
        }

        public static bool InsertDTRSummary(Connection connection,DTRSummary dtrSummary) 
        {
            string query = "insert DTRSummary values (" + dtrSummary.CntrlNo + "," + dtrSummary.Series + 
                           "," + dtrSummary.EmpNo + ",'" + Connection.SqlString(dtrSummary.EmpName) + "', " +
	                       "" + dtrSummary.Period + "," + dtrSummary.Dept + "," + dtrSummary.Sect + ",'" + 
                           Connection.SqlString(dtrSummary.Supplier) + "'," + dtrSummary.Position + "," + dtrSummary.EmpStatus + ", " +
	                       "" + dtrSummary.NoHours + "," + dtrSummary.NoColaHours + "," + dtrSummary.AgencyHours + "," + dtrSummary.GuardRegHours + ", " +
	                       "" + dtrSummary.SickLeave + "," + dtrSummary.SH + "," + dtrSummary.LH + "," + 
                           dtrSummary.SH_OT + "," + dtrSummary.LH_OT + "," + dtrSummary.RD + "," + dtrSummary.Reg_OT + "," + dtrSummary.MidNight + ", " +
	                       "" + dtrSummary.Clearing + "," +dtrSummary.Adjustment  + ",'" + Connection.SqlString(dtrSummary.LastModifiedDTR) + "'," + dtrSummary.CurrentPAM + ", " +
	                       "" +  dtrSummary.Locked + "," + dtrSummary.UnLocked + "," + dtrSummary.Uploaded + "," + dtrSummary.Bio + ") ";

            return connection.Execute(query);
        }

        public static DTRSummary CreateEmptyDTRSummary() 
        {
            return new DTRSummary(0,0,0,0,string.Empty,0,0,0,string.Empty,0,0,
                0,0,0,0,0,0,0,0,0,0,0,0,0,0,string.Empty,0,0,0,0,0);
        }
    }
}

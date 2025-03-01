using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeKeepingDataCode.Biometrics
{
    public class TimeRecord
    {
        public int Id { get; set; }
        public int EmpId { get; set; }
        public DateTime ActualDate { get; set; }
        public double TotalHours { get; set; }
        public double TotalLate { get; set; }
        public double TotalUndertime { get; set; }
        public double OfficialUndertime { get; set; }
        public double AdjustedTime { get; set; }
        public string AdjustmentCntrlNo { get; set; }
        public string Remarks { get; set; }
        public DateTime MidNightFrom { get; set; }
        public DateTime MidNightTo { get; set; }
        public double MidNightTotal { get; set; }
        public DateTime ExtendedFrom { get; set; }
        public DateTime ExtendedTo { get; set; }
        public double TotalExtended { get; set; }
        public int Locked { get; set; }
        public double NetHours { get; set; }

        public TimeRecord(int id,int empId,DateTime actualDate,double totalHours,double totalLate,
            double totalUndertime,double officialUndertime,double adjustedTime,string adjustedCntrlNo,
            string remarks,DateTime midNightFrom,DateTime midNightTo,double totalMidNight,
            DateTime extendedFrom,DateTime extendedTo,double totalExtended,int locked,double netHours)
        {
            this.Id = id;
            this.EmpId = empId;
            this.ActualDate = actualDate;
            this.TotalHours = totalHours;
            this.TotalLate = totalLate;
            this.TotalUndertime = totalUndertime;
            this.OfficialUndertime = officialUndertime;
            this.AdjustedTime = adjustedTime;
            this.AdjustmentCntrlNo = adjustedCntrlNo;
            this.Remarks = remarks;
            this.MidNightFrom = midNightFrom;
            this.MidNightTo = midNightTo;
            this.MidNightTotal = totalMidNight;
            this.ExtendedFrom = extendedFrom;
            this.ExtendedTo = extendedTo;
            this.TotalExtended = totalExtended;
            this.Locked = locked;
            this.NetHours = netHours;
        }

        private static string QueryFilter(FilterClause<int> id,FilterClause<int> empId,
            FilterClause<DateTime> dateFrom,FilterClause<DateTime> dateTo,FilterClause<DateTime> dateEffect) 
        {
            string idWhereClause = string.Empty;
            string empIdWhereClause = string.Empty;
            string fromToWhereClause = string.Empty;
            string dateEffectWhereClause = string.Empty;

            if (id.IsFilter)
                idWhereClause = " and PK = " + id.Value + " ";
            if (empId.IsFilter)
                empIdWhereClause = " and EmployeeKey = " + empId.Value + " ";
            if (dateFrom.IsFilter && dateTo.IsFilter)
                fromToWhereClause = " and Actual_Date between '" + dateFrom.Value.ToShortDateString() + "' and '" + dateTo.Value.ToShortDateString() + "' ";
            if (dateEffect.IsFilter)
                dateEffectWhereClause = " and Actual_Date = '" + dateEffect.Value.ToShortDateString() + "' ";

            string query = "SELECT PK,EmployeeKey,Actual_Date,TotalHours,TotalLate, " +
                                  "TotalUndertime,OfficialUndertime,AdjustedTime, " +
                                  "AdjustmentCtrl,Remarks,isnull(MidNightFrom,'1901-01-01')MidNightFrom, " +
                                  "isnull(MidNightTo,'1901-01-01')MidNightTo, " +
                                  "MidNightTotal,isnull(ExtendedFrom,'1901-01-01')ExtendedFrom, " +
                                  "isnull(ExtendedTo,'1901-01-01')ExtendedTo,ExtendedTotal, " +
                                  "Locked,isnull(NetHours,0)NetHours " +
                           "FROM tbl_TimeRecord " +
                           "where 1=1 " + idWhereClause + empIdWhereClause + fromToWhereClause + dateEffectWhereClause;
            return query;
        }

        private static string QueryFilterLocked(FilterClause<int> id, FilterClause<int> empId,
            FilterClause<DateTime> dateFrom, FilterClause<DateTime> dateTo, FilterClause<DateTime> dateEffect)
        {
            string idWhereClause = string.Empty;
            string empIdWhereClause = string.Empty;
            string fromToWhereClause = string.Empty;
            string dateEffectWhereClause = string.Empty;

            if (id.IsFilter)
                idWhereClause = " and PK = " + id.Value + " ";
            if (empId.IsFilter)
                empIdWhereClause = " and EmployeeKey = " + empId.Value + " ";
            if (dateFrom.IsFilter && dateTo.IsFilter)
                fromToWhereClause = " and Actual_Date between '" + dateFrom.Value.ToShortDateString() + "' and '" + dateTo.Value.ToShortDateString() + "' ";
            if (dateEffect.IsFilter)
                dateEffectWhereClause = " and Actual_Date = '" + dateEffect.Value.ToShortDateString() + "' ";

            string query = "SELECT PK,EmployeeKey,Actual_Date,TotalHours,TotalLate, " +
                                 "TotalUndertime,OfficialUndertime,AdjustedTime, " +
                                 "AdjustmentCtrl,Remarks,isnull(MidNightFrom,'1901-01-01')MidNightFrom, " +
                                 "isnull(MidNightTo,'1901-01-01')MidNightTo, " +
                                 "MidNightTotal,isnull(ExtendedFrom,'1901-01-01')ExtendedFrom, " +
                                 "isnull(ExtendedTo,'1901-01-01')ExtendedTo,ExtendedTotal, " +
                                 "1 Locked,isnull(NetHours,0)NetHours " +
                           "FROM tbl_TimeRecord_Locked " +
                           "where 1=1 " + idWhereClause + empIdWhereClause + fromToWhereClause + dateEffectWhereClause;
            return query;
        }

        private static List<TimeRecord> GetDatas(Connection connection,string query) 
        {
            List<TimeRecord> result = new List<TimeRecord>();
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result.Add(new TimeRecord(Convert.ToInt32(d.Rows[i]["PK"]), Convert.ToInt32(d.Rows[i]["EmployeeKey"]),
                    Convert.ToDateTime(d.Rows[i]["Actual_Date"]), Convert.ToDouble(d.Rows[i]["TotalHours"]),
                    Convert.ToDouble(d.Rows[i]["TotalLate"]), Convert.ToDouble(d.Rows[i]["TotalUndertime"]),
                    Convert.ToDouble(d.Rows[i]["OfficialUndertime"]), Convert.ToDouble(d.Rows[i]["AdjustedTime"]),
                    d.Rows[i]["AdjustmentCtrl"].ToString(), d.Rows[i]["Remarks"].ToString(),
                    Convert.ToDateTime(d.Rows[i]["MidNightFrom"]), Convert.ToDateTime(d.Rows[i]["MidNightTo"]),
                    Convert.ToDouble(d.Rows[i]["MidNightTotal"]), Convert.ToDateTime(d.Rows[i]["ExtendedFrom"]),
                    Convert.ToDateTime(d.Rows[i]["ExtendedTo"]), Convert.ToDouble(d.Rows[i]["ExtendedTotal"]),
                    Convert.ToInt32(d.Rows[i]["Locked"]), Convert.ToDouble(d.Rows[i]["NetHours"])));
            }
            return result;
        }

        private static TimeRecord GetData(Connection connection,string query) 
        {
            TimeRecord result = null;
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result = new TimeRecord(Convert.ToInt32(d.Rows[i]["PK"]), Convert.ToInt32(d.Rows[i]["EmployeeKey"]),
                    Convert.ToDateTime(d.Rows[i]["Actual_Date"]), Convert.ToDouble(d.Rows[i]["TotalHours"]),
                    Convert.ToDouble(d.Rows[i]["TotalLate"]), Convert.ToDouble(d.Rows[i]["TotalUndertime"]),
                    Convert.ToDouble(d.Rows[i]["OfficialUndertime"]), Convert.ToDouble(d.Rows[i]["AdjustedTime"]),
                    d.Rows[i]["AdjustmentCtrl"].ToString(), d.Rows[i]["Remarks"].ToString(),
                    Convert.ToDateTime(d.Rows[i]["MidNightFrom"]), Convert.ToDateTime(d.Rows[i]["MidNightTo"]),
                    Convert.ToDouble(d.Rows[i]["MidNightTotal"]), Convert.ToDateTime(d.Rows[i]["ExtendedFrom"]),
                    Convert.ToDateTime(d.Rows[i]["ExtendedTo"]), Convert.ToDouble(d.Rows[i]["ExtendedTotal"]),
                    Convert.ToInt32(d.Rows[i]["Locked"]), Convert.ToDouble(d.Rows[i]["NetHours"]));
            }
            return result;
        }

        public static List<TimeRecord> GetAllTimeRecord(Connection connection) 
        {
            return GetDatas(connection,QueryFilter(new FilterClause<int>(),new FilterClause<int>(),
                new FilterClause<DateTime>(),new FilterClause<DateTime>(),new FilterClause<DateTime>()));
        }

        public static List<TimeRecord> GetAllLockTimeRecord(Connection connection)
        {
            return GetDatas(connection, QueryFilterLocked(new FilterClause<int>(), new FilterClause<int>(),
                new FilterClause<DateTime>(), new FilterClause<DateTime>(), new FilterClause<DateTime>()));
        }

        public static List<TimeRecord> GetAllTimeRecord(Connection connection,int empId)
        {
            return GetDatas(connection, QueryFilter(new FilterClause<int>(),new FilterClause<int>(empId),
                new FilterClause<DateTime>(),new FilterClause<DateTime>(),new FilterClause<DateTime>()));
        }

        public static List<TimeRecord> GetAllLockedTimeRecord(Connection connection, int empId)
        {
            return GetDatas(connection, QueryFilterLocked(new FilterClause<int>(), new FilterClause<int>(empId),
                new FilterClause<DateTime>(), new FilterClause<DateTime>(), new FilterClause<DateTime>()));
        }

        public static List<TimeRecord> GetAllTimeRecord(Connection connection,int empId,DateTime from,DateTime to)
        {
            return GetDatas(connection, QueryFilter(new FilterClause<int>(),new FilterClause<int>(empId),
                new FilterClause<DateTime>(from),new FilterClause<DateTime>(to),new FilterClause<DateTime>()));
        }

        public static List<TimeRecord> GetAllLockedTimeRecord(Connection connection, int empId, DateTime from, DateTime to)
        {
            return GetDatas(connection, QueryFilterLocked(new FilterClause<int>(), new FilterClause<int>(empId),
                new FilterClause<DateTime>(from), new FilterClause<DateTime>(to), new FilterClause<DateTime>()));
        }

        public static TimeRecord GetTimeRecord(Connection connection, int id)
        {
            return GetData(connection, QueryFilter(new FilterClause<int>(id),new FilterClause<int>(),
                new FilterClause<DateTime>(),new FilterClause<DateTime>(),new FilterClause<DateTime>()));
        }

        public static TimeRecord GetLockedTimeRecord(Connection connection, int id)
        {
            return GetData(connection, QueryFilterLocked(new FilterClause<int>(id), new FilterClause<int>(),
                new FilterClause<DateTime>(), new FilterClause<DateTime>(), new FilterClause<DateTime>()));
        }

        public static TimeRecord GetTimeRecord(Connection connection,int empId,DateTime dateEffect) 
        {
            return GetData(connection,QueryFilter(new FilterClause<int>(),new FilterClause<int>(empId),
                new FilterClause<DateTime>(),new FilterClause<DateTime>(),new FilterClause<DateTime>(dateEffect)));
        }

        public static TimeRecord GetLockedTimeRecord(Connection connection, int empId, DateTime dateEffect)
        {
            return GetData(connection, QueryFilterLocked(new FilterClause<int>(), new FilterClause<int>(empId),
                new FilterClause<DateTime>(), new FilterClause<DateTime>(), new FilterClause<DateTime>(dateEffect)));
        }

        public static List<TimeRecord> GetAllLockedTimeRecord(Connection connection, DateTime dateFrom, DateTime dateTo) 
        {
            return GetDatas(connection,QueryFilterLocked(new FilterClause<int>(),
                new FilterClause<int>(),new FilterClause<DateTime>(dateFrom),
                new FilterClause<DateTime>(dateTo),new FilterClause<DateTime>()));
        }

        public static bool RepostTimeRecordByRange(Connection connection,DateTime dateFrom,DateTime dateTo) 
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("delete tbl_TimeRecord_Detail " +
                      "where Actual_Date between '" + dateFrom.ToShortDateString() + "' and '" + dateTo.ToShortDateString() + "' ");

            sb.Append("delete tbl_TimeRecord " +
                      "where Actual_Date between '" + dateFrom.ToShortDateString() + "' and '" + dateTo.ToShortDateString() + "' ");

            sb.Append("update tbl_TransactionLog " +
                      "set Posted = 0 " +
                      "where Actual_Date between '" + dateFrom.ToShortDateString() + "' and '" + dateTo.ToShortDateString() + "' ");

            return connection.Execute(sb.ToString());
        }

        public static bool IsPresentBefore(Connection connection, DateTime date, int empPk)
        {
            bool checking = true;
            bool result = false;

            while (checking)
            {
                date = date.AddDays(-1);

                string query = "select NetHours from tbl_TimeRecord " +
                               "where EmployeeKey =" + empPk + " and Actual_Date = '" + date.ToShortDateString() + "' ";

                var d = connection.GetData(query);
                if (d.Rows.Count > 0)
                {
                    result = true;
                    checking = false;
                }
                else {
                    //IF NOT RESTDAY ELSE CONTINUE LOOP
                    if (!EmployeeShifting.IsRestday(connection, date, empPk)) 
                    {
                        //IF LEAVE
                        if (LeaveUndertime.IsLeave(connection, date, empPk))
                        {
                            result = false;
                            checking = false;
                        }
                        else { 
                            string holidayType = string.Empty;
                            //CHECK KUNG HOLIDAY ANG DAY
                            if (HolidayName.IsDateHoliday(connection, date, out holidayType))
                            {
                                //ABSENT ANG KAGWANG
                                if (!HolidayEmployees.IsEmployeeHoliday(connection, date, empPk, out holidayType))
                                {
                                    result = false;
                                    checking = false;
                                }
                            }
                            //ABSENT ANG KAGWANG
                            else {
                                result = false;
                                checking = false;
                            }
                        }
                    }
                }
            }

            return result;
        }
    }
}

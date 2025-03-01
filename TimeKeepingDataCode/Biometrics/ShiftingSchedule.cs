using System;
using System.Collections.Generic;

namespace TimeKeepingDataCode.Biometrics
{
    public class ShiftingSchedule
    {
        public int Id { get; set; }
        public int ScheduleType { get; set; }
        public string ShiftingName { get; set; }
        public int ShiftingType { get; set; }
        public TimeSpan AMIn { get; set; }
        public TimeSpan LunchOut { get; set; }
        public TimeSpan LunchIn { get; set; }
        public TimeSpan CoffeeOut { get; set; }
        public TimeSpan CoffeeIn { get; set; }
        public TimeSpan PmOut { get; set; }
        public int Lunchtime { get; set; }
        public int Breaktime { get; set; }
        public bool IsFixed { get; set; }
        public bool IsActive { get; set; }
        public string LastModified { get; set; }

        public ShiftingSchedule(int id,int scheduleType,string shiftingName,int shiftingType,
            TimeSpan amIn,TimeSpan lunchOut,TimeSpan lunchIn,TimeSpan coffeeOut,TimeSpan coffeeIn,
            TimeSpan pmOut,int lunchtime,int breaktime,bool isFixed,bool isActive,string lastModified)
        {
            this.Id = id;
            this.ScheduleType = scheduleType;
            this.ShiftingName = shiftingName;
            this.ShiftingType = shiftingType;
            this.AMIn = amIn;
            this.LunchOut = lunchOut;
            this.LunchIn = lunchIn;
            this.CoffeeOut = coffeeOut;
            this.CoffeeIn = coffeeIn;
            this.PmOut = pmOut;
            this.Lunchtime = lunchtime;
            this.Breaktime = breaktime;
            this.IsFixed = isFixed;
            this.IsActive = isActive;
            this.LastModified = lastModified;
        }

        public override string ToString()
        {
            return string.Format("AmIn:{0},LunchOut:{1},LunchIn:{2},CoffeeOut:{3},CoffeeIn:{4},PmOut:{5}",
                this.AMIn,this.LunchOut,this.LunchIn,this.CoffeeOut,this.CoffeeIn,this.PmOut);
        }

        public string StringAMIn {
            get {
                return DateTime.Today.Add(this.AMIn).ToString("hh:mm tt");
            }
        }

        public string StringLunchOut {
            get {
                if (this.ScheduleType == 1 || this.ScheduleType == 3)
                    return DateTime.Today.Add(this.LunchOut).ToString("hh:mm tt");
                else
                    return string.Empty;
            }
        }

        public string StringLunchIn {
            get {
                if (this.ScheduleType == 1 || this.ScheduleType == 3)
                    return DateTime.Today.Add(this.LunchIn).ToString("hh:mm tt");
                else
                    return string.Empty;
            }
        }

        public string StringCoffeeOut {
            get {
                if (this.ScheduleType == 1 || this.ScheduleType == 2)
                    return DateTime.Today.Add(this.CoffeeOut).ToString("hh:mm tt");
                else
                    return string.Empty;
            }
        }

        public string StringCoffeeIn {
            get {
                if (this.ScheduleType == 1 || this.ScheduleType == 2)
                    return DateTime.Today.Add(this.CoffeeIn).ToString("hh:mm tt");
                else
                    return string.Empty;
            }
        }

        public string StringPmOut {
            get {
                return DateTime.Today.Add(this.PmOut).ToString("hh:mm tt");
            }
        }
            
        public static List<ShiftingSchedule> GetSchedules(Connection connection) 
        {
            return GetDatas(connection,FilterQuery(new FilterClause<int>(),
                new FilterClause<bool>(),new FilterClause<bool>(),new FilterClause<int>()));
        }

        public static List<ShiftingSchedule> GetAllCasherCheckerSchedulePicker(Connection connection) {
            return GetDatas(connection,FilterQueryCasherCheckerSchedule());
        }

        public static List<ShiftingSchedule> GetActiveSchedules(Connection connection,bool isActive) 
        {
            return GetDatas(connection,FilterQuery(new FilterClause<int>(),
                new FilterClause<bool>(isActive),new FilterClause<bool>(),new FilterClause<int>()));
        }

        public static List<ShiftingSchedule> GetFixedSchedules(Connection connection,bool isFixed) 
        {
            return GetDatas(connection,FilterQuery(new FilterClause<int>(),
                new FilterClause<bool>(),new FilterClause<bool>(isFixed),new FilterClause<int>()));
        }

        public static ShiftingSchedule GetSchedule(Connection connection,int id) 
        {
            return GetData(connection,FilterQuery(new FilterClause<int>(id),
                new FilterClause<bool>(),new FilterClause<bool>(),new FilterClause<int>()));
        }

        private static string FilterQuery(FilterClause<int> id,FilterClause<bool> isActive,
            FilterClause<bool> isFixed,FilterClause<int> scheduleType) 
        {
            string idWhereClause = string.Empty;
            string isActiveWhereClause = string.Empty;
            string isFixedWhereClause = string.Empty;
            string scheduleTypeWhereClause = string.Empty;

            if (id.IsFilter)
                idWhereClause = " and Pk = " + id.Value + " ";
            if (isActive.IsFilter)
                isActiveWhereClause = " and Status = '" + isActive.Value + "' ";
            if(isFixed.IsFilter)
                isFixedWhereClause = " and Fixed = '" + isFixed.Value + "' ";
            if (scheduleType.IsFilter)
                scheduleTypeWhereClause = " and ScheduleType = " + scheduleType.Value + " ";

            string query = "SELECT PK Id,ScheduleType,ShiftName ShiftingName,isnull(ShiftType,0)ShiftingType,isnull(IN_AM,'1901-01-01')AMIn, " +
	                             "isnull(OUT_Lunch,'1901-01-01')LunchOut,isnull(IN_Lunch,'1901-01-01')LunchIn, " +
	                             "isnull(OUT_Break,'1901-01-01')CoffeeOut,isnull(IN_Break,'1901-01-01')CoffeeIn, " +
	                             "isnull(OUT_PM,'1901-01-01')PMOut,Lunch Lunchtime,BreakTime Breaktime, " +
	                             "Fixed IsFixed,isnull(Status,0) IsActive,LastModifiedBy LastModified " +
                           "FROM ShiftingSchedule " +
                           "where 1=1 " + idWhereClause + isActiveWhereClause +
                           isFixedWhereClause + scheduleTypeWhereClause;
            return query;
        }

        private static string FilterQueryCasherCheckerSchedule() {
            string query = "SELECT a.PK Id,a.ScheduleType,a.ShiftName ShiftingName,isnull(a.ShiftType,0)ShiftingType,isnull(a.IN_AM,'1901-01-01')AMIn, " +
	                             "isnull(a.OUT_Lunch,'1901-01-01')LunchOut,isnull(a.IN_Lunch,'1901-01-01')LunchIn, " +
	                             "isnull(a.OUT_Break,'1901-01-01')CoffeeOut,isnull(a.IN_Break,'1901-01-01')CoffeeIn, " +
	                             "isnull(a.OUT_PM,'1901-01-01')PMOut,a.Lunch Lunchtime,a.BreakTime Breaktime, " +
	                             "a.Fixed IsFixed,a.Status IsActive,a.LastModifiedBy LastModified " +
                           "FROM ShiftingSchedule a " +
                           "join tbl_DCasherCheckerSchedule b on a.Pk = b.ShiftingId ";
            return query;
        }

        private static List<ShiftingSchedule> GetDatas(Connection connection,string query)
        {
            List<ShiftingSchedule> result = new List<ShiftingSchedule>();
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                int rowId = Convert.ToInt32(d.Rows[i]["Id"]);
                result.Add(new ShiftingSchedule(Convert.ToInt32(d.Rows[i]["Id"]), Convert.ToInt32(d.Rows[i]["ScheduleType"]),
                    d.Rows[i]["ShiftingName"].ToString(), Convert.ToInt32(d.Rows[i]["ShiftingType"]), Convert.ToDateTime(d.Rows[i]["AMIn"].ToString()).TimeOfDay,
                    Convert.ToDateTime(d.Rows[i]["LunchOut"].ToString()).TimeOfDay, Convert.ToDateTime(d.Rows[i]["LunchIn"].ToString()).TimeOfDay,
                    Convert.ToDateTime(d.Rows[i]["CoffeeOut"].ToString()).TimeOfDay, Convert.ToDateTime(d.Rows[i]["CoffeeIn"].ToString()).TimeOfDay,
                    Convert.ToDateTime(d.Rows[i]["PMOut"].ToString()).TimeOfDay, Convert.ToInt32(d.Rows[i]["Lunchtime"]),
                    Convert.ToInt32(d.Rows[i]["Breaktime"]), Convert.ToBoolean(d.Rows[i]["IsFixed"]), Convert.ToBoolean(d.Rows[i]["IsActive"]),
                    d.Rows[i]["LastModified"].ToString()));
            }
            return result;
        }

        private static ShiftingSchedule GetData(Connection connection,string query) 
        {
            ShiftingSchedule result = null;
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result = new ShiftingSchedule(Convert.ToInt32(d.Rows[i]["Id"]), Convert.ToInt32(d.Rows[i]["ScheduleType"]),
                    d.Rows[i]["ShiftingName"].ToString(), Convert.ToInt32(d.Rows[i]["ShiftingType"]), Convert.ToDateTime(d.Rows[i]["AMIn"].ToString()).TimeOfDay,
                    Convert.ToDateTime(d.Rows[i]["LunchOut"].ToString()).TimeOfDay, Convert.ToDateTime(d.Rows[i]["LunchIn"].ToString()).TimeOfDay,
                    Convert.ToDateTime(d.Rows[i]["CoffeeOut"].ToString()).TimeOfDay, Convert.ToDateTime(d.Rows[i]["CoffeeIn"].ToString()).TimeOfDay,
                    Convert.ToDateTime(d.Rows[i]["PMOut"].ToString()).TimeOfDay, Convert.ToInt32(d.Rows[i]["Lunchtime"]),
                    Convert.ToInt32(d.Rows[i]["Breaktime"]), Convert.ToBoolean(d.Rows[i]["IsFixed"]), Convert.ToBoolean(d.Rows[i]["IsActive"]),
                    d.Rows[i]["LastModified"].ToString());
            }
            return result;
        }

        public static bool CreateShiftingSchedule(Connection connection,ShiftingSchedule schedule) 
        {
            string lunchOut = string.Empty;
            string lunchIn = string.Empty;
            string coffeeOut = string.Empty;
            string coffeeIn = string.Empty;

            if (schedule.ScheduleType == 1)
            {
                lunchOut = "'" + schedule.LunchOut + "'";
                lunchIn = "'" + schedule.LunchIn + "'";
                coffeeOut = "'" + schedule.CoffeeOut + "'";
                coffeeIn = "'" + schedule.CoffeeIn + "'";
            }
            else if (schedule.ScheduleType == 2) {
                lunchOut = "null";
                lunchIn = "null";
                coffeeOut = "'" + schedule.CoffeeOut + "'";
                coffeeIn = "'" + schedule.CoffeeIn + "'";
            }
            else if (schedule.ScheduleType == 3)
            {
                lunchOut = "'" + schedule.LunchOut + "'";
                lunchIn = "'" + schedule.LunchIn + "'";
                coffeeOut = "null";
                coffeeIn = "null";
            }
            else {
                lunchOut = "null";
                lunchIn = "null";
                coffeeOut = "null";
                coffeeIn = "null";
            }

            string query = "insert ShiftingSchedule (ScheduleType,ShiftName,ShiftType, " +
                               "IN_AM,OUT_Lunch,IN_Lunch,OUT_Break,IN_Break,OUT_PM,Lunch,BreakTime, " +
                               "Fixed,LastModifiedBy,Status) " +
                           "values (" + schedule.ShiftingType + ",'" + Connection.SqlString(schedule.ShiftingName) + "'," + schedule.ShiftingType + ", " +
	                           "'" + schedule.AMIn + "'," + lunchOut + "," + lunchIn + "," + coffeeOut + "," + coffeeIn + ",'" + schedule.PmOut + 
                               "'," + schedule.Lunchtime + "," + schedule.Breaktime + ",'" + Convert.ToInt32(schedule.IsFixed) + "','" + 
                               Connection.SqlString(schedule.LastModified) + "',1) ";

            return connection.Execute(query);
        }

        public static bool CreateCasherCheckerShiftingPicker(Connection connection,List<ShiftingSchedule> schedules) {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.Append("declare @tmpTable table(Id int,LastModified varchar(50)); ");
            for (int i = 0; i < schedules.Count; i++)
            {
                sb.Append("insert @tmpTable values (" + schedules[i].Id + ",'" + 
                    Connection.SqlString(schedules[i].LastModified) + "') ");
            }

            sb.Append("insert tbl_DCasherCheckerSchedule " +
                      "select b.Id,b.LastModified " +
                      "from tbl_DCasherCheckerSchedule a " +
                      "right join @tmpTable b on a.ShiftingId = b.Id " +
                      "where a.ShiftingId is null ");

            return connection.Execute(sb.ToString());
        }

        public static bool DeleteCasherCheckerShiftingPicker(Connection connection,int id) 
        {
            return connection.Execute("delete tbl_DCasherCheckerSchedule where ShiftingId = " + id + " ");
        }
    }
}

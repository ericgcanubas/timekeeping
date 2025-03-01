using System;
using System.Collections.Generic;

namespace TimeKeepingDataCode.Biometrics
{
    public class ScheduleType
    {
        public int Id { get; set; }
        public string ScheduleName { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }

        public ScheduleType(int id,string scheduleName,
            DateTime dateCreated,string createdBy)
        {
            this.Id = id;
            this.ScheduleName = scheduleName;
            this.DateCreated = dateCreated;
            this.CreatedBy = createdBy;
        }

        public override string ToString()
        {
            return string.Format("Id={0},Name={1}",this.Id,this.ScheduleName);
        }

        public static List<ScheduleType> GetScheduleTypes(Connection connection) 
        {
            return GetDatas(connection,QueryFilter(new FilterClause<int>(),new FilterClause<string>()));
        }

        public static ScheduleType GetScheduleType(Connection connection,int id) 
        {
            return GetData(connection,QueryFilter(new FilterClause<int>(id),new FilterClause<string>()));
        }

        private static string QueryFilter(FilterClause<int> id,FilterClause<string> name) 
        {
            string idWhereClause = string.Empty;
            string nameWhereClause = string.Empty;

            if (id.IsFilter)
                idWhereClause = " and Id = " + id.Value + " ";
            if (name.IsFilter)
                nameWhereClause = " and ScheduleName = '" + Connection.SqlString(name.Value) + "' ";

            string query = "SELECT Id,ScheduleName,DateCreated,CreatedBy " +
                           "FROM tbl_DScheduleType " +
                           "where 1=1 ";
            return query;
        }

        private static List<ScheduleType> GetDatas(Connection connection,string query) 
        {
            List<ScheduleType> result = new List<ScheduleType>();
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result.Add(new ScheduleType(Convert.ToInt32(d.Rows[i]["Id"]), d.Rows[i]["ScheduleName"].ToString(),
                    Convert.ToDateTime(d.Rows[i]["DateCreated"]),d.Rows[i]["CreatedBy"].ToString()));
            }
            return result;
        }

        private static ScheduleType GetData(Connection connection,string query) 
        {
            ScheduleType result = null;
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result = new ScheduleType(Convert.ToInt32(d.Rows[i]["Id"]), d.Rows[i]["ScheduleName"].ToString(),
                    Convert.ToDateTime(d.Rows[i]["DateCreated"]), d.Rows[i]["CreatedBy"].ToString());
            }
            return result;
        }
    }
}

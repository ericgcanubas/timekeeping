using System;
using System.Collections.Generic;

namespace TimeKeepingDataCode.Biometrics
{
    public class ShiftingType
    {
        public int Pk { get; set; }
        public string ShiftType { get; set; }

        public ShiftingType(int pk,string shiftType)
        {
            this.Pk = pk;
            this.ShiftType = shiftType;
        }

        public static List<ShiftingType> GetShiftingTypes (Connection connection)
        {
            return GetDatas(connection,FilterQuery());
        }

        private static string FilterQuery() 
        {
            string query = "SELECT PK,ShiftType " +
                           "FROM ShiftingType " +
                           "where 1= 1 ";
            return query;
        }

        private static List<ShiftingType> GetDatas(Connection connection,string query) 
        {
            List<ShiftingType> result = new List<ShiftingType>();
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result.Add(new ShiftingType(Convert.ToInt32(d.Rows[i]["Pk"]), d.Rows[i]["ShiftType"].ToString()));
            }
            return result;
        }

        private static ShiftingType GetData(Connection connection,string query) 
        {
            ShiftingType result = null;
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result = new ShiftingType(Convert.ToInt32(d.Rows[i]["Pk"]), d.Rows[i]["ShiftType"].ToString());
            }
            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeKeepingDataCode.Biometrics
{
    public class HolidayName
    {
        public int Pk { get; set; }
        public int CntrlId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }

        public HolidayName(int pk,int cntrlId,string holidayName,
            DateTime holidayDate,string holidayType)
        {
            this.Pk = pk;
            this.CntrlId = cntrlId;
            this.Description = holidayName;
            this.Date = holidayDate;
            this.Type = holidayType;
        }

        private static string QueryFilter(FilterClause<int> pk,FilterClause<int> cntrlId) 
        {
            string pkWhereClause = string.Empty;
            string cntrlIdWhereClause = string.Empty;

            if (pk.IsFilter)
                pkWhereClause = " and HolidayNamePk = " + pk.Value + " ";
            if (cntrlId.IsFilter)
                cntrlIdWhereClause = " and HolidayCntrlId = " + cntrlId.Value + " ";

            string query = "SELECT HolidayNamePk,HolidayCntrlId,HolidayName, " +
                                  "HolidayDate,HolidayType " +
                           "FROM tbl_HolidayName " +
                           "where 1= 1 " + pkWhereClause + cntrlIdWhereClause;
            return query;
        }

        private static List<HolidayName> GetDatas(Connection connection,string query) 
        {
            List<HolidayName> result = new List<HolidayName>();
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result.Add(new HolidayName(Convert.ToInt32(d.Rows[i]["HolidayNamePk"]), Convert.ToInt32(d.Rows[i]["HolidayCntrlId"]),
                    d.Rows[i]["HolidayName"].ToString(), Convert.ToDateTime(d.Rows[i]["HolidayDate"]), d.Rows[i]["HolidayType"].ToString()));
            }
            return result;
        }

        private static HolidayName GetData(Connection connection, string query) 
        {
            HolidayName result = null;
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result = new HolidayName(Convert.ToInt32(d.Rows[i]["HolidayNamePk"]), Convert.ToInt32(d.Rows[i]["HolidayCntrlId"]),
                    d.Rows[i]["HolidayName"].ToString(), Convert.ToDateTime(d.Rows[i]["HolidayDate"]), d.Rows[i]["HolidayType"].ToString());
            }
            return result;
        }

        public static List<HolidayName> GetAllHolidayNames(Connection connection)
        {
            return GetDatas(connection,QueryFilter(new FilterClause<int>(),new FilterClause<int>()));
        }

        public static List<HolidayName> GetAllHolidayNames(Connection connection,int cntrlId)
        {
            return GetDatas(connection, QueryFilter(new FilterClause<int>(), new FilterClause<int>(cntrlId)));
        }

        public static HolidayName GetHolidayName(Connection connection,int id) 
        {
            return GetData(connection,QueryFilter(new FilterClause<int>(id),new FilterClause<int>()));
        }

        public static int GetLastId(Connection connection,int holidayNamePk) 
        {
            string query = "select top 1 HolidayNamePk " +
                           "from tbl_HolidayName " +
                           "where HolidayCntrlId = " + holidayNamePk + " " +
                           "order by HolidayNamePk desc ";
            var d = connection.GetData(query);

            if (d.Rows.Count > 0)
                return Convert.ToInt32(d.Rows[0]["HolidayNamePk"]);
            else
                return 0;
        }

        public static bool IsDateHoliday(Connection connection,DateTime date,out string holidayType)
        {
            string query = "select HolidayType " +
                           "from tbl_HolidayName " +
                           "where HolidayDate = '" + date.ToShortDateString() + "' " ;

            var d = connection.GetData(query);

            if (d.Rows.Count > 0)
            {
                holidayType = d.Rows[0]["HolidayType"].ToString();
                return true;
            }
            else {
                holidayType = string.Empty;
                return false;
            }
        }
    }
}

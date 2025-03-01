using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeKeepingDataCode.PayrollSystem
{
    public static class StaticHelper
    {
        public static bool IsPayrollLocked(Connection connection,DateTime date) 
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("declare @date date = '" + date.ToShortDateString() + "' " +
                      "declare @payrollPeriod int; ");

            sb.Append("select @payrollPeriod = a.PPeriodNo " +
                      "from PPeriod a " +
                      "where @date between a.PDateFrom and a.PDateTo ");

            sb.Append("select a.ID " +
                      "from tbl_NewCompensation a " +
                      "where a.PayrollPeriod = @payrollPeriod " +
                      "and a.PayrollLocked = 1 ");

            var d = connection.GetData(sb.ToString());
            if (d.Rows.Count > 0)
                return true;
            else
                return false;
        }

        public static double MidNightMinimum(Connection connection,DateTime dateEffect) 
        {
            double result = 0;

            string query = "select top 1 MinHour " +
                           "from tbl_MidNight_Minimum_Hour " +
                           "where EffectDate <= '" + dateEffect.ToShortDateString() + "' " +
                           "order by EffectDate desc ";

            var d = connection.GetData(query);

            if (d.Rows.Count > 0) 
                result = Convert.ToDouble(d.Rows[0]["MinHour"]);

            return result;
        }

        public static DateTime DateHired(Connection connection,int empNo) 
        {
            DateTime result = new DateTime(1901,1,1);

            string query = "select isnull(EDateHired,'1901-01-01') DateHired " +
                           "from tbl_Profile_IDNumber " +
                           "where Pk = " + empNo + " ";

            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result = Convert.ToDateTime(d.Rows[i]["DateHired"]);
            }
            return result;
        }

        public static double SecurityOTRate(Connection connection,DateTime dateEffect) 
        {
            string query = "select top 1 Rate from SecurityOTRate " +
                           "where EffectDate <= '" + dateEffect.ToShortDateString()  + "' " +
                           "order by PK desc ";

            var d = connection.GetData(query);
            if (d.Rows.Count > 0)
                return Convert.ToDouble(d.Rows[0]["Rate"]);
            else
                return 0;
        }
    }
}

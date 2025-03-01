using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeKeepingDataCode.PayrollSystem
{
    public class ClearingRate
    {
        public int PK { get; set; }
        public DateTime EffectiveDate { get; set; }
        public double Rate { get; set; }
        public double MidNightRate { get; set; }
        public double OverTimeRate { get; set; }
        public double MinHoursMonthly { get; set; }
        public double MinHoursDaily { get; set; }

        public ClearingRate(int pk,DateTime effectiveDate,double rate,
            double midNightRate,double overtimeRate,double minMonthlyRate,
            double minHoursDaily)
        {
            this.PK = pk;
            this.EffectiveDate = effectiveDate;
            this.Rate = rate;
            this.MidNightRate = midNightRate;
            this.OverTimeRate = overtimeRate;
            this.MinHoursMonthly = minMonthlyRate;
            this.MinHoursDaily = minHoursDaily;
        }

        private static string QueryFilter(FilterClause<int> pk,FilterClause<DateTime> dateEffect,FilterClause<DateTime> current) 
        {
            string pkWhereClause = string.Empty;
            string dateEffectWhereClause = string.Empty;
            string currentWhereClause = string.Empty;
            string topWhereClause = string.Empty;
            string orderClause = string.Empty;

            if (pk.IsFilter)
                pkWhereClause = " and PK = " +  pk.Value + " ";
            if (dateEffect.IsFilter)
                dateEffectWhereClause = " and EffectDate = '" + dateEffect.Value.ToShortDateString() + "' ";
            if (current.IsFilter)
            {
                currentWhereClause = " and EffectDate <= '" + current.Value.ToShortDateString() + "' ";
                topWhereClause = " top 1 ";
                orderClause = " order by EffectDate desc ";
            }

            string query = "SELECT " + topWhereClause + " PK,EffectDate,Rate,MidnightRate, " +
                                  "OTRate,MinimumHrsMonthly,MinimumHrsDaily " +
                           "FROM ClearingRate " +
                           "where 1=1 " + pkWhereClause + dateEffectWhereClause + currentWhereClause + orderClause;

            return query;
        }

        private static List<ClearingRate> GetDatas(Connection connection,string query) 
        {
            List<ClearingRate> result = new List<ClearingRate>();
            var d = connection.GetData(query);

            for (int i = 0; i < d.Rows.Count; i++)
            {
                result.Add(new ClearingRate(Convert.ToInt32(d.Rows[i]["PK"]), Convert.ToDateTime(d.Rows[i]["EffectDate"]),
                    Convert.ToDouble(d.Rows[i]["Rate"]), Convert.ToDouble(d.Rows[i]["MidnightRate"]),
                    Convert.ToDouble(d.Rows[i]["OTRate"]), Convert.ToDouble(d.Rows[i]["MinimumHrsMonthly"]),
                    Convert.ToDouble(d.Rows[i]["MinimumHrsDaily"])));    
            }
            return result;
        }

        private static ClearingRate GetData(Connection connection, string query)
        {
            ClearingRate result = null;
            var d = connection.GetData(query);

            for (int i = 0; i < d.Rows.Count; i++)
            {
                result = new ClearingRate(Convert.ToInt32(d.Rows[i]["PK"]), Convert.ToDateTime(d.Rows[i]["EffectDate"]),
                    Convert.ToDouble(d.Rows[i]["Rate"]), Convert.ToDouble(d.Rows[i]["MidnightRate"]),
                    Convert.ToDouble(d.Rows[i]["OTRate"]), Convert.ToDouble(d.Rows[i]["MinimumHrsMonthly"]),
                    Convert.ToDouble(d.Rows[i]["MinimumHrsDaily"]));
            }
            return result;
        }

        public static ClearingRate GetCurrentClearingRate(Connection connection,DateTime dateEffect) 
        {
            return GetData(connection,QueryFilter(new FilterClause<int>(),new FilterClause<DateTime>(),new FilterClause<DateTime>(dateEffect)));
        }

        public static ClearingRate GetCurrentClearingRate(Connection connection, int empPk)
        {
            return GetData(connection, QueryFilter(new FilterClause<int>(empPk), new FilterClause<DateTime>(), new FilterClause<DateTime>()));
        }

        public static List<ClearingRate> GetAllClearingRates(Connection connection) 
        {
            return GetDatas(connection,QueryFilter(new FilterClause<int>(),new FilterClause<DateTime>(),new FilterClause<DateTime>()));
        }
    }
}

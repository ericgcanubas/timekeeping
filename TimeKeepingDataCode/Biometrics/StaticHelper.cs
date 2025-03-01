using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeKeepingDataCode.Biometrics
{
    public static class StaticHelper
    {
        private static string QueryCheckPayrollLocked(FilterClause<DateTime> dateFrom,FilterClause<DateTime> dateTo,
            FilterClause<int> egroup,FilterClause<int> notSectionId,FilterClause<string> notTin,
            FilterClause<string> supplier,FilterClause<string> tin,FilterClause<int> empNo) 
        {
            string dateFromWhereClause = string.Empty;
            string dateToWhereClaue = string.Empty;
            string egroupWhereClause = string.Empty;
            string notSectionIdWhereClause = string.Empty;
            string notTinWhereClause = string.Empty;
            string supplierWhereClause = string.Empty;
            string tinwWhereClause = string.Empty;
            string empNoWhereClause = string.Empty;

            if (dateFrom.IsFilter)
                dateFromWhereClause = " and DateFrom = '" + dateFrom.Value.ToShortDateString() + "' ";
            if (dateTo.IsFilter)
                dateToWhereClaue = " and DateTo = '" + dateTo.Value.ToShortDateString() + "' ";
            if (egroup.IsFilter)
                egroupWhereClause = " and EGroup = " + egroup.Value + " ";
            if (notSectionId.IsFilter)
                notSectionIdWhereClause = " and SectID != " + notSectionId.Value + " ";
            if (notTin.IsFilter)
                notTinWhereClause = " and Tin != '" + Connection.SqlString(notTin.Value) + "' ";
            if (supplier.IsFilter)
                supplierWhereClause = " and Supplier ='" + Connection.SqlString(supplier.Value) + "' ";
            if (tin.IsFilter)
                tinwWhereClause = " and Tin = '" + Connection.SqlString(notTin.Value) + "' ";
            if (empNo.IsFilter)
                empNoWhereClause = " and EmpNo = " + empNo.Value + " ";

            string query = "SELECT TOP 1 EmpNo " +
                           "From Time_Summary " +
                           "WHERE Locked = 1 " +
                           dateFromWhereClause + dateToWhereClaue + egroupWhereClause + 
                           notSectionIdWhereClause + notTinWhereClause + supplierWhereClause + tinwWhereClause + empNoWhereClause +
                           "union " +
                           "SELECT TOP 1 EmpNo " +
                           "From Time_Summary_Locked " +
                           "WHERE 1= 1 " +
                           dateFromWhereClause + dateToWhereClaue + egroupWhereClause + 
                           notSectionIdWhereClause + notTinWhereClause + supplierWhereClause + tinwWhereClause + empNoWhereClause;

            return query;
        }

        private static string QueryCheckPayrollLockedPromoAcc(DateTime dateFrom,DateTime dateTo) 
        {
            string query = "SELECT TOP 1 EmpNo " +
                           "From Time_Summary " +
                           "WHERE ((EGroup = 9) AND (DateFrom = '" + dateFrom.ToShortDateString() + "') AND (DateTo = '" + dateTo.ToShortDateString() + "') AND (Supplier <> 'SMC') AND (Locked = 1)) " +
                           "OR ((EGroup = 11) AND (DateFrom = '" + dateFrom.ToShortDateString() + "') AND (DateTo = '" + dateTo.ToShortDateString() + "') AND (Supplier <>'SMC') AND (Locked = 1)) " +
                           "OR ((EGroup = 15) AND (DateFrom = '" + dateFrom.ToShortDateString() + "') AND (DateTo = '" + dateTo.ToShortDateString() + "') AND (Supplier <>'SMC') AND (Locked = 1)) " +
                           "union " +
                           "SELECT TOP 1 EmpNo " +
                           "From Time_Summary_Locked " +
                           "WHERE ((EGroup = 9) AND (DateFrom = '" + dateFrom.ToShortDateString() + "') AND (DateTo = '" + dateTo.ToShortDateString() + "') AND (Supplier <> 'SMC') AND (Locked = 1)) " +
                           "OR ((EGroup = 11) AND (DateFrom = '" + dateFrom.ToShortDateString() + "') AND (DateTo = '" + dateTo.ToShortDateString() + "') AND (Supplier <>'SMC') AND (Locked = 1)) " +
                           "OR ((EGroup = 15) AND (DateFrom = '" + dateFrom.ToShortDateString() + "') AND (DateTo = '" + dateTo.ToShortDateString() + "') AND (Supplier <>'SMC') AND (Locked = 1)) ";
            return query;
        }

        private static string QueryCheckPayrollLockedNonRegularContract(DateTime dateFrom,DateTime dateTo) 
        {
            string query = "SELECT TOP 1 EmpNo " +
                           "From Time_Summary " +
                           "WHERE ((DateFrom = '" + dateFrom.ToShortDateString() + "') AND (DateTo = '" + dateTo.ToShortDateString() + "') AND (SectID = 94)) " +
                           "OR ((DateFrom = '" + dateFrom.ToShortDateString() + "') AND (DateTo = '" + dateTo.ToShortDateString() + "') AND (EmpStatus = 14)) " +
                           "union " +
                           "SELECT TOP 1 EmpNo " +
                           "From Time_Summary_Locked " +
                           "WHERE ((DateFrom = '" + dateFrom.ToShortDateString() + "') AND (DateTo = '" + dateTo.ToShortDateString() + "') AND (SectID = 94)) " +
                           "OR ((DateFrom = '" + dateFrom.ToShortDateString() + "') AND (DateTo = '" + dateTo.ToShortDateString() + "') AND (EmpStatus = 14)) ";

            return query;
        }

        public static bool IsPayrollLocked(Connection connection,DateTime dateFrom,DateTime dateTo) 
        {
            return IsLocked(connection, QueryCheckPayrollLocked(new FilterClause<DateTime>(dateFrom),
                new FilterClause<DateTime>(dateTo), new FilterClause<int>(), new FilterClause<int>(),
                new FilterClause<string>(), new FilterClause<string>(), new FilterClause<string>(),new FilterClause<int>()));
        }

        public static bool IsMW1ALocked(Connection connection,DateTime dateFrom,DateTime dateTo) 
        {
            return IsLocked(connection, QueryCheckPayrollLocked(new FilterClause<DateTime>(dateFrom),
                new FilterClause<DateTime>(dateTo), new FilterClause<int>(8), new FilterClause<int>(94),
                new FilterClause<string>("ON PROCESS"), new FilterClause<string>(),new FilterClause<string>(),new FilterClause<int>()));
        }

        public static bool IsMW1BLocked(Connection connection, DateTime dateFrom, DateTime dateTo)
        {
            return IsLocked(connection, QueryCheckPayrollLocked(new FilterClause<DateTime>(dateFrom),
                new FilterClause<DateTime>(dateTo), new FilterClause<int>(8), new FilterClause<int>(94),
                new FilterClause<string>(), new FilterClause<string>(), new FilterClause<string>("ON PROCESS"),new FilterClause<int>()));
        }

        public static bool IsMW2ALocked(Connection connection, DateTime dateFrom, DateTime dateTo)
        {
            return IsLocked(connection, QueryCheckPayrollLocked(new FilterClause<DateTime>(dateFrom),
                new FilterClause<DateTime>(dateTo), new FilterClause<int>(7), new FilterClause<int>(94),
                new FilterClause<string>("ON PROCESS"), new FilterClause<string>(), new FilterClause<string>(),new FilterClause<int>()));
        }

        public static bool IsMW2BLocked(Connection connection, DateTime dateFrom, DateTime dateTo)
        {
            return IsLocked(connection, QueryCheckPayrollLocked(new FilterClause<DateTime>(dateFrom),
                new FilterClause<DateTime>(dateTo), new FilterClause<int>(7), new FilterClause<int>(94),
                new FilterClause<string>(), new FilterClause<string>(), new FilterClause<string>("ON PROCESS"),new FilterClause<int>()));
        }

        public static bool IsContractualLocked(Connection connection, DateTime dateFrom, DateTime dateTo)
        {
            return IsLocked(connection, QueryCheckPayrollLocked(new FilterClause<DateTime>(dateFrom),
                new FilterClause<DateTime>(dateTo), new FilterClause<int>(6), new FilterClause<int>(94),
                new FilterClause<string>(), new FilterClause<string>(), new FilterClause<string>(),new FilterClause<int>()));
        }

        public static bool IsOJT2Locked(Connection connection, DateTime dateFrom, DateTime dateTo)
        {
            return IsLocked(connection, QueryCheckPayrollLocked(new FilterClause<DateTime>(dateFrom),
                new FilterClause<DateTime>(dateTo), new FilterClause<int>(3), new FilterClause<int>(94),
                new FilterClause<string>(), new FilterClause<string>(), new FilterClause<string>(),new FilterClause<int>()));
        }

        public static bool IsOJT1Locked(Connection connection, DateTime dateFrom, DateTime dateTo)
        {
            return IsLocked(connection, QueryCheckPayrollLocked(new FilterClause<DateTime>(dateFrom),
                new FilterClause<DateTime>(dateTo), new FilterClause<int>(2), new FilterClause<int>(94),
                new FilterClause<string>(), new FilterClause<string>(), new FilterClause<string>(),new FilterClause<int>()));
        }

        public static bool IsExposureLocked(Connection connection, DateTime dateFrom, DateTime dateTo)
        {
            return IsLocked(connection, QueryCheckPayrollLocked(new FilterClause<DateTime>(dateFrom),
                new FilterClause<DateTime>(dateTo), new FilterClause<int>(1), new FilterClause<int>(94),
                new FilterClause<string>(), new FilterClause<string>(), new FilterClause<string>(),new FilterClause<int>()));
        }

        public static bool IsSeasonalLocked(Connection connection, DateTime dateFrom, DateTime dateTo)
        {
            return IsLocked(connection, QueryCheckPayrollLocked(new FilterClause<DateTime>(dateFrom),
                new FilterClause<DateTime>(dateTo), new FilterClause<int>(14), new FilterClause<int>(94),
                new FilterClause<string>(), new FilterClause<string>(), new FilterClause<string>(),new FilterClause<int>()));
        }

        public static bool IsPromoAccLocked(Connection connection, DateTime dateFrom, DateTime dateTo)
        {
            return IsLocked(connection,QueryCheckPayrollLockedPromoAcc(dateFrom,dateTo));
        }

        public static bool IsInactiveCompanyLocked(Connection connection, DateTime dateFrom, DateTime dateTo)
        {
            return IsLocked(connection, QueryCheckPayrollLocked(new FilterClause<DateTime>(dateFrom),
                new FilterClause<DateTime>(dateTo), new FilterClause<int>(9), new FilterClause<int>(94),
                new FilterClause<string>(), new FilterClause<string>("SMC"), new FilterClause<string>(),new FilterClause<int>()));
        }

        public static bool IsNonRegularContractLocked(Connection connection,DateTime dateFrom,DateTime dateTo) 
        {
            return IsLocked(connection, QueryCheckPayrollLockedNonRegularContract(dateFrom, dateTo));
        }

        public static bool IsEmployeeLocked(Connection connection, DateTime dateFrom, DateTime dateTo,int empNo)
        {
            return IsLocked(connection, QueryCheckPayrollLocked(new FilterClause<DateTime>(dateFrom),
                new FilterClause<DateTime>(dateTo), new FilterClause<int>(), new FilterClause<int>(),
                new FilterClause<string>(), new FilterClause<string>(), new FilterClause<string>(), new FilterClause<int>(empNo)));
        }

        private static bool IsLocked(Connection connection,string query) 
        {
            bool result = false;
            var d = connection.GetData(query);
            if (d.Rows.Count > 0)
                result = true;
            return result;
        }

        public static double TotalClearing(Connection connection,DateTime dateFrom,DateTime dateTo,int empNo) 
        {
            var d = connection.GetData("exec A_sp_Get_Clearing " + empNo + ",'" + dateFrom.ToShortDateString() + "','" + dateTo.ToShortDateString() + "'");
            if (d.Rows.Count > 0)
                return Convert.ToDouble(d.Rows[0]["Sessions"]);
            else
                return 0;
        }
    }
}

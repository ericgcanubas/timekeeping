using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeKeepingDataCode.PayrollSystem
{
    public class ActionMemo
    {
        public int Id { get; set; }
        public int EmpId { get; set; }
        public DateTime EffectivityDate { get; set; }
        public DateTime EndContract { get; set; }
        public int EmploymentStatus { get; set; }
        public int TaxStatus { get; set; }
        public int Position { get; set; }
        public int Supplier { get; set; }
        public int Hired { get; set; }
        public int Division { get; set; }
        public int Department { get; set; }
        public int Section { get; set; }
        public int PlaceAssign { get; set; }
        public string Location { get; set; }
        public int TypeOfCompensation { get; set; }
        public string PositionRemarks { get; set; }
        public double RatePerHour { get; set; }
        public double ColaPerHour { get; set; }

        public ActionMemo(int id,int empId,DateTime effectivityDate,DateTime endContract,
            int employmentStatus,int taxStatus,int position,int supplier,int hired,
            int division,int department,int section,int placeAssign,string location,
            int typeOfCompensation,string positionRemarks,double ratePerHour,double colaPerHour)
        {
            this.Id = id;
            this.EmpId = empId;
            this.EffectivityDate = effectivityDate;
            this.EndContract = endContract;
            this.EmploymentStatus = employmentStatus;
            this.TaxStatus = taxStatus;
            this.Position = position;
            this.Supplier = supplier;
            this.Hired = hired;
            this.Division = division;
            this.Department = department;
            this.Section = section;
            this.PlaceAssign = placeAssign;
            this.Location = location;
            this.TypeOfCompensation = typeOfCompensation;
            this.PositionRemarks = positionRemarks;
            this.RatePerHour = ratePerHour;
            this.ColaPerHour = colaPerHour;
        }

        private static string QueryFilter(FilterClause<int> empId,FilterClause<DateTime> effectiveDate,FilterClause<bool> isCurrent) 
        {
            string empIdWhereClause = string.Empty;
            string effectiveDateWhereClause = string.Empty;
            string orderByWhereClause = string.Empty;
            string topWhereClause = string.Empty;

            if (empId.IsFilter)
                empIdWhereClause = " and PEmployeeNo = " + empId.Value + " ";
            if (effectiveDate.IsFilter)
                effectiveDateWhereClause = " and PEffectivityDate <= '" + effectiveDate.Value.ToShortDateString() + "' ";
            if (isCurrent.IsFilter)
            {
                topWhereClause = " top 1 ";
                orderByWhereClause = " order by PEffectivityDate desc ";
            }

            string query = "SELECT " + topWhereClause + " PPamTransactionNo,PEmployeeNo,PEffectivityDate, " +
                                  "isnull(PEndofContract,'1901-01-01')EndContract, " +
                                  "PEmploymentStatus,PTaxStatus,PPosition,PSupplier, " +
                                  "PHired,PDiv,PDept,PSection,PPlaceAssign, " +
                                  "isnull(PLocation,'')Location,PTypeOfCompensation,isnull(PPositionRemarks,'')PPositionRemarks, " +
                                  "isnull(PRatePerHour,0)PRatePerHour,isnull(PPerHourCola,0)PPerHourCola " +
                           "FROM tbl_Profile_Action " +
                           "where 1=1 " + empIdWhereClause + effectiveDateWhereClause + orderByWhereClause;
            return query;
        }

        private static List<ActionMemo> GetDatas(Connection connection,string query) 
        {
            List<ActionMemo> result = new List<ActionMemo>();
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result.Add(new ActionMemo(Convert.ToInt32(d.Rows[i]["PPamTransactionNo"]), Convert.ToInt32(d.Rows[i]["PEmployeeNo"]),
                    Convert.ToDateTime(d.Rows[i]["PEffectivityDate"]), Convert.ToDateTime(d.Rows[i]["EndContract"]),
                    Convert.ToInt32(d.Rows[i]["PEmploymentStatus"]),Convert.ToInt32(d.Rows[i]["PTaxStatus"]),
                    Convert.ToInt32(d.Rows[i]["PPosition"]),Convert.ToInt32(d.Rows[i]["PSupplier"]),
                    Convert.ToInt32(d.Rows[i]["PHired"]),Convert.ToInt32(d.Rows[i]["PDiv"]),Convert.ToInt32(d.Rows[i]["PDept"]),
                    Convert.ToInt32(d.Rows[i]["PSection"]),Convert.ToInt32(d.Rows[i]["PPlaceAssign"]),
                    d.Rows[i]["Location"].ToString(), Convert.ToInt32(d.Rows[i]["PTypeOfCompensation"]),
                    d.Rows[i]["PPositionRemarks"].ToString(), Convert.ToDouble(d.Rows[i]["PRatePerHour"]), 
                    Convert.ToDouble(d.Rows[i]["PPerHourCola"])));
            }
            return result;
        }

        private static ActionMemo GetData(Connection connection,string query) 
        {
            ActionMemo result = null;
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result = new ActionMemo(Convert.ToInt32(d.Rows[i]["PPamTransactionNo"]), Convert.ToInt32(d.Rows[i]["PEmployeeNo"]),
                    Convert.ToDateTime(d.Rows[i]["PEffectivityDate"]), Convert.ToDateTime(d.Rows[i]["EndContract"]),
                    Convert.ToInt32(d.Rows[i]["PEmploymentStatus"]), Convert.ToInt32(d.Rows[i]["PTaxStatus"]),
                    Convert.ToInt32(d.Rows[i]["PPosition"]), Convert.ToInt32(d.Rows[i]["PSupplier"]),
                    Convert.ToInt32(d.Rows[i]["PHired"]), Convert.ToInt32(d.Rows[i]["PDiv"]), Convert.ToInt32(d.Rows[i]["PDept"]),
                    Convert.ToInt32(d.Rows[i]["PSection"]), Convert.ToInt32(d.Rows[i]["PPlaceAssign"]),
                    d.Rows[i]["Location"].ToString(), Convert.ToInt32(d.Rows[i]["PTypeOfCompensation"]),
                    d.Rows[i]["PPositionRemarks"].ToString(), Convert.ToDouble(d.Rows[i]["PRatePerHour"]),
                    Convert.ToDouble(d.Rows[i]["PPerHourCola"]));
            }
            return result;
        }

        public static List<ActionMemo> GetAllActionMemo(Connection connection) 
        {
            return GetDatas(connection,QueryFilter(new FilterClause<int>(),new FilterClause<DateTime>(),new FilterClause<bool>()));
        }

        public static List<ActionMemo> GetAllActionMemo(Connection connection, int empId) {
            return GetDatas(connection, QueryFilter(new FilterClause<int>(empId), new FilterClause<DateTime>(), new FilterClause<bool>()));
        }

        public static List<ActionMemo> GetAllActionMemo(Connection connection, int empId,DateTime dateDate)
        {
            return GetDatas(connection, QueryFilter(new FilterClause<int>(empId), new FilterClause<DateTime>(dateDate), new FilterClause<bool>()));
        }

        public static ActionMemo GetCurrentActionMemo(Connection connection,int empId,DateTime effectiveDate) 
        {
            return GetData(connection,QueryFilter(new FilterClause<int>(empId),new FilterClause<DateTime>(effectiveDate),new FilterClause<bool>(true)));
        }
    }
}

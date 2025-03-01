using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeKeepingDataCode.PayrollSystem
{
    public class TimeSummaryEmployee
    {
        public int EmpNo { get; set; }
        public string EmpIdNumber { get; set; }
        public string EmpName { get; set; }
        public int Status { get; set; }
        public DateTime Effectivity { get; set; }
        public string Supplier { get; set; }
        public int SalaryHold { get; set; }
        public int PamId { get; set; }
        public int CompType { get; set; }
        public int DepId { get; set; }
        public string DepartmentName { get; set; }
        public int SectionId { get; set; }
        public string SectionName { get; set; }
        public int SecSort { get; set; }
        public int PClassBack { get; set; }
        public string TIN { get; set; }
        public int EGroup { get; set; }
        public int PostId { get; set; }
        public string PostName { get; set; }
        public int Hired { get; set; }

        public TimeSummaryEmployee(int empNo,string empIdNumber,string empName,int status,
            DateTime effectivity,string supplier,int salaryHold,int pamId,int compType,
            int depId,string departmentName,int secId,string sectionName,int secSort,
            int pClassBack,string tin,int eGroup,int postId,string postName,int hired)
        {
            this.EmpNo = empNo;
            this.EmpIdNumber = empIdNumber;
            this.EmpName = empName;
            this.Status = status;
            this.Effectivity = effectivity;
            this.Supplier = supplier;
            this.SalaryHold = salaryHold;
            this.PamId = pamId;
            this.CompType = compType;
            this.DepId = depId;
            this.DepartmentName = departmentName;
            this.SectionId = secId;
            this.SectionName = sectionName;
            this.SecSort = secSort;
            this.PClassBack = pClassBack;
            this.TIN = tin;
            this.EGroup = eGroup;
            this.PostId = postId;
            this.PostName = postName;
            this.Hired = hired;
        }

        private static string QueryFilter(FilterClause<int> transType,FilterClause<DateTime> dateFrom,
            FilterClause<DateTime> dateTo,FilterClause<int> groupType,FilterClause<int> empNo) 
        {
            string query = string.Empty;

            if (transType.IsFilter)
            {
                if (transType.Value == 6)
                    query = "exec sp_UpdateTimeSummary_Status " + groupType.Value + ",'" + dateFrom.Value.ToShortDateString() + "','" + dateTo.Value.ToShortDateString() + "' ";
                else
                    query = "exec sp_UpdateTimeSummary_All_Employee " + transType.Value + ",'" + 
                        dateFrom.Value.ToShortDateString() + "','" + dateTo.Value.ToShortDateString() +"',''," + empNo.Value  + ",'' ";
            }

            return query;
        }

        private static List<TimeSummaryEmployee> GetDatas(Connection connection,string query) 
        {
            List<TimeSummaryEmployee> result = new List<TimeSummaryEmployee>();
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result.Add(new TimeSummaryEmployee(Convert.ToInt32(d.Rows[i]["EmpNo"]), d.Rows[i]["EEmployeeIDNo"].ToString(),
                    d.Rows[i]["Emp_Name"].ToString(), Convert.ToInt32(d.Rows[i]["Status"]), Convert.ToDateTime(d.Rows[i]["Effectivity"]),
                    d.Rows[i]["Supplier"].ToString(), Convert.ToInt32(d.Rows[i]["Salary_Hold"]), Convert.ToInt32(d.Rows[i]["PAM"]),
                    Convert.ToInt32(d.Rows[i]["Comp_Type"]), Convert.ToInt32(d.Rows[i]["DeptID"]), d.Rows[i]["DeptName"].ToString(),
                    Convert.ToInt32(d.Rows[i]["SectID"]), d.Rows[i]["SectName"].ToString(), Convert.ToInt32(d.Rows[i]["SectSort"]),
                    Convert.ToInt32(d.Rows[i]["PClass_Back"]), d.Rows[i]["TIN"].ToString(), Convert.ToInt32(d.Rows[i]["EGroup"]),
                    Convert.ToInt32(d.Rows[i]["PostID"]), d.Rows[i]["PostName"].ToString(), Convert.ToInt32(d.Rows[i]["Hired"])));
            }
            return result;
        }

        private static TimeSummaryEmployee GetData(Connection connection,string query) 
        {
            TimeSummaryEmployee result = null;
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result = new TimeSummaryEmployee(Convert.ToInt32(d.Rows[i]["EmpNo"]), d.Rows[i]["EEmployeeIDNo"].ToString(),
                    d.Rows[i]["Emp_Name"].ToString(), Convert.ToInt32(d.Rows[i]["Status"]), Convert.ToDateTime(d.Rows[i]["Effectivity"]),
                    d.Rows[i]["Supplier"].ToString(), Convert.ToInt32(d.Rows[i]["Salary_Hold"]), Convert.ToInt32(d.Rows[i]["PAM"]),
                    Convert.ToInt32(d.Rows[i]["Comp_Type"]), Convert.ToInt32(d.Rows[i]["DeptID"]), d.Rows[i]["DeptName"].ToString(),
                    Convert.ToInt32(d.Rows[i]["SectID"]), d.Rows[i]["SectName"].ToString(), Convert.ToInt32(d.Rows[i]["SectSort"]),
                    Convert.ToInt32(d.Rows[i]["PClass_Back"]), d.Rows[i]["TIN"].ToString(), Convert.ToInt32(d.Rows[i]["EGroup"]),
                    Convert.ToInt32(d.Rows[i]["PostID"]), d.Rows[i]["PostName"].ToString(), Convert.ToInt32(d.Rows[i]["Hired"]));
            }
            return result;
        }

        public static List<TimeSummaryEmployee> GetAllTimeSummaryEmployees(Connection connection,DateTime dateFrom,DateTime dateTo)
        {
            return GetDatas(connection,QueryFilter(new FilterClause<int>(1),
                new FilterClause<DateTime>(dateFrom),new FilterClause<DateTime>(dateTo),new FilterClause<int>(),new FilterClause<int>()));
        }

        public static List<TimeSummaryEmployee> GetAllTimeSummaryEmployeesByGroup(Connection connection,DateTime dateFrom,DateTime dateTo,int groupType)
        {
            return GetDatas(connection,QueryFilter(new FilterClause<int>(6),new FilterClause<DateTime>(dateFrom),
                new FilterClause<DateTime>(dateTo),new FilterClause<int>(groupType),new FilterClause<int>()));
        }

        public static TimeSummaryEmployee GetTimeSummaryEmployee(Connection connection,DateTime dateFrom,DateTime dateTo,int empNo) 
        {
            return GetData(connection,QueryFilter(new FilterClause<int>(2),
                new FilterClause<DateTime>(dateFrom),new FilterClause<DateTime>(dateTo),new FilterClause<int>(),new FilterClause<int>(empNo)));
        }

        public static List<TimeSummaryEmployee> GetAllTimeSummaryEmployeesByAgenctGuard(Connection connection,DateTime dateFrom,DateTime dateTo) 
        {
            return GetDatas(connection, QueryFilter(new FilterClause<int>(9), new FilterClause<DateTime>(dateFrom), 
                new FilterClause<DateTime>(dateTo), new FilterClause<int>(), new FilterClause<int>()));
        }
    }
}

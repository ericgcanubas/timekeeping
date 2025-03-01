using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeKeepingDataCode.PayrollSystem
{
    public class AgencyHoursSalary
    {
        public int PK { get; set; }
        public string EmpName { get; set; }
        public int Period { get; set; }
        public double HoursSMC { get; set; }
        public double HoursAgency { get; set; }
        public double Descripancy { get; set; }
        public double RegHours { get; set; }
        public double Overtime { get; set; }
        public int Locked { get; set; }
        public double RatePerHour { get; set; }
        public double ColaPerHour { get; set; }
        public double OvertimePerHour { get; set; }
        public double RegPaid { get; set; }
        public double OvertimePaid { get; set; }
        public double Cola { get; set; }
        public double TotalPaid { get; set; }
        public string AgencyName { get; set; }
        public string LastModified { get; set; }

        public AgencyHoursSalary(int pk,string empName,int period,double hoursSMC,
            double hoursAgency,double descripancy,double regHours,double colaPerHour,
            double overtimePerHour,double regPaid,double overtimePaid,double cola,
            double totalPaid,string agencyName,string lastModified)
        {
            this.PK = pk;
            this.EmpName = empName;
            this.Period = period;
            this.HoursSMC = hoursSMC;
            this.HoursAgency = hoursAgency;
            this.Descripancy = descripancy;
            this.RegHours = regHours;
            this.ColaPerHour = colaPerHour;
            this.OvertimePerHour = overtimePerHour;
            this.RegPaid = regPaid;
            this.OvertimePaid = overtimePaid;
            this.Cola = cola;
            this.TotalPaid = totalPaid;
            this.AgencyName = agencyName;
            this.LastModified = lastModified;
        }

        private static string QueryFilter(FilterClause<int> pk,FilterClause<string> empName,FilterClause<int> period) 
        {
            string pkWhereClause = string.Empty;
            string empNameWhereClause = string.Empty;
            string periodWhereClause = string.Empty;

            if (pk.IsFilter)
                pkWhereClause = " and Pk = " + pk.Value + " ";
            if (empName.IsFilter)
                empNameWhereClause = " and EmpName = '" + Connection.SqlString(empName.Value) + "' ";
            if (period.IsFilter)
                periodWhereClause = " and Period = " + period.Value + " ";

            string query = "select Pk,EmpName,Period,Hours_SMC,Hours_Agency, " +
                                  "Discrepancy,Reg_Hours,Overtime,Locked, " +
                                  "RatePerHour,ColaPerHour,OvertimePerHour, " +
                                  "RegPaid,OvertimePaid,Cola,TotalPaid, " +
                                  "AgencyName,isnull(LastModified,'')LastModified " +
                           "from Agency_Hours_Salary " +
                           "where 1=1 " + pkWhereClause + empNameWhereClause + periodWhereClause;
            return query;
        }

        private static List<AgencyHoursSalary> GetDatas(Connection connection,string query) 
        {
            List<AgencyHoursSalary> result = new List<AgencyHoursSalary>();
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result.Add(new AgencyHoursSalary(Convert.ToInt32(d.Rows[i]["Pk"]), d.Rows[i]["EmpName"].ToString(),
                    Convert.ToInt32(d.Rows[i]["Period"]), Convert.ToDouble(d.Rows[i]["Hours_SMC"]),
                    Convert.ToDouble(d.Rows[i]["Hours_Agency"]), Convert.ToDouble(d.Rows[i]["Discrepancy"]),
                    Convert.ToDouble(d.Rows[i]["Reg_Hours"]), Convert.ToDouble(d.Rows[i]["ColaPerHour"]),
                    Convert.ToDouble(d.Rows[i]["OvertimePerHour"]), Convert.ToDouble(d.Rows[i]["RegPaid"]),
                    Convert.ToDouble(d.Rows[i]["OvertimePaid"]), Convert.ToDouble(d.Rows[i]["Cola"]),
                    Convert.ToDouble(d.Rows[i]["TotalPaid"]), d.Rows[i]["AgencyName"].ToString(),
                    d.Rows[i]["LastModified"].ToString()));
            }
            return result;
        }

        private static AgencyHoursSalary GetData(Connection connection, string query)
        {
            AgencyHoursSalary result = null;
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result = new AgencyHoursSalary(Convert.ToInt32(d.Rows[i]["Pk"]), d.Rows[i]["EmpName"].ToString(),
                    Convert.ToInt32(d.Rows[i]["Period"]), Convert.ToDouble(d.Rows[i]["Hours_SMC"]),
                    Convert.ToDouble(d.Rows[i]["Hours_Agency"]), Convert.ToDouble(d.Rows[i]["Discrepancy"]),
                    Convert.ToDouble(d.Rows[i]["Reg_Hours"]), Convert.ToDouble(d.Rows[i]["ColaPerHour"]),
                    Convert.ToDouble(d.Rows[i]["OvertimePerHour"]), Convert.ToDouble(d.Rows[i]["RegPaid"]),
                    Convert.ToDouble(d.Rows[i]["OvertimePaid"]), Convert.ToDouble(d.Rows[i]["Cola"]),
                    Convert.ToDouble(d.Rows[i]["TotalPaid"]), d.Rows[i]["AgencyName"].ToString(),
                    d.Rows[i]["LastModified"].ToString());
            }
            return result;
        }

        public static AgencyHoursSalary GetAgencyHourSalary(Connection connection,string empName,int period) 
        {
            return GetData(connection,QueryFilter(new FilterClause<int>(),
                new FilterClause<string>(empName),new FilterClause<int>(period)));
        }

        public static bool UpdateAgencySalary(Connection connection,AgencyHoursSalary agencyHourSalary) 
        {
            string query = "update Agency_Hours_Salary " +
                           "set EmpName='" + Connection.SqlString(agencyHourSalary.EmpName) + "',Period=" + 
                               agencyHourSalary.Period + ",Hours_SMC=" + agencyHourSalary.HoursSMC + ", " +
	                           "Hours_Agency=" + agencyHourSalary.HoursAgency + ",Discrepancy=" + agencyHourSalary.Descripancy + ", " +
	                           "Reg_Hours=" + agencyHourSalary.RegHours + ",Overtime=" +  agencyHourSalary.Overtime + ",Locked=" + agencyHourSalary.Locked + ", " +
	                           "RatePerHour=" + agencyHourSalary.RatePerHour + ",ColaPerHour=" + agencyHourSalary.ColaPerHour + ", " +
	                           "OvertimePerHour=" + agencyHourSalary.OvertimePerHour + ",RegPaid=" + agencyHourSalary.RegPaid + ", " +
	                           "OvertimePaid=" + agencyHourSalary.OvertimePaid + ",Cola=" + agencyHourSalary.Cola + ",TotalPaid=" + agencyHourSalary.TotalPaid + ", " +
	                           "AgencyName='" + Connection.SqlString(agencyHourSalary.AgencyName) + "',LastModified='" + Connection.SqlString(agencyHourSalary.LastModified) + "' " +
                           "where PK = " + agencyHourSalary.PK + " ";

            return connection.Execute(query);
        }

        public static bool InsertAgencySalary(Connection connection,AgencyHoursSalary agencyHourSalary) 
        {
            string query = "insert Agency_Hours_Salary values ('" + Connection.SqlString(agencyHourSalary.EmpName) + 
                           "'," + agencyHourSalary.Period + "," + agencyHourSalary.HoursSMC + "," + agencyHourSalary.HoursAgency + ", " +
	                       "" + agencyHourSalary.Descripancy + "," + agencyHourSalary.RegHours + "," + agencyHourSalary.Overtime + "," + 
                           agencyHourSalary.Locked + "," + agencyHourSalary.RatePerHour + "," + agencyHourSalary.ColaPerHour + ", " +
	                       "" + agencyHourSalary.OvertimePerHour + "," + agencyHourSalary.RegPaid + "," + agencyHourSalary.OvertimePaid + "," + 
                           agencyHourSalary.Cola + "," + agencyHourSalary.TotalPaid + ",'" + Connection.SqlString(agencyHourSalary.AgencyName) + "','" + 
                           Connection.SqlString(agencyHourSalary.LastModified) + "') ";

            return connection.Execute(query);
        }

        public static bool DeleteAgencyHourSalary(Connection connection,string empName,int period)
        {
            string query = "delete Agency_Hours_Salary " +
                           "where EmpName = '" + Connection.SqlString(empName) + "' and Period = " + period + " ";

            return connection.Execute(query);
        }

        public static AgencyHoursSalary CreateEmptyAgencyHourSalary() 
        {
            return new AgencyHoursSalary(0, string.Empty, 0, 0, 0, 0, 0, 
                0, 0, 0, 0, 0, 0, string.Empty, string.Empty);
        }
    }
}

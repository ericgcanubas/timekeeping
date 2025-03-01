using System;
using System.Collections.Generic;

namespace TimeKeepingDataCode.Biometrics
{
    public class EmployeeShifting
    {
        public int Pk { get; set; }
        public int EmpNo { get; set; }
        public string EmpId { get; set; }
        public string EmpName { get; set; }
        public DateTime EffectDate { get; set; }
        public int Sunday { get; set; }
        public int Monday { get; set; }
        public int Tuesday { get; set; }
        public int Wednesday { get; set; }
        public int Thursday { get; set; }
        public int Friday { get; set; }
        public int Saturday { get; set; }
        public int MachineId { get; set; }
        public int MachineNo { get; set; }
        public int Restday { get; set; }
        public string LastModified { get; set; }

        public EmployeeShifting(int pk,int empNo,string empId,string empName,DateTime effectDate,
            int sunday,int monday,int tuesday,int wednesday,int thursday,int friday,
            int saturday,int machineId,int machineNo,int restday,string lastModified )
        {
            this.Pk = pk;
            this.EmpNo = empNo;
            this.EmpId = empId;
            this.EmpName = empName;
            this.EffectDate = effectDate;
            this.Sunday = sunday;
            this.Monday = monday;
            this.Tuesday = tuesday;
            this.Wednesday = wednesday;
            this.Thursday = thursday;
            this.Friday = friday;
            this.Saturday = saturday;
            this.MachineId = machineId;
            this.MachineNo = machineNo;
            this.Restday = restday;
            this.LastModified = lastModified;
        }

        public override string ToString()
        {
            return string.Format("Pk={0},EmpNo={1},DateEfftect={2}",this.Pk,this.EmpNo,this.EffectDate);
        }

        public static List<EmployeeShifting> GetEmployeeShiftings(Connection connection)
        {
            return GetDatas(connection, QueryFilter(new FilterClause<int>(), new FilterClause<int>(),
                new FilterClause<bool>(),new FilterClause<DateTime>()));
        }

        public static List<EmployeeShifting> GetEmployeeShiftings(Connection connection, int empNo) 
        {
            return GetDatas(connection,QueryFilter(new FilterClause<int>(),new FilterClause<int>(empNo),
                new FilterClause<bool>(),new FilterClause<DateTime>()));
        }

        public static EmployeeShifting GetEmployeeShifting(Connection connection,int pk) 
        {
            return GetData(connection,QueryFilter(new FilterClause<int>(pk),new FilterClause<int>(),
                new FilterClause<bool>(),new FilterClause<DateTime>()));
        }

        public static EmployeeShifting GetCurrentEmployeeShifting(Connection connection, int empPk) 
        {
            return GetData(connection,QueryFilter(new FilterClause<int>(),new FilterClause<int>(empPk),
                new FilterClause<bool>(true),new FilterClause<DateTime>()));
        }

        public static EmployeeShifting GetCurrentEmployeeShifting(Connection connection, int empPk, DateTime dateEffect) 
        {
            return GetData(connection, QueryFilter(new FilterClause<int>(),
                new FilterClause<int>(empPk), new FilterClause<bool>(), new FilterClause<DateTime>(dateEffect)));
        }

        public static bool CreateEmployeeShifting(Connection connection, EmployeeShifting shifting) 
        {
            string query = "insert EmployeeShifting (EmpNo,EmpId,EmpName,EffectDate,Sunday,Monday, " +
                               "Tuesday,Wednesday,Thursday,Friday,Saturday,MachineId,MachineNo, " +
                               "Restday,LastModified) " +
                           "values (" + shifting.EmpNo + ",'" + Connection.SqlString(shifting.EmpId) + "','" + 
                                    Connection.SqlString(shifting.EmpName) + "','" + shifting.EffectDate.ToShortDateString() + "'," + 
                                    shifting.Sunday + "," + shifting.Monday + ", " + shifting.Tuesday + "," + 
                                    shifting.Wednesday + "," + shifting.Thursday + "," + shifting.Friday + "," + 
                                    shifting.Saturday + "," + shifting.MachineId + "," + shifting.MachineNo + ", " +
                                    "" + shifting.Restday + ",'" + shifting.LastModified + "' ) ";
            return connection.Execute(query);
        }

        public static bool UpdateEmployeeShifting(Connection connection,EmployeeShifting shifitng) 
        {
            string query = "update EmployeeShifting set EffectDate='" + shifitng.EffectDate.ToShortDateString() + 
                               "',Sunday=" + shifitng.Sunday + ",Monday=" + shifitng.Monday + ",Tuesday=" + 
                               shifitng.Tuesday + ",Wednesday=" + shifitng.Wednesday + ",Thursday=" + shifitng.Thursday + ", " +
	                           "Friday=" + shifitng.Friday + ",Saturday=" + shifitng.Saturday + ",MachineId=" + 
                               shifitng.MachineId + ",MachineNo=" + shifitng.MachineNo + ", " +
	                           "Restday=" + shifitng.Restday + ",LastModified='" + Connection.SqlString(shifitng.LastModified) + "' " +
                           "where Pk = " + shifitng.Pk + " ";

            return connection.Execute(query);
        }

        private static string QueryFilter(FilterClause<int> pk,FilterClause<int> empNo,
            FilterClause<bool> isFilterCurrentSchedule,FilterClause<DateTime> isFilterByParamEffectiveDate)
        {
            string pkWhereClause = string.Empty;
            string empNoWhereClause = string.Empty;
            string isFilterCurrentWhereClause = string.Empty;
            string topWhereClause = string.Empty;
            string orderByWhereClause = string.Empty;
            string effectiveDateWhereClause = string.Empty;

            if (pk.IsFilter)
                pkWhereClause = " and Pk = " + pk.Value + " ";
            if (empNo.IsFilter)
                empNoWhereClause = " and EmpNo = " + empNo.Value + " ";
            if (isFilterCurrentSchedule.IsFilter)
            {
                isFilterCurrentWhereClause = " and EffectDate <= GETDATE() ";
                topWhereClause = " top 1 ";
                orderByWhereClause = " order by EffectDate desc ";
            }

            if (isFilterByParamEffectiveDate.IsFilter) {
                isFilterCurrentWhereClause = " and EffectDate <= '" + isFilterByParamEffectiveDate.Value.ToShortDateString() + "' ";
                topWhereClause = " top 1 ";
                orderByWhereClause = " order by EffectDate desc ";
            }

            string query = "SELECT " + topWhereClause + " Pk,EmpNo,EmpId,EmpName,EffectDate,Sunday,Monday,Tuesday " +
                                 ",Wednesday,Thursday,Friday,Saturday,MachineId " +
                                 ",MachineNo,Restday,LastModified " +
                           "FROM EmployeeShifting " +
                           "where 1=1 " + empNoWhereClause + pkWhereClause + isFilterCurrentWhereClause + orderByWhereClause;
            return query;
        }

        private static List<EmployeeShifting> GetDatas(Connection connection,string query) 
        {
            List<EmployeeShifting> result = new List<EmployeeShifting>();
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result.Add(new EmployeeShifting(Convert.ToInt32(d.Rows[i]["Pk"]), Convert.ToInt32(d.Rows[i]["EmpNo"]),
                    d.Rows[i]["EmpId"].ToString(), d.Rows[i]["EmpName"].ToString(),Convert.ToDateTime(d.Rows[i]["EffectDate"]), 
                    Convert.ToInt32(d.Rows[i]["Sunday"]),Convert.ToInt32(d.Rows[i]["Monday"]),Convert.ToInt32(d.Rows[i]["Tuesday"]),
                    Convert.ToInt32(d.Rows[i]["Wednesday"]),Convert.ToInt32(d.Rows[i]["Thursday"]),Convert.ToInt32(d.Rows[i]["Friday"]),
                    Convert.ToInt32(d.Rows[i]["Saturday"]),Convert.ToInt32(d.Rows[i]["MachineId"]),Convert.ToInt32(d.Rows[i]["MachineNo"]),
                    Convert.ToInt32(d.Rows[i]["Restday"]), d.Rows[i]["LastModified"].ToString()));
            }
            return result;
        }

        private static EmployeeShifting GetData(Connection connection,string query) 
        {
            EmployeeShifting result = null;
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result = new EmployeeShifting(Convert.ToInt32(d.Rows[i]["Pk"]), Convert.ToInt32(d.Rows[i]["EmpNo"]),
                    d.Rows[i]["EmpId"].ToString(),d.Rows[i]["EmpName"].ToString(),Convert.ToDateTime(d.Rows[i]["EffectDate"]), 
                    Convert.ToInt32(d.Rows[i]["Sunday"]),Convert.ToInt32(d.Rows[i]["Monday"]), Convert.ToInt32(d.Rows[i]["Tuesday"]), 
                    Convert.ToInt32(d.Rows[i]["Wednesday"]),Convert.ToInt32(d.Rows[i]["Thursday"]), Convert.ToInt32(d.Rows[i]["Friday"]),
                    Convert.ToInt32(d.Rows[i]["Saturday"]),Convert.ToInt32(d.Rows[i]["MachineId"]), Convert.ToInt32(d.Rows[i]["MachineNo"]), 
                    Convert.ToInt32(d.Rows[i]["Restday"]),d.Rows[i]["LastModified"].ToString());
            }
            return result;
        }

        public static int GenerateRandomBioID(Connection connection) 
        {
            string query = "declare @tmpId table(Id int); " +
                           "insert @tmpId " +
                           "select a.MachineID from ( " +
	                           "select a.PkId,b.MachineID, " +
		                              "Row = ROW_NUMBER() over (partition by a.PkId order by b.EffectDate desc) " +
	                           "from ( " +
		                           "select a.PkId,a.PEmploymentStatus " +
		                           "from ( " +
			                           "select b.PK PkId,c.PEmploymentStatus, " +
				                           "Row = ROW_NUMBER() over (partition by b.Pk order by c.PEffectivityDate desc) " +
			                           "from PayrollSystem.dbo.tbl_Profile_IDNumber b " +
			                           "join PayrollSystem.dbo.tbl_Profile_Action c " +
				                           "on b.PK = c.PEmployeeNo ) a " +
		                           "left join PayrollSystem.dbo.EEmploymentStatus b " +
			                           "on a.PEmploymentStatus = b.EEmploymentStatus " +
		                           "where a.Row = 1 and b.Eactive =1 ) a " +
                               "join Biometrics.dbo.EmployeeShifting b on a.PkId = b.EmpNo ) a " +
                           "where a.Row = 1 order by a.MachineId; " +
                           "declare @id int = 100; " +
                           "while (select distinct Id from @tmpId where Id = @id) > 1 " +
	                           "begin " +
                                   "set @id = @id +1; " +
	                           "end " +
                           "select @id GeneratedId ";
            var resultData = connection.GetData(query);

            if (resultData.Rows.Count > 0)
                return Convert.ToInt32(resultData.Rows[0]["GeneratedId"]);
            else
                throw new Exception("No Bio Id Generated.");
        }

        public static bool IsRestday(Connection connection,DateTime date,int empId)
        {
            string query = "declare @date date = '" + date.ToShortDateString() + "'; " +
                           "declare @empPK int = " + empId + " " +
                           "select a.EmpNo,a.Restday " +
                           "from ( " +
                            "select a.EmpNo,isnull(b.ToDay,a.RestDay) Restday " +
                            "from ( " +
                                "select EmpNo,RestDay, " +
                                       "Row = ROW_NUMBER() over (partition by EmpNo order by PK desc) " +
                                "from EmployeeShifting " +
                                "where EmpNo = @empPK and cast(EffectDate as date) <= cast(@date as date) ) a " +
                            "left join (select EmpPK = case when EmpPK = @empPK " +
		                                                      "then @empPK else EmpPKWith end, " +
                                           "dReqDateFrom,dReqDateTo, " +
                                           "FromDay = case when EmpPK = @empPK " +
	                                                      "then " +
		                                                      "case when DATEPART(W,dReqDateFrom) = 1 " +
			                                                      "then 7 else (DATEPART(W,dReqDateFrom) - 1) end " +
	                                                      "else " +
		                                                      "case when DATEPART(W,dExDateFrom) = 1 " +
			                                                      "then 7 else (DATEPART(W,dExDateFrom) - 1) end " +
                                                      "end, " +
                                           "ToDay = case when EmpPK = @empPK " +
                                                       "then " +
	                                                      "case when DATEPART(W,dReqDateTo) = 1 " +
		                                                      "then 7 else (DATEPART(W,dReqDateTo) -1) end " +
                                                       "else " +
	                                                      "case when DATEPART(W,dReqDateTo) = 1 " +
		                                                      "then 7 else (DATEPART(W,dExDateTo) -1) end " +
                                                   "end " +
                                      "from tbl_CHANGERESTDAY " +
                                      "where (cast(dReqDateTo as date) = cast(@date as date) " +
                                      "or cast(dReqDateFrom as date) = cast(@date as date)) " +
                                      "and nPosted = 1 and nCancelled = 0 and (EmpPK = @empPK or EmpPKWith = @empPK)) b " +
                            "on a.EmpNo = b.EmpPK " +
                            "where a.Row = 1 ) a  " +
                           "where a.Restday = case when DATEPART(W,cast(@date as date)) = 1 " +
                                           "then 7 else (DATEPART(W,cast(@date as date)) - 1) end ";
            if (connection.GetData(query).Rows.Count > 0)
                return true;
            else
                return false;
        }

        public static bool DeleteShifting(Connection connection,EmployeeShifting shifting) 
        {
            string query = "delete EmployeeShifting where Pk =" + shifting.Pk;

            return connection.Execute(query);
        }

        public static List<int> GetRestdaysEmpId(Connection connection,DateTime date) 
        {
            string query = "declare @dateEffect date = '" + date + "'; " +
                           "select a.PK,isnull(b.ToDay,a.RestDay) Restday " +
                           "from ( " +
	                           "/** normal restday **/ " +
	                           "select a.PK,a.RestDay " +
	                           "from ( " +
		                           "select a.PK,c.RestDay, " +
			                              "Row= ROW_NUMBER() over (partition by a.Pk order by c.EffectDate desc) " +
		                           "from ( " +
			                           "select b.PK,c.PEmploymentStatus, " +
				                           "Row = ROW_NUMBER() over (partition by b.Pk order by c.PEffectivityDate desc) " +
			                           "from PayrollSystem.dbo.tbl_Profile_IDNumber b " +
			                           "join PayrollSystem.dbo.tbl_Profile_Action c " +
				                           "on b.PK = c.PEmployeeNo ) a " +
		                           "left join PayrollSystem.dbo.EEmploymentStatus b " +
			                           "on a.PEmploymentStatus = b.EEmploymentStatus " +
		                           "join Biometrics.dbo.EmployeeShifting c " +
			                           "on a.PK = c.EmpNo " +
		                           "where a.Row = 1 and b.Eactive = 1 " +
		                           "and cast(c.EffectDate as date) <= @dateEffect ) a " +
	                           "where a.Row = 1 and a.RestDay = " +
	                           "(case when (DATEPART(DW,@dateEffect) - 1) = 0 then 7 else (DATEPART(DW,@dateEffect) - 1) end)  ) a " +
                           "left join ( " +
	                           "/**change shift**/ " +
	                           "select dReqDateFrom,dReqDateTo,EmpPK, " +
		                           "FromDay = case when DATEPART(W,dReqDateFrom) = 1 " +
						                              "then 7 else (DATEPART(W,dReqDateFrom) - 1) end, " +
		                           "ToDay = case when DATEPART(W,dReqDateTo) = 1 " +
						                              "then 7 else (DATEPART(W,dReqDateTo) -1) end " +
	                           "from tbl_CHANGERESTDAY " +
	                           "where cast(dReqDateTo as date) = cast(@dateEffect as date) " +
	                           "and nPosted = 1 and nCancelled = 0 " +
	                           "union all " +
	                           "select dReqDateFrom,dReqDateTo,EmpPKWith, " +
		                           "FromDay = case when DATEPART(W,dExDateFrom) = 1 " +
						                              "then 7 else (DATEPART(W,dExDateFrom) - 1) end, " +
		                           "ToDay = case when DATEPART(W,dExDateTo) = 1 " +
						                              "then 7 else (DATEPART(W,dExDateTo) -1) end " +
	                           "from tbl_CHANGERESTDAY " +
	                           "where cast(dReqDateFrom as date) = cast(@dateEffect as date) " +
	                           "and nPosted = 1 and nCancelled = 0 and EmpPKWith != 0 " +
                           ") b on a.PK = b.EmpPK ";

            List<int> empIds = new List<int>();
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                empIds.Add(Convert.ToInt32(d.Rows[i]["PK"]));
            }
            return empIds;
        }
    }
}

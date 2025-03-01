using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeKeepingDataCode.Biometrics
{
    public class AttendanceEmployee 
    {
        public string Area { get; private set; }
        public string Department { get; private set; }
        public string Section { get; private set; }
        public string Position { get; private set; }
        public int AreaID { get; private set; }
        public int DepartmentNo { get; private set; }
        public int SectionID { get; private set; }
        public int PositionID { get; private set; }
        public string DescriptionType { get; private set; }
        public string Effectivity { get; private set; }
        public string Reason { get; private set; }
        public string ApprovedBy { get; private set; }
        public string Remarks { get; private set; }

        public int EmpPk { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Initial { get; set; }

        public override string ToString()
        {
            return this.Lastname + ", " + this.Firstname + " " + this.Initial;
        }

        public AttendanceEmployee(string area,string department,string section,string position,
            int areaId,int departmentNo,int sectionId,int positionId,string descriptionType,
            string effectivity,string reason,string approvedBy,string remarks,
            int empPk,string lastname,string firstname,string initial)
        {
            this.Area = area;
            this.Department = department;
            this.Section = section;
            this.Position = position;
            this.AreaID = areaId;
            this.DepartmentNo = departmentNo;
            this.SectionID = sectionId;
            this.PositionID = positionId;
            this.DescriptionType = descriptionType;
            this.Effectivity = effectivity;
            this.Reason = reason;
            this.ApprovedBy = approvedBy;
            this.Remarks = remarks;
            this.EmpPk = empPk;
            this.Lastname = lastname;
            this.Firstname = firstname;
            this.Initial = initial;
        }

        public static List<AttendanceEmployee> GetAttendanceEmployees(Connection connection,DateTime date) 
        {
            return AttendanceResult(connection, FilterQuery(date, 0, 0, 0, 0));
        }

        public static List<AttendanceEmployee> GetAttendanceEmployees(Connection connection,DateTime date,
            int areaId,int departmentId,int sectionId,int positionId) 
        {
            return AttendanceResult(connection, FilterQuery(date, areaId,departmentId,sectionId,positionId));
        }

        private static string FilterQuery(DateTime date,int areaId,int departmentId,int sectionId,int positionId) 
        {
            string areaIdWhereClause = string.Empty;
            string departmentIdWhereClause = string.Empty;
            string sectionIdWhereClause = string.Empty;
            string positionIdWhereClause = string.Empty;

            if (areaId != 0)
                areaIdWhereClause = " and a.AreaId =" + areaId + " ";
            if (departmentId != 0)
                departmentIdWhereClause = " and a.DDepartmentsNo =" + departmentId + " ";
            if (sectionId != 0)
                sectionIdWhereClause = " and and a.SSectionID =" + sectionId + " ";
            if (positionId != 0)
                positionIdWhereClause = " and a.PositionId =" + positionId + " ";

            StringBuilder sb = new StringBuilder();
            sb.Append("declare @date date =  '" +  date + "' ");
            sb.Append("declare @date2 date = DATEADD(D,-1,@date) ");
            sb.Append("declare @date3 date = DATEADD(D,-2,@date) ");

            sb.Append("declare @leaveDateEffects varchar(50) ");
            sb.Append("declare @leaveDateEffects2 varchar(50) ");
            sb.Append("declare @leaveDateEffects3 varchar(50) ");

            sb.Append("set @leaveDateEffects = case when LEN(MONTH(@date)) = 1 " +
								"then '0' + cast(MONTH(@date) as varchar(2)) else cast(MONTH(@date) as varchar(2)) end; ");
            sb.Append("set @leaveDateEffects = @leaveDateEffects + '/' + case when LEN(DAY(@date)) = 1 " +
								"then '0' + CAST(DAY(@date) as varchar(2)) else CAST(DAY(@date) as varchar(2)) end; ");
            sb.Append("set @leaveDateEffects = @leaveDateEffects + '/' + CAST(YEAR(@date) as varchar(4)) ");

            sb.Append("set @leaveDateEffects2 = case when LEN(MONTH(@date2)) = 1  " +
								"then '0' + cast(MONTH(@date2) as varchar(2)) else cast(MONTH(@date2) as varchar(2)) end; " );
            sb.Append("set @leaveDateEffects2 = @leaveDateEffects + '/' + case when LEN(DAY(@date2)) = 1 " +
								"then '0' + CAST(DAY(@date2) as varchar(2)) else CAST(DAY(@date2) as varchar(2)) end; ");
            sb.Append("set @leaveDateEffects2 = @leaveDateEffects + '/' + CAST(YEAR(@date2) as varchar(4)) ");

            sb.Append("set @leaveDateEffects3 = case when LEN(MONTH(@date3)) = 1 " +
								"then '0' + cast(MONTH(@date3) as varchar(2)) else cast(MONTH(@date3) as varchar(2)) end; ");
            sb.Append("set @leaveDateEffects3 = @leaveDateEffects + '/' + case when LEN(DAY(@date3)) = 1 " +
								"then '0' + CAST(DAY(@date3) as varchar(2)) else CAST(DAY(@date3) as varchar(2)) end; ");
            sb.Append("set @leaveDateEffects3 = @leaveDateEffects + '/' + CAST(YEAR(@date3) as varchar(4)) ");

            sb.Append("select * " +
                      "from ( " +
                      "select a.*, " +
	                         "DescType = case when h.EmpPK is null then 'Awol' " +
					                      "else case when f.EmpNo is not null " +
								                      "then 'Suspension' " +
							                        "when i.EmpPK is null then 'Absent' " +
							                        "when e.EmpId is not null then 'Holiday' " +
							                        "when g.EmpNo is not null then 'Restday' " +
							                        "when b.EmpPK is not null then 'Leave' " +
							                        "when c.EmpPK is not null then 'Undertime' " +
 							                        "when d.EmpPK is not null then 'Late' " +
							                        "else 'Present' " +
						                       "end " +
				                        "end, " +
		                     "Effectivity = case when h.EmpPK is null then '' " +
					                      "else case when f.EmpNo is not null " +
								                      "then cast(Month(f.DateFrom) as varchar(2)) + '/' + " +
									                      "cast(DAY(f.DateFrom) as varchar(2)) + '/' + cast(YEAR(f.DateFrom) as varchar(4)) " +
							                        "when i.EmpPK is null then '' " +
							                        "when e.EmpId is not null then cast(Month(e.HolidayDate) as varchar(2)) + '/' + " +
									                      "cast(DAY(e.HolidayDate) as varchar(2)) + '/' + cast(YEAR(e.HolidayDate) as varchar(4)) " +
							                        "when g.EmpNo is not null then '' " +
							                        "when b.EmpPK is not null then cast(Month(b.dEffectDate) as varchar(2)) + '/' +  " +
									                      "cast(DAY(b.dEffectDate) as varchar(2)) + '/' + cast(YEAR(b.dEffectDate) as varchar(4)) " +
							                        "when c.EmpPK is not null then cast(Month(c.dEffectDate) as varchar(2)) + '/' +  " +
									                      "cast(DAY(c.dEffectDate) as varchar(2)) + '/' + cast(YEAR(c.dEffectDate) as varchar(4)) " +
                                                    "when d.EmpPK is not null then cast(Month(d.Actual_Time_In) as varchar(2)) + '/' + " +
									                      "cast(DAY(d.Actual_Time_In) as varchar(2)) + '/' + cast(YEAR(d.Actual_Time_In) as varchar(4)) + " +
									                      "' ' + Right('0' + cast(DatePart(HH,d.Actual_Time_In) as varchar(2)),2) + ':' + Right('0' + " +
									                      "cast(DatePart(N,d.Actual_Time_In) as varchar(2)),2) + ' - ' + cast(Month(d.Shift_Time_In) as varchar(2)) + '/' + " +
									                      "cast(DAY(d.Shift_Time_In) as varchar(2)) + '/' + cast(YEAR(d.Shift_Time_In) as varchar(4)) +  " +
									                      "' ' + Right('0' + cast(DatePart(HH,d.Shift_Time_In) as varchar(2)),2) + ':' + Right('0' +  " +
									                      "cast(DatePart(N,d.Shift_Time_In) as varchar(2)),2)" +
							                        "else '' " +
						                       "end " +
				                        "end, " +
		                     "Reason = case when h.EmpPK is null then '' " +
					                      "else case when f.EmpNo is not null " +
								                      "then '' " +
							                        "when i.EmpPK is null then '' " +
							                        "when e.EmpId is not null then e.HolidayName " +
							                        "when g.EmpNo is not null then '' " +
							                        "when b.EmpPK is not null then b.sReason "+
							                        "when c.EmpPK is not null then c.sReason " +
							                        "when d.EmpPK is not null then '' " +
							                        "else '' " +
						                       "end " +
				                        "end, " +
		                     "ApprovedBy = case when h.EmpPK is null then '' " +
					                      "else case when f.EmpNo is not null " +
								                      "then '' " +
							                        "when i.EmpPK is null then '' " +
							                        "when e.EmpId is not null then '' " +
							                        "when g.EmpNo is not null then '' " +
							                        "when b.EmpPK is not null then b.sApprovedBy " +
							                        "when c.EmpPK is not null then c.sApprovedBy " +
							                        "when d.EmpPK is not null then '' " +
							                        "else '' " +
						                       "end " +
				                        "end, " +
		                     "Remarks = case when h.EmpPK is null then '' " +
					                      "else case when f.EmpNo is not null " + 
								                      "then f.Remarks " +
							                        "when i.EmpPK is null then '' " +
							                        "when e.EmpId is not null then '' " +
							                        "when g.EmpNo is not null then '' " +
							                        "when b.EmpPK is not null then b.sNoOfDaysMin " +
							                        "when c.EmpPK is not null then c.sNoOfDaysMin " +
							                        "when d.EmpPK is not null then d.Remarks " +
							                        "else '' " +
						                       "end " +
				                        "end " +
                      "from ( " +
	                        "select a.PK,a.ELastName Lastname,a.EFirstName Firstname,a.EMiddleName Initial, " +
			                         "isnull(a.PPositionName,'') Position,  " +
			                         "isnull(a.Description,'') Area,isnull(a.DDepartment,'') Department, " +
			                         "isnull(a.DDepartmentsNo,0) DpartNo,isnull(a.SSectionID,0)SSectionID,isnull(a.SSectionName,'') Section, " +
			                         "a.AreaId,a.PositionId " +
	                       "from ( " +
	                          "/** Current basic information sa Employees **/ " +
	                          "select a.PK,a.ELastName,a.EFirstName,a.EMiddleName,a.EEmployeeIDNo,b.PPamTransactionNo, " +
			                         "b.PEffectivityDate,isnull(d.EActive,0)EActive,e.PPositionName,  " +
			                         "f.Description,g.DDepartment,g.DDepartmentsNo,h.SSectionID,  " +
			                         "h.SSectionName,f.PK AreaId,e.PPositionIDNo PositionId, " +
			                         "Row = ROW_NUMBER() over (partition by a.pk order by b.PEffectivityDate desc) " +
	                          "from PayrollSystem.dbo.tbl_Profile_IDNumber a  " +
	                          "join PayrollSystem.dbo.tbl_Profile_Action b on a.PK = b.PEmployeeNo " +
	                          "left join PayrollSystem.dbo.EEmploymentStatus d on b.PEmploymentStatus = d.EEmploymentStatus " +
	                          "left join PayrollSystem.dbo.PPositionName e on b.PPosition = e.PPositionIDNo  " +
	                          "left join PayrollSystem.dbo.EEmployeeDiv f on b.PDiv = f.PK  " +
	                          "left join PayrollSystem.dbo.DDepartmental g on b.PDept = g.DDepartmentsNo " +
	                          "left join PayrollSystem.dbo.SSection h on b.PSection = h.SSectionID " +
	                          "left join PayrollSystem.dbo.EmployeeWithOutBio i on a.PK = i.EmpNo " +
			                       "and cast(i.EffectDate as date) <= @date " +
	                          "where i.EmpNo is null) a " +
	                       "/** wala nko gi apil ang mga uban tao **/ " +
	                       "where a.Row = 1 and a.EActive = 1 and a.PositionId != 107  " +
                           "and a.PositionId != 106 and a.PK not in(289,749) " +
		                       "" + areaIdWhereClause + departmentIdWhereClause + sectionIdWhereClause + positionIdWhereClause + " ) a " +
                       "/** Leave Employees **/ " +
                       "left join Biometrics.dbo.tbl_LEAVE_UNDERTIME b " +
	                       "on a.PK = b.EmpPK and b.EffectDates like '%' + @leaveDateEffects + '%' " +
	                       "and b.nPosted = 1 and b.nCancelled != 1 and nType = 1 " +
                       "/** Undertime Employees **/ " +
                       "left join Biometrics.dbo.tbl_LEAVE_UNDERTIME c " +
	                       "on a.PK = c.EmpPK and cast(c.dEffectDate as date) = CAST(@date as date) " +
	                       "and c.nPosted = 1 and c.nCancelled != 1 and c.nType = 2 " +
                       "/** Late Employees **/ " +
                       "left join (select EmpPk,Remarks,Actual_Time_In,Shift_Time_In  from ( " +
				                       "select EmployeeKey EmpPk,Remarks,Actual_Time_In,Shift_Time_In, " +
					                          "Row = Row_Number() over (partition by EmployeeKey order by line) " +
				                       "from tbl_TimeRecord_Detail " +
				                       "where cast(Actual_Date as date) = @date) a " +
			                       "where a.Row = 1 and (cast(cast(Actual_Time_In as varchar(20)) as datetime) > " +
                                      "cast(cast(Shift_Time_In as varchar(20)) as datetime) or Actual_Time_In is null) ) d on a.PK = d.EmpPk " +
                       "/** Holiday Employees **/ " +
                       "left join (select distinct a.HolidayDate,b.EmpId,b.IsHolidayDuty,a.HolidayName " +
			                       "from Biometrics.dbo.tbl_HolidayName a " +
			                       "join Biometrics.dbo.tbl_HolidayEmployees b " +
				                       "on a.HolidayNamePk = b.HolidayNamePk) e " +
	                       "on a.PK = e.EmpId and e.IsHolidayDuty = 0 and e.HolidayDate = CAST(@date as date) " +
                       "/** Suspension Employees **/ " +
                       "left join Biometrics.dbo.Suspension f " +
	                       "on a.PK = f.EmpNo and cast(f.DDate as date) = cast(@date as date) " +
                       "/** Restday Employees **/ " +
                       "left join(select a.EmpNo " +
			                       "from (  " +
			                         "select a.EmpNo,a.RestDay,b.EmpPk " +
			                         "from (  " +
				                         "select EmpNo,RestDay, " +
						                        "Row = ROW_NUMBER() over (partition by EmpNo order by PK desc) " +
				                         "from Biometrics.dbo.EmployeeShifting " +
				                         "where cast(EffectDate as date) <= cast(@date as date) ) a " +
			                         "left join (select EmpPk = case when (a.EmpPKWith is not null or a.EmpPKWith != 0) and " +
												                       "cast(dExDateTo as date)= @date " +
													                       "then a.EmpPKWith else a.EmpPK end " +
						                       "from Biometrics.dbo.tbl_CHANGERESTDAY a " +
						                       "where (cast(dReqDateTo as date) = @date " +
							                       "or cast(dExDateTo as date) = @date) " +
							                       "and nPosted = 1 and nCancelled = 0) b " +
			                         "on a.EmpNo = b.EmpPK " +
			                         "where a.Row = 1 ) a  " +
			                         "where EmpPK is not null or (a.Restday = case when DATEPART(W,cast(@date as date)) = 1 " +
							                        "then 7 else (DATEPART(W,cast(@date as date)) - 1) end )) g " +
	                       "on a.PK = g.EmpNo " +
                       "/** Awol Employees **/ " +
                       "left join (select a.EmpPK " +
			                       "from ( " +
				                       "/** 1st day attendance **/ " +
				                       "select distinct a.EmpPK " +
				                       "from ( " +
					                       "select distinct a.EmpPK " +
					                       "from Biometrics.dbo.tbl_TransactionLog a /** Bio Record **/ " +
					                       "where cast(a.Actual_Date as date) = @date " +
					                       "union " +
					                       "select distinct a.EmpPK " +
					                       "from Biometrics.dbo.tbl_LEAVE_UNDERTIME a /** Leave **/ " +
					                       "where a.nType = 1 and a.EffectDates like '%' + @leaveDateEffects + '%'  " +
						                       "and a.nPosted = 1 and a.nCancelled != 1 " +
					                       "union  " +
					                       "select distinct b.EmpId " +
					                       "from Biometrics.dbo.tbl_HolidayName a /** Holiday **/ " +
					                       "join Biometrics.dbo.tbl_HolidayEmployees b " +
						                       "on a.HolidayNamePk = b.HolidayNamePk " +
					                       "where a.HolidayDate = @date and b.IsHolidayDuty = 0 " +
					                       "/**	gi comment nko kay wala gipa apil sa awol ang restday " +
					                       "union " +
					                       "select distinct a.EmpNo " +
					                       "from ( " + 
					                         "select a.EmpNo,a.RestDay,b.EmpPk " +
					                         "from (  " +
						                         "select EmpNo,RestDay, " +
								                        "Row = ROW_NUMBER() over (partition by EmpNo order by PK desc) " +
						                         "from Biometrics.dbo.EmployeeShifting " +
						                         "where cast(EffectDate as date) <= cast(@date as date) ) a " +
					                         "left join (select EmpPk = case when (a.EmpPKWith is not null or a.EmpPKWith != 0) and " +
														                       "cast(dExDateTo as date)= @date " +
															                       "then a.EmpPKWith else a.EmpPK end " +
								                       "from Biometrics.dbo.tbl_CHANGERESTDAY a " +
								                       "where (cast(dReqDateTo as date) = @date " +
									                       "or cast(dExDateTo as date) = @date) " +
									                       "and nPosted = 1 and nCancelled = 0) b " + 
					                         "on a.EmpNo = b.EmpPK " +
					                         "where a.Row = 1 ) a " +
					                         "where EmpPK is not null or (a.Restday = case when DATEPART(W,cast(@date as date)) = 1 " +
									                        "then 7 else (DATEPART(W,cast(@date as date)) - 1) end ) **/ " +
					                       "union " +
					                       "select a.EmpPK " +
					                       "from Biometrics.dbo.tbl_PRW_NEW a /** PRW **/ " +
					                       "where a.nPosted = 1 and cast(a.dTransDate as date) = @date ) a " +
				                       "union " +
				                       "/** 2nd Day attendance **/ " +
				                       "select distinct a.EmpPK " +
				                       "from ( " +
					                       "select distinct a.EmpPK " +
					                       "from Biometrics.dbo.tbl_TransactionLog a /** Bio Record **/ " +
					                       "where cast(a.Actual_Date as date) = @date2 " +
					                       "union " +
					                       "select distinct a.EmpPK " +
					                       "from Biometrics.dbo.tbl_LEAVE_UNDERTIME a /** Leave **/ " +
					                       "where a.nType = 1 and a.EffectDates like '%' + @leaveDateEffects2 + '%' " +
						                       "and a.nPosted = 1 and a.nCancelled != 1 " +
					                       "union  " +
					                       "select distinct b.EmpId " +
					                       "from Biometrics.dbo.tbl_HolidayName a /** Holiday **/ " +
					                       "join Biometrics.dbo.tbl_HolidayEmployees b " +
						                       "on a.HolidayNamePk = b.HolidayNamePk " +
					                       "where a.HolidayDate = @date2 and b.IsHolidayDuty = 0 " +
					                       "/** gi comment nko kay wala gipa apil ang restday sa awol " +
					                       "union " +
					                       "select distinct a.EmpNo " +
					                       "from ( " +
					                         "select a.EmpNo,a.RestDay,b.EmpPk " +
					                         "from ( " +
						                         "select EmpNo,RestDay, " +
								                        "Row = ROW_NUMBER() over (partition by EmpNo order by PK desc) " +
						                         "from Biometrics.dbo.EmployeeShifting " +
						                         "where cast(EffectDate as date) <= cast(@date2 as date) ) a " +
					                         "left join (select EmpPk = case when (a.EmpPKWith is not null or a.EmpPKWith != 0) and " +
														                       "cast(dExDateTo as date)= @date2 " +
															                       "then a.EmpPKWith else a.EmpPK end " +
								                       "from Biometrics.dbo.tbl_CHANGERESTDAY a " +
								                       "where (cast(dReqDateTo as date) = @date2 " +
									                       "or cast(dExDateTo as date) = @date2) " +
									                       "and nPosted = 1 and nCancelled = 0) b " +
					                         "on a.EmpNo = b.EmpPK " +
					                         "where a.Row = 1 ) a  " +
					                         "where EmpPK is not null or (a.Restday = case when DATEPART(W,cast(@date2 as date)) = 1 " +
									                        "then 7 else (DATEPART(W,cast(@date2 as date)) - 1) end ) **/ " +
					                       "union " +
					                       "select a.EmpPK " +
					                       "from Biometrics.dbo.tbl_PRW_NEW a " +
					                       "where a.nPosted = 1 and cast(a.dTransDate as date) = @date2 ) a " +
				                       "union " +
				                       "/** 3rd Day Attendance **/ " +
				                       "select distinct a.EmpPK " +
				                       "from ( " +
					                       "select distinct a.EmpPK " +
					                       "from Biometrics.dbo.tbl_TransactionLog a /** Bio Record **/ " +
					                       "where cast(a.Actual_Date as date) = @date3 " +
					                       "union " +
					                       "select distinct a.EmpPK " +
					                       "from Biometrics.dbo.tbl_LEAVE_UNDERTIME a /** Leave **/ " +
					                       "where a.nType = 1 and a.EffectDates like '%' + @leaveDateEffects3 + '%' " +
						                       "and a.nPosted = 1 and a.nCancelled != 1 " +
					                       "union " +
					                       "select distinct b.EmpId " +
					                       "from Biometrics.dbo.tbl_HolidayName a /** Holiday **/ " +
					                       "join Biometrics.dbo.tbl_HolidayEmployees b " +
						                       "on a.HolidayNamePk = b.HolidayNamePk " +
					                       "where a.HolidayDate = @date3 and b.IsHolidayDuty = 0 " +
					                       "/** gi comment nko kay wala gipa apil ang restday sa awol " +
					                       "union " +
					                       "select distinct a.EmpNo " +
					                       "from ( " +
					                         "select a.EmpNo,a.RestDay,b.EmpPk " +
					                         "from ( " +
						                         "select EmpNo,RestDay, " +
								                        "Row = ROW_NUMBER() over (partition by EmpNo order by PK desc) " +
						                         "from Biometrics.dbo.EmployeeShifting " +
						                         "where cast(EffectDate as date) <= cast(@date3 as date) ) a " +
					                         "left join (select EmpPk = case when (a.EmpPKWith is not null or a.EmpPKWith != 0) and " +
														                       "cast(dExDateTo as date)= @date3 " +
															                       "then a.EmpPKWith else a.EmpPK end " +
								                       "from Biometrics.dbo.tbl_CHANGERESTDAY a " +
								                       "where (cast(dReqDateTo as date) = @date3 " +
									                       "or cast(dExDateTo as date) = @date3) " +
									                       "and nPosted = 1 and nCancelled = 0) b " +
					                         "on a.EmpNo = b.EmpPK " +
					                         "where a.Row = 1 ) a  " +
					                         "where EmpPK is not null or (a.Restday = case when DATEPART(W,cast(@date3 as date)) = 1 " +
									                        "then 7 else (DATEPART(W,cast(@date3 as date)) - 1) end ) **/ " +
					                       "union " +
					                       "select a.EmpPK " +
					                       "from Biometrics.dbo.tbl_PRW_NEW a /** PRW **/ " +
					                       "where a.nPosted = 1 and cast(a.dTransDate as date) = @date3 ) a ) a ) h " +
	                       "on a.PK = h.EmpPK " +
                       "/** Absent Employees **/ " +
                       "left join (select distinct a.EmpPK " +
			                       "from ( " +
				                       "select distinct a.EmpPK " +
				                       "from Biometrics.dbo.tbl_TransactionLog a /** Bio Record **/ " +
				                       "where cast(a.Actual_Date as date) = @date " +
				                       "union " +
				                       "select distinct a.EmpPK " +
				                       "from Biometrics.dbo.tbl_LEAVE_UNDERTIME a /** Leave **/ " +
				                       "where a.nType = 1 and a.EffectDates like '%' + @leaveDateEffects + '%' " +
					                       "and a.nPosted = 1 and a.nCancelled != 1 " +
				                       "union " +
				                       "select distinct a.EmpPK " +
				                       "from Biometrics.dbo.tbl_LEAVE_UNDERTIME a /** Undertime **/ " +
				                       "where cast(a.dEffectDate as date) = CAST(@date as date) " +
					                       "and a.nPosted = 1 and a.nCancelled != 1 and a.nType = 2 " +
				                       "union  " +
				                       "select distinct b.EmpId " +
				                       "from Biometrics.dbo.tbl_HolidayName a /** Holiday **/ " +
				                       "join Biometrics.dbo.tbl_HolidayEmployees b " +
					                       "on a.HolidayNamePk = b.HolidayNamePk " +
				                       "where a.HolidayDate = @date and b.IsHolidayDuty = 0 " +
				                       "union " +
				                       "select distinct a.EmpNo " +
				                       "from (  " +
				                         "select a.EmpNo,a.RestDay,b.EmpPk " +
				                         "from ( " +
					                         "select EmpNo,RestDay, " +
							                        "Row = ROW_NUMBER() over (partition by EmpNo order by PK desc) " +
					                         "from Biometrics.dbo.EmployeeShifting " +
					                         "where cast(EffectDate as date) <= cast(@date as date) ) a " +
				                         "left join (select EmpPk = case when (a.EmpPKWith is not null or a.EmpPKWith != 0) and " +
													                       "cast(dExDateTo as date)= @date " +
														                       "then a.EmpPKWith else a.EmpPK end " +
							                       "from Biometrics.dbo.tbl_CHANGERESTDAY a " +
							                       "where (cast(dReqDateTo as date) = @date " +
								                       "or cast(dExDateTo as date) = @date) " +
								                       "and nPosted = 1 and nCancelled = 0) b  " +
				                         "on a.EmpNo = b.EmpPK " +
				                         "where a.Row = 1 ) a  " +
				                         "where EmpPK is not null or (a.Restday = case when DATEPART(W,cast(@date as date)) = 1 " +
								                        "then 7 else (DATEPART(W,cast(@date as date)) - 1) end ) " +
				                       "union " +
				                       "select a.EmpPK " +
				                       "from Biometrics.dbo.tbl_PRW_NEW a " +
				                       "where a.nPosted = 1 and cast(a.dTransDate as date) = @date ) a) i " +
	                       "on a.PK = i.EmpPK ) a " +
                       "order by a.DescType,a.AreaId,a.DpartNo,a.SSectionID,a.PositionId");
            return sb.ToString();
        }

        private static List<AttendanceEmployee> AttendanceResult(Connection connection,string query) 
        {
            List<AttendanceEmployee> result = new List<AttendanceEmployee>();
            var resultData = connection.GetData(query);

            for (int i = 0; i < resultData.Rows.Count; i++)
            {
                result.Add(new AttendanceEmployee(resultData.Rows[i]["Area"].ToString(), resultData.Rows[i]["Department"].ToString(),
                    resultData.Rows[i]["Section"].ToString(), resultData.Rows[i]["Position"].ToString(),
                    Convert.ToInt32(resultData.Rows[i]["AreaId"]), Convert.ToInt32(resultData.Rows[i]["DpartNo"]),
                    Convert.ToInt32(resultData.Rows[i]["SSectionID"]), Convert.ToInt32(resultData.Rows[i]["PositionId"]),
                    resultData.Rows[i]["DescType"].ToString(), resultData.Rows[i]["Effectivity"].ToString(),
                    resultData.Rows[i]["Reason"].ToString(), resultData.Rows[i]["ApprovedBy"].ToString(),
                    resultData.Rows[i]["Remarks"].ToString(), Convert.ToInt32(resultData.Rows[i]["PK"]),
                    resultData.Rows[i]["Lastname"].ToString(), resultData.Rows[i]["Firstname"].ToString(),
                    resultData.Rows[i]["Initial"].ToString()));
            }

            return result;
        }

        public static System.Data.DataTable NotEightHours(Connection connection,DateTime date) 
        {
            string query = "declare @date date = '" + date.ToShortDateString() + "'; " + 
                           "select a.Name,a.Area,a.DDepartment Department, " +
	                              "a.SSectionName Section,a.PPositionName Position, " +
	                              "TotalLate = cast(cast(abs(a.TotalLate) as int) as varchar(2)) + " +
			                           "' hr/s and ' + cast(cast((abs(a.TotalLate) - CAST(abs(a.TotalLate) as int)) * 60 as int) as varchar(2)) + ' min/s', " +
	                              "TotalUndertime = cast(cast(abs(a.TotalUndertime) as int) as varchar(2)) +  " +
			                           "' hr/s and ' + cast(cast((abs(a.TotalUndertime) - CAST(abs(a.TotalUndertime) as int)) * 60 as int) as varchar(2)) + ' min/s', " +
	                              "a.AdjustmentCtrl, " +
	                              "AdjustedTime = cast(cast(abs(a.AdjustedTime) as int) as varchar(2)) +  " +
			                           "' hr/s and ' + cast(cast((abs(a.AdjustedTime) - CAST(abs(a.AdjustedTime) as int)) * 60 as int) as varchar(2)) + ' min/s', " +
	                              "NetHours = cast(cast(abs(a.NetHours) as int) as varchar(2)) +  " +
			                           "' hr/s and ' + cast(cast((abs(a.NetHours) - CAST(abs(a.NetHours) as int)) * 60 as int) as varchar(2)) + ' min/s' " +
                           "from ( " +
                           "select b.ELastName + ', ' + b.EFirstName + ' ' +  b.EMiddleName Name,a.EmployeeKey, " +
	                              "d.EActive,e.PPositionName,f.Description Area,isnull(g.DDepartment,'')DDepartment, " +
	                              "g.DDepartmentsNo,h.SSectionName,h.SSectionID, " +
	                              "f.PK AreaId,e.PPositionIDNo, " +
	                              "a.TotalHours,a.TotalLate,a.TotalUndertime, " +
	                              "a.AdjustedTime,a.AdjustmentCtrl,a.NetHours, " +
	                              "Row = ROW_NUMBER() over (partition by b.pk order by c.PEffectivityDate desc) " +
                           "from Biometrics.dbo.tbl_TimeRecord a " +
                           "join PayrollSystem.dbo.tbl_Profile_IDNumber b on a.EmployeeKey = b.PK " +
                           "join PayrollSystem.dbo.tbl_Profile_Action c on b.PK = c.PEmployeeNo " +
                           "left join PayrollSystem.dbo.EEmploymentStatus d on c.PEmploymentStatus = d.EEmploymentStatus " +
                           "left join PayrollSystem.dbo.PPositionName e on c.PPosition = e.PPositionIDNo " +
                           "left join PayrollSystem.dbo.EEmployeeDiv f on c.PDiv = f.PK " +
                           "left join PayrollSystem.dbo.DDepartmental g on c.PDept = g.DDepartmentsNo " +
                           "left join PayrollSystem.dbo.SSection h on c.PSection = h.SSectionID " +
                           "left join PayrollSystem.dbo.EmployeeWithOutBio i on b.PK = i.EmpNo " +
                           "where a.Actual_Date = @date and NetHours < 8 and i.EmpNo is null and  " +
	                           "cast(c.PEffectivityDate as date) <= @date) a " +
                           "where a.Row = 1 and a.EActive = 1 " +
                           "order by a.AreaId,a.DDepartmentsNo,a.SSectionID,a.PPositionIDNo ";

            return connection.GetData(query);
        }
    }
}

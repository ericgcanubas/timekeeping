using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeKeepingDataCode.PayrollSystem
{
    public class Position
    {
        public int Id { get; set; }
        public string PositionName { get; set; }
        public int Classify { get; set; }
        public int Level { get; set; }
        public int LevelSort { get; set; }
        public int Classification { get; set; }
        public int DirectToPAMPayroll { get; set; }
        public int WithGovernmentBenefits { get; set; }
        public int PayrollClassification { get; set; }
        public int ClassStoreBack { get; set; }
        public int Update2Bio { get; set; }
        public string PositionCode { get; set; }
        public int DepartmentId { get; set; }
        public int SectionId { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime LastUpdated { get; set; }
        public int ContractVersion { get; set; }

        public Position(int id,string positionName,int classify,int level,int levelSort,
            int classification,int directToPamPayroll,int withGovernmentBenefits,
            int payrollClassification,int classStoreBack,int update2Bio,
            string positionCode,int departmentId,int sectionId,string updatedBy,
            DateTime lastUpdated,int contractVersion)
        {
            this.Id = id;
            this.PositionName = positionName;
            this.Classify = classify;
            this.Level = level;
            this.LevelSort = levelSort;
            this.Classification = classification;
            this.DirectToPAMPayroll = directToPamPayroll;
            this.WithGovernmentBenefits = withGovernmentBenefits;
            this.PayrollClassification = payrollClassification;
            this.ClassStoreBack = classStoreBack;
            this.Update2Bio = update2Bio;
            this.PositionCode = positionCode;
            this.DepartmentId = departmentId;
            this.SectionId = sectionId;
            this.UpdatedBy = updatedBy;
            this.LastUpdated = lastUpdated;
            this.ContractVersion = contractVersion;
        }

        private static string QueryFilter() 
        {
            string query = "select isnull(PPositionIDNo,0)PPositionIDNo,isnull(PPositionName,'')PPositionName, " +
                               "isnull(PClassify,0)PClassify,isnull(PLevel,'')PLevel,isnull(PLevelSort,0)PLevelSort, " +
                               "isnull(PClassification,0)PClassification,isnull(PDirectToPAMPayroll,0)PDirectToPAMPayroll, " +
                               "isnull(PWithGovernmentBenefits,0)PWithGovernmentBenefits, " +
                               "isnull(PPayrollClassification,0)PPayrollClassification, " +
                               "isnull(PClassStore_Back,0)PClassStore_Back,isnull(Update2Bio,0)Update2Bio, " +
                               "isnull(PositionCode,'')PositionCode,isnull(DepartmentID,0)DepartmentID, " +
                               "isnull(SectionID,0)SectionID,isnull(UpdatedBy,'')UpdatedBy, " +
                               "isnull(LastUpdated,'1901-01-01')LastUpdated,isnull(ContractVersion,0)ContractVersion " +
                           "from PPositionName ";
            return query;
        }

        private static List<Position> GetDatas(Connection connection,string query) 
        {
            List<Position> result = new List<Position>();
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result.Add(new Position(Convert.ToInt32(d.Rows[i]["PPositionIDNo"]),d.Rows[i]["PPositionName"].ToString(),
                    Convert.ToInt32(d.Rows[i]["PClassify"]),Convert.ToInt32(d.Rows[i]["PLevel"]),Convert.ToInt32(d.Rows[i]["PLevelSort"]),
                    Convert.ToInt32(d.Rows[i]["PClassification"]),Convert.ToInt32(d.Rows[i]["PDirectToPAMPayroll"]),
                    Convert.ToInt32(d.Rows[i]["PWithGovernmentBenefits"]),Convert.ToInt32(d.Rows[i]["PPayrollClassification"]),
                    Convert.ToInt32(d.Rows[i]["PClassStore_Back"]),Convert.ToInt32(d.Rows[i]["Update2Bio"]),
                    d.Rows[i]["PositionCode"].ToString(),Convert.ToInt32(d.Rows[i]["DepartmentID"]),Convert.ToInt32(d.Rows[i]["SectionID"]),
                    d.Rows[i]["UpdatedBy"].ToString(),Convert.ToDateTime(d.Rows[i]["LastUpdated"]),Convert.ToInt32(d.Rows[i]["ContractVersion"])));
            }
            return result;
        }

        private static Position GetData(Connection connection,string query) 
        {
            Position result = null;
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result = new Position(Convert.ToInt32(d.Rows[i]["PPositionIDNo"]), d.Rows[i]["PPositionName"].ToString(),
                    Convert.ToInt32(d.Rows[i]["PClassify"]), Convert.ToInt32(d.Rows[i]["PLevel"]), Convert.ToInt32(d.Rows[i]["PLevelSort"]),
                    Convert.ToInt32(d.Rows[i]["PClassification"]), Convert.ToInt32(d.Rows[i]["PDirectToPAMPayroll"]),
                    Convert.ToInt32(d.Rows[i]["PWithGovernmentBenefits"]), Convert.ToInt32(d.Rows[i]["PPayrollClassification"]),
                    Convert.ToInt32(d.Rows[i]["PClassStore_Back"]), Convert.ToInt32(d.Rows[i]["Update2Bio"]),
                    d.Rows[i]["PositionCode"].ToString(), Convert.ToInt32(d.Rows[i]["DepartmentID"]), Convert.ToInt32(d.Rows[i]["SectionID"]),
                    d.Rows[i]["UpdatedBy"].ToString(), Convert.ToDateTime(d.Rows[i]["LastUpdated"]), Convert.ToInt32(d.Rows[i]["ContractVersion"]));
            }
            return result;
        }

        public static List<Position> GetAllPosition(Connection connection) 
        {
            return GetDatas(connection,QueryFilter());
        }
    }
}

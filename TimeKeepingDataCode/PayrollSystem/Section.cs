using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeKeepingDataCode.PayrollSystem
{
    public class Section
    {
        public int Id { get; set; }
        public string SectionName { get; set; }
        public string SectionCode { get; set; }
        public int DepartmentType { get; set; }
        public int Sort { get; set; }
        public int NoFloorAssign { get; set; }
        public int NoHeads { get; set; }
        public int Update2Bio { get; set; }
        public int PayrollDept { get; set; }
        public string SectionCodeNew { get; set; }
        public string UpdatedBy { get; set; }
        public string LastUpdated { get; set; }

        public Section(int id,string sectionName,string sectioncode,int departmentType,int sort,
            int noFloorAssign,int noHeads,int update2Bio,int payrollDept,string sectionCodeNew,
            string updatedBy,string lastUpdated)
        {
            this.Id = id;
            this.SectionName = sectionName;
            this.SectionCode = sectioncode;
            this.DepartmentType = departmentType;
            this.Sort = sort;
            this.NoFloorAssign = noFloorAssign;
            this.NoHeads = noHeads;
            this.Update2Bio = update2Bio;
            this.PayrollDept = payrollDept;
            this.SectionCodeNew = sectionCodeNew;
            this.UpdatedBy = updatedBy;
            this.LastUpdated = lastUpdated;
        }

        private static string QueryFilter() 
        {
            string query = "select isnull(a.SSectionID,0)SSectionID, " +
                               "isnull(a.SSectionName,'')SSectionName, " +
                               "isnull(a.SSectionCode,'000')SSectionCode, " +
                               "isnull(a.SDeptType,0)SDeptType, " +
                               "isnull(a.SSort,0)SSort, " +
                               "isnull(a.NoFloorAss,0)NoFloorAss, " +
                               "isnull(a.No_Heads,0)No_Heads, " +
                               "isnull(Update2Bio,0)Update2Bio, " +
                               "isnull(PayrollDept,0)PayrollDept, " +
                               "isnull(SectionCodeNew,'')SectionCodeNew, " +
                               "isnull(UpdatedBy,'')UpdatedBy, " +
                               "isnull(LastUpdated,'1901-01-01')LastUpdated " +
                           "from SSection a ";

            return query;
        }

        private static List<Section> GetDatas(Connection connection,string query) 
        {
            List<Section> result = new List<Section>();
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result.Add(new Section(Convert.ToInt32(d.Rows[i]["SSectionID"]), d.Rows[i]["SSectionName"].ToString(),
                    d.Rows[i]["SSectionCode"].ToString(), Convert.ToInt32(d.Rows[i]["SDeptType"]),
                    Convert.ToInt32(d.Rows[i]["SSort"]), Convert.ToInt32(d.Rows[i]["NoFloorAss"]),
                    Convert.ToInt32(d.Rows[i]["No_Heads"]), Convert.ToInt32(d.Rows[i]["Update2Bio"]),
                    Convert.ToInt32(d.Rows[i]["PayrollDept"]), d.Rows[i]["SectionCodeNew"].ToString(),
                    d.Rows[i]["UpdatedBy"].ToString(), d.Rows[i]["LastUpdated"].ToString()));
            }
            return result;
        }

        private static Section GetData(Connection connection,string query) 
        {
            Section result = null;
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result = new Section(Convert.ToInt32(d.Rows[i]["SSectionID"]), d.Rows[i]["SSectionName"].ToString(),
                    d.Rows[i]["SSectionCode"].ToString(), Convert.ToInt32(d.Rows[i]["SDeptType"]),
                    Convert.ToInt32(d.Rows[i]["SSort"]), Convert.ToInt32(d.Rows[i]["NoFloorAss"]),
                    Convert.ToInt32(d.Rows[i]["No_Heads"]), Convert.ToInt32(d.Rows[i]["Update2Bio"]),
                    Convert.ToInt32(d.Rows[i]["PayrollDept"]), d.Rows[i]["SectionCodeNew"].ToString(),
                    d.Rows[i]["UpdatedBy"].ToString(), d.Rows[i]["LastUpdated"].ToString());
            }
            return result;
        }

        public static List<Section> GetAllSections(Connection connection)
        {
            return GetDatas(connection,QueryFilter());
        }
    }
}

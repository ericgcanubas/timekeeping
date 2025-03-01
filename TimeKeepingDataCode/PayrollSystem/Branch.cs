using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeKeepingDataCode.PayrollSystem
{
    public class Branch
    {
        public string Section { get; private set; }
        public string Department { get; private set; }
        public string Area { get; private set; }
        public int SectionId { get; private set; }
        public int DepartmentId { get; private set; }
        public int Sort { get; private set; }

        public Branch(string section, string department, string area,
            int sectionId,int departmendId,int sort)
        {
            this.Section = section;
            this.Department = department;
            this.Area = area;
            this.SectionId = sectionId;
            this.DepartmentId = departmendId;
            this.Sort = sort;
        }

        public static List<Branch> GetBranch(Connection connection) 
        {
            List<Branch> result = new List<Branch>();
            string query = "select isnull(a.SSectionName,'')Section,isnull(b.BBranchName,'')Department, " +
	                              "isnull(c.Description,'')Area,isnull(a.SSectionID,0)SectionId, " +
	                              "isnull(b.BBranchIDNo,0)DepartmendId,isnull(a.SSort,0)Sort " +
                            "from SSection a " +
                            "join BBranch b on a.SDeptType = BBranchIDNo " +
                            "join EEmployeeDiv c on b.BDepartmentType = c.PK " +
                            "order by b.BBranchIDNo,a.SSort ";
            var resultData = connection.GetData(query);

            for (int i = 0; i < resultData.Rows.Count; i++)
            {
                result.Add(new Branch(resultData.Rows[i]["Section"].ToString(),
                    resultData.Rows[i]["Department"].ToString(), resultData.Rows[i]["Area"].ToString(),
                    Convert.ToInt32(resultData.Rows[i]["SectionId"]), Convert.ToInt32(resultData.Rows[i]["DepartmendId"]),
                    Convert.ToInt32(resultData.Rows[i]["Sort"])));
            }

            return result;
        }
    }
}

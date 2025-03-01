using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeKeepingDataCode.Biometrics
{
    public class UserRoles
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string Name { get; set; }
        public bool CanView { get; set; }
        public bool CanCreate { get; set; }
        public bool CanUpdate { get; set; }
        public bool CanDelete { get; set; }
        public bool CanPost { get; set; }
        public bool CanUnPost { get; set; }
        public bool CanGenerateReport { get; set; }

        public UserRoles(int userId,int id,string name,bool canView,bool canCreate,
            bool canUpdate,bool canDelete,bool canPost,bool canUnpost,
            bool canGenerateReport)
        {
            this.UserId = userId;
            this.RoleId = id;
            this.Name = name;
            this.CanView = canView;
            this.CanCreate = canCreate;
            this.CanUpdate = canUpdate;
            this.CanDelete = canDelete;
            this.CanPost = canPost;
            this.CanUnPost = canUnpost;
            this.CanGenerateReport = canGenerateReport;
        }

        private static string QueryFilter(FilterClause<int> userId) 
        {
            string userIdWhereClauser = string.Empty;

            if (userId.IsFilter)
                userIdWhereClauser = "  and a.UserId = " + userId.Value + " ";

            string query = "select isnull(a.UserId,0)UserId,b.Id,b.Description,isnull(a.CanView,0)CanView,isnull(a.CanCreate,0)CanCreate, " +
                                  "isnull(a.CanUpdate,0)CanUpdate,isnull(a.CanDelete,0)CanDelete, " +
                                  "isnull(a.CanPost,0)CanPost,isnull(a.CanUnPost,0)CanUnPost, " +
                                  "isnull(a.CanGenerateReport,0)CanGenerateReport " +
                           "from tbl_DRoles b " +
                           "left join tbl_DUserRoles a on a.RoleId = b.Id " + userIdWhereClauser;
            return query;
        }

        private static List<UserRoles> GetDatas(Connection connection,string query) 
        {
            List<UserRoles> result = new List<UserRoles>();
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result.Add(new UserRoles(Convert.ToInt32(d.Rows[i]["UserId"]), Convert.ToInt32(d.Rows[i]["Id"]), d.Rows[i]["Description"].ToString(),
                    Convert.ToBoolean(d.Rows[i]["CanView"]), Convert.ToBoolean(d.Rows[i]["CanCreate"]),
                    Convert.ToBoolean(d.Rows[i]["CanUpdate"]), Convert.ToBoolean(d.Rows[i]["CanDelete"]),
                    Convert.ToBoolean(d.Rows[i]["CanPost"]), Convert.ToBoolean(d.Rows[i]["CanUnPost"]),
                    Convert.ToBoolean(d.Rows[i]["CanGenerateReport"])));
            }
            return result;
        }

        private static UserRoles GetData(Connection connection,string query)
        {
            UserRoles result = null;
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result = new UserRoles(Convert.ToInt32(d.Rows[i]["UserId"]), Convert.ToInt32(d.Rows[i]["Id"]), d.Rows[i]["Description"].ToString(),
                    Convert.ToBoolean(d.Rows[i]["CanView"]), Convert.ToBoolean(d.Rows[i]["CanCreate"]),
                    Convert.ToBoolean(d.Rows[i]["CanUpdate"]), Convert.ToBoolean(d.Rows[i]["CanDelete"]),
                    Convert.ToBoolean(d.Rows[i]["CanPost"]), Convert.ToBoolean(d.Rows[i]["CanUnPost"]),
                    Convert.ToBoolean(d.Rows[i]["CanGenerateReport"]));
            }
            return result;
        }

        public static List<UserRoles> GetAllUserRoles(Connection connection) 
        {
            return GetDatas(connection,QueryFilter(new FilterClause<int>()));
        }

        public static List<UserRoles> GetAllUserRoles(Connection connection,int userId) 
        {
            return GetDatas(connection,QueryFilter(new FilterClause<int>(userId)));
        }

        public static List<UserRoles> EmptyUserRoles(Connection connection) 
        {
            string query = "select UserId = 0,Id,Description,CanView=0,CanCreate=0,CanUpdate=0, " +
	                              "CanDelete=0,CanPost=0,CanUnPost=0,CanGenerateReport=0 " +
                           "from tbl_DRoles ";
            return GetDatas(connection,query);
        }
    }
}

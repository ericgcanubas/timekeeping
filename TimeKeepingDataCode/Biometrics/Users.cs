using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeKeepingDataCode.Biometrics
{
    public class Users
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime DateAdded { get; set; }
        public string AddedBy { get; set; }

        public Users(int id,string firstName,string middleName,string lastName,
            string username,string password,DateTime dateAdded,string addedBy)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.UserName = username;
            this.Password = password;
            this.DateAdded = dateAdded;
            this.AddedBy = addedBy;
        }

        private static string QueryFilter(FilterClause<int> id,FilterClause<string> username) 
        {
            string idWhereClause = string.Empty;
            string usernameWhereClause = string.Empty;

            if (id.IsFilter)
                idWhereClause = " and Id = " + id.Value + " ";
            if (username.IsFilter)
                usernameWhereClause = " and Username = '" +  Connection.SqlString(username.Value) + "' ";

            string query = "SELECT Id,Firstname,Middlename,Lastname,Username, " +
                                  "Passwd,DateAdded,AddedBy " +
                           "FROM tbl_DUsers where 1=1 " + idWhereClause + usernameWhereClause;

            return query;
        }

        private static List<Users> GetDatas(Connection connection,string query) 
        {
            List<Users> result = new List<Users>();
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result.Add(new Users(Convert.ToInt32(d.Rows[i]["Id"]),d.Rows[i]["Firstname"].ToString(),
                    d.Rows[i]["Middlename"].ToString(),d.Rows[i]["Lastname"].ToString(),
                    d.Rows[i]["Username"].ToString(),d.Rows[i]["Passwd"].ToString(),
                    Convert.ToDateTime(d.Rows[i]["DateAdded"]),d.Rows[i]["AddedBy"].ToString()));
            }
            return result;
        }

        private static Users GetData(Connection connection,string query) 
        {
            Users result = null;
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result = new Users(Convert.ToInt32(d.Rows[i]["Id"]), d.Rows[i]["Firstname"].ToString(),
                    d.Rows[i]["Middlename"].ToString(), d.Rows[i]["Lastname"].ToString(),
                    d.Rows[i]["Username"].ToString(), d.Rows[i]["Passwd"].ToString(),
                    Convert.ToDateTime(d.Rows[i]["DateAdded"]), d.Rows[i]["AddedBy"].ToString());
            }
            return result;
        }

        public static List<Users> GetAllUsers(Connection connection) 
        {
            return GetDatas(connection,QueryFilter(new FilterClause<int>(),new FilterClause<string>()));
        }

        public static Users GetUser(Connection connection,int id) 
        {
            return GetData(connection,QueryFilter(new FilterClause<int>(id),new FilterClause<string>()));
        }

        public static Users GetUser(Connection connection, string username)
        {
            return GetData(connection, QueryFilter(new FilterClause<int>(), new FilterClause<string>(username)));
        }

        public static bool SaveCreatedUser(Connection connection,Users user,List<UserRoles> userRoles) 
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("insert tbl_DUsers (Firstname,Middlename,Lastname,Username,Passwd,AddedBy) " + 
                " values ('" + Connection.SqlString(user.FirstName) + "','" + Connection.SqlString(user.MiddleName) + "','" + 
                Connection.SqlString(user.LastName) + "','" + Connection.SqlString(user.UserName) + 
                "','" + Connection.SqlString(user.Password) + "','" + Connection.SqlString(user.AddedBy) + "') ");

            sb.Append("declare @userId int = (select MAX(Id) from tbl_DUsers) ");

            for (int i = 0; i < userRoles.Count; i++)
            {
                sb.Append("insert tbl_DUserRoles values (@userId," + userRoles[i].RoleId +",'" + userRoles[i].CanView + 
                          "','" + userRoles[i].CanCreate + "','" + userRoles[i].CanUpdate + "','" + userRoles[i].CanDelete + 
                          "','" + userRoles[i].CanPost + "','" + userRoles[i].CanUnPost + "','" + userRoles[i].CanGenerateReport + "') ");
            }

            return connection.Execute(sb.ToString());
        }

        public static bool SaveUpdatedUser(Connection connection, Users user, List<UserRoles> userRoles)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("update tbl_DUsers " +
                      "set Firstname='" + Connection.SqlString(user.FirstName) + "',Middlename='" + Connection.SqlString(user.MiddleName) + "', " +
	                      "Lastname='" + Connection.SqlString(user.LastName) + "',Username='" + Connection.SqlString(user.UserName) + "', " +
	                      "Passwd='" + Connection.SqlString(user.Password) + "' " +
                      "where Id=" + user.Id + " ");

            sb.Append("declare @tmpTable table(Id int,UserId int,RoleId int, " +
	                  "CanView bit,CanCreate bit,CanUpdate bit,CanDelete bit, " +
	                  "CanPost bit,CanUnPost bit,CanGenerateReport bit) ");

            for (int i = 0; i < userRoles.Count; i++)
            {
                sb.Append("insert @tmpTable values (0," + userRoles[i].UserId + "," + userRoles[i].RoleId + ",'" + userRoles[i].CanView + 
                          "','" + userRoles[i].CanCreate + "','" + userRoles[i].CanUpdate + "','" + userRoles[i].CanDelete + 
                          "','" + userRoles[i].CanPost + "','" + userRoles[i].CanUnPost + "','" + userRoles[i].CanGenerateReport + "') ");
            }

            sb.Append("delete a " +
                      "from tbl_DUserRoles a " +
                      "left join @tmpTable b on " +
	                      "a.UserId = b.UserId and a.RoleId = b.RoleId " +
                      "where a.UserId = " + user.Id + " and (b.UserId is null and b.RoleId is null) ");

            sb.Append("update a " +
                      "set a.CanView=b.CanView,a.CanCreate=b.CanCreate, " +
	                      "a.CanUpdate=b.CanUpdate,a.CanDelete=b.CanDelete, " +
	                      "a.CanPost=b.CanPost,a.CanUnPost=b.CanUnPost, " +
	                      "a.CanGenerateReport=b.CanGenerateReport " +
                      "from tbl_DUserRoles a " +
                      "join @tmpTable b on  " +
	                      "a.UserId = b.UserId and a.RoleId = b.RoleId ");

            sb.Append("insert tbl_DUserRoles " +
                      "select " + user.Id + ",b.RoleId,b.CanView,b.CanCreate, " +
	                         "b.CanUpdate,b.CanDelete,b.CanPost,b.CanUnPost, " +
	                         "b.CanGenerateReport " +
                      "from tbl_DUserRoles a " +
                      "right join @tmpTable b on " +
	                      "a.UserId = b.UserId and a.RoleId = b.RoleId " +
                      "where (a.UserId is null and a.RoleId is null) ");

            return connection.Execute(sb.ToString());
        }

        public static bool IsUsernameAlreadtExist(Connection connection,string username) 
        {
            TimeKeepingDataCode.Biometrics.Users u = TimeKeepingDataCode.Biometrics.Users.GetUser(connection,username);
            if (u != null)
                return true;
            else
                return false;
        }

        public static bool IsAuthenticate(Connection connection,string username,string password) 
        {
            bool result = false;
            
            Users user = GetUser(connection, username);
            if (user != null) {
                if (password.Equals(user.Password))
                    result = true;
            }

            return result;

        }
    }
}

using System;
using System.Text;

namespace TimeKeepingDataCode
{
    [Serializable]
    public class Connection
    {
        /// <summary>
        /// Constructor Connection Class para sa pag execute ug mga query
        /// </summary>
        /// <param name="server">server Name</param>
        /// <param name="database">Database Name</param>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        public Connection(string server, string database, string username, string password) 
        {
            this.Server = server;
            this.Database = database;
            this.Username = username;
            this.Password = password;
            this.connectionString = "Data Source=" + server +
                ";Initial Catalog=" + database +
                ";user=" + username + ";pwd=" + password + ";Connection Timeout=0;";
        }

        private string connectionString;
        public string Server { get; private set; }
        public string Database { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }

        /// <summary>
        /// Mothod Para sa mag select ug query.
        /// </summary>
        /// <param name="query">query string</param>
        /// <returns>DataTable type</returns>
        public System.Data.DataTable GetData(string query) 
        {
            StringBuilder finalQuery = new StringBuilder();
            finalQuery.Append("declare @transName varchar(50) = 'myTrans'; ");
            finalQuery.Append("begin transaction @transName ");
            finalQuery.Append("begin try ");
            finalQuery.Append(query + " ");
            finalQuery.Append("commit transaction @transName ");
            finalQuery.Append("end try ");
            finalQuery.Append("begin catch ");
            finalQuery.Append("rollback transaction @transName ");
            finalQuery.Append("DECLARE @ErrorMessage NVARCHAR(4000); ");
            finalQuery.Append("DECLARE @ErrorSeverity INT; ");
            finalQuery.Append("DECLARE @ErrorState INT; ");
            finalQuery.Append("SELECT @ErrorMessage = ERROR_MESSAGE(), ");
            finalQuery.Append("@ErrorSeverity = ERROR_SEVERITY(), ");
            finalQuery.Append("@ErrorState = ERROR_STATE(); ");
            finalQuery.Append("RAISERROR (@ErrorMessage,@ErrorSeverity,@ErrorState) ");
            finalQuery.Append("end catch ");
            System.Data.DataTable dt = new System.Data.DataTable();
            try
            {
                using (System.Data.SqlClient.SqlConnection con =
                    new System.Data.SqlClient.SqlConnection(this.connectionString))
                {
                    con.Open();
                    using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
                    {
                        cmd.CommandTimeout = 0;
                        cmd.Connection = con;
                        cmd.CommandText = finalQuery.ToString();
                        using (System.Data.SqlClient.SqlDataAdapter adp = new System.Data.SqlClient.SqlDataAdapter())
                        {
                            adp.SelectCommand = cmd;
                            adp.Fill(dt);
                        }
                    }
                }
                return dt;
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message,"Error..",System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error);
                return dt;
            }
        }

        /// <summary>
        /// Method Para sa pag execute ug query Ex.Delete,Update,
        /// </summary>
        /// <param name="query">query string</param>
        /// <returns>true kung success pag execute or false kung dili</returns>
        public bool Execute(string query) 
        {
            StringBuilder finalQuery = new StringBuilder();
            finalQuery.Append("declare @transName varchar(50) = 'myTrans'; ");
            finalQuery.Append("begin transaction @transName ");
            finalQuery.Append("begin try ");
            finalQuery.Append(query + " ");
            finalQuery.Append("commit transaction @transName ");
            finalQuery.Append("end try ");
            finalQuery.Append("begin catch ");
            finalQuery.Append("rollback transaction @transName ");
            finalQuery.Append("DECLARE @ErrorMessage NVARCHAR(4000); ");
            finalQuery.Append("DECLARE @ErrorSeverity INT; ");
            finalQuery.Append("DECLARE @ErrorState INT; ");
            finalQuery.Append("SELECT @ErrorMessage = ERROR_MESSAGE(), ");
            finalQuery.Append("@ErrorSeverity = ERROR_SEVERITY(), ");
            finalQuery.Append("@ErrorState = ERROR_STATE(); ");
            finalQuery.Append("RAISERROR (@ErrorMessage,@ErrorSeverity,@ErrorState) ");
            finalQuery.Append("end catch ");
            bool result = false;
            try
            {
                using (System.Data.SqlClient.SqlConnection con =
                    new System.Data.SqlClient.SqlConnection(this.connectionString))
                {
                    con.Open();
                    using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandText = finalQuery.ToString();
                        cmd.ExecuteNonQuery();
                        result = true;
                    }
                }
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Error..", System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error);
            }
            return result;
        }

        /// <summary>
        /// Method pang check sa connection
        /// </summary>
        /// <returns>true kung naay connection false kung wala</returns>
        public bool CheckConnection() 
        {
            bool result = false;
            try 
            {
                using (System.Data.SqlClient.SqlConnection con = 
                    new System.Data.SqlClient.SqlConnection(this.connectionString)) 
                {
                    con.Open();
                    result = true;
                }
            }
            catch
            {
                result = false;
            }

            return result;
        }

        /// <summary>
        /// Static Method pang check sa connection
        /// </summary>
        /// <param name="server">Server Name</param>
        /// <param name="database">Database Name</param>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <returns>true kung active ang connection false kung inactive</returns>
        public static bool IsActiveConnection(string server,string database,
            string username,string password) 
        {
            bool result = false;
            try {
                using (System.Data.SqlClient.SqlConnection conn = 
                    new System.Data.SqlClient.SqlConnection()) 
                {
                    conn.ConnectionString = "Data Source=" + server + ";Initial Catalog=" + 
                        database + ";user=" + username + ";pwd=" + password + "";
                    conn.Open();
                    result = true;
                }
            }
            catch { result = false; }
            return result;
        }

        public static string SqlString(string str) 
        {
            return str.Replace("'","''");
        }

        /// <summary>
        /// Get the current server date
        /// </summary>
        /// <returns>server date</returns>
        public DateTime ServerDate() 
        {
            var resultData = GetData("select GETDATE() SystemDate ");
            return Convert.ToDateTime(resultData.Rows[0]["SystemDate"]);
        }

        /// <summary>
        /// distructor
        /// </summary>
        ~Connection()
        {
            this.Database = null;
            this.Server = null;
            this.Username = null;
            this.Password = null;
            this.connectionString = null;
        }
    }
}

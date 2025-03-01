using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeKeepingDataCode.PayrollSystem
{
    public class Supplier
    {
        public int Id { get; set; }
        public string SupplierName { get; set; }

        public Supplier(int id,string supplierName)
        {
            this.Id = id;
            this.SupplierName = supplierName;
        }

        private static string QueryFilter(FilterClause<int> id,FilterClause<string> searchName) 
        {
            string pkWhereClause = string.Empty;
            string supplierNameWhereClause = string.Empty;

            if (id.IsFilter)
                pkWhereClause = " and Pk = " + id.Value + " ";
            if (searchName.IsFilter)
                supplierNameWhereClause = " and Supplier like '%" + Connection.SqlString(searchName.Value) + "%' ";

            string query = "SELECT PK,isnull(Supplier,'')Supplier " +
                           "FROM Supplier " +
                           "where 1=1 " + pkWhereClause + supplierNameWhereClause;  

            return query;
        }

        private static List<Supplier> GetDatas(Connection connection,string query) 
        {
            List<Supplier> result = new List<Supplier>();
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result.Add(new Supplier(Convert.ToInt32(d.Rows[i]["PK"]), d.Rows[i]["Supplier"].ToString()));
            }
            return result;
        }

        private static Supplier GetData(Connection connection,string query) 
        {
            Supplier result = null;
            var d = connection.GetData(query);
            for (int i = 0; i < d.Rows.Count; i++)
            {
                result = new Supplier(Convert.ToInt32(d.Rows[i]["PK"]), d.Rows[i]["Supplier"].ToString());
            }
            return result;
        }

        public static List<Supplier> GetAllSupplier(Connection connection) 
        {
            return GetDatas(connection,QueryFilter(new FilterClause<int>(),new FilterClause<string>()));
        }

        public static List<Supplier> SearchSupplier(Connection connection,string supplierName) 
        {
            return GetDatas(connection,QueryFilter(new FilterClause<int>(),new FilterClause<string>(supplierName)));
        }

        public static Supplier GetSupplier(Connection connection,int id) 
        {
            return GetData(connection,QueryFilter(new FilterClause<int>(id),new FilterClause<string>()));
        }
    }
}

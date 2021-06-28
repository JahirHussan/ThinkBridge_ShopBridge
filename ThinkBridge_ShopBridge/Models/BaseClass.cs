using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class BaseClass
    {
        //Constructor
        public BaseClass()
        {

        }
        public string GetConnectionstring()
        {
            return ConfigurationManager.ConnectionStrings["ShopBridge"].ToString();
        }

        public SqlConnection OpenConnection()
        {
            SqlConnection connection = new SqlConnection(GetConnectionstring());
            if (connection.State != ConnectionState.Open) connection.Open();
            return connection;
        }

        public void CloseConnection(SqlConnection connection)
        {
            if (connection.State != ConnectionState.Closed) connection.Close();
        }
    }
}

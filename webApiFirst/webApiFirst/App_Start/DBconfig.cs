using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webApiFirst.App_Start
{
    public class DBconfig
    {
        public static MySqlConnection register()
        {
            string connStr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DBconn"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connStr);
            return conn;
        }
    }
}
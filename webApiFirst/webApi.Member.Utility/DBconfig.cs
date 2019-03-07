using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webApi.Member.Utility.Domain
{
    class DBconfig
    {
        private static IConfiguration Configuration { get; set; }

        public static MySqlConnection register()
        {
            string connStr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DBconn"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connStr);
            return conn;
        }
    }
}

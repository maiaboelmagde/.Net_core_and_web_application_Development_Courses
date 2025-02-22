using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace TaskSolution
{
    static class ConnectionHelper
    {
        public static SqlConnection sqlCN;

        static ConnectionHelper()
        {
            sqlCN = new SqlConnection();
            sqlCN.ConnectionString = ConfigurationManager.ConnectionStrings["PubsCN"].ConnectionString;
        }
    }
}

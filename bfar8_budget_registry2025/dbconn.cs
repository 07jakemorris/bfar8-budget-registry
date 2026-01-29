using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bfar8_budget_registry2025
{
    internal class dbconn
    {
        private static string connectionString =
            "server=mysql-budgetregistry.alwaysdata.net;" +
            "database=budgetregistry_db_bfar8;" +
            "uid=budgetregistry;" +
            "pwd=abcxyz123$;" +
            "SslMode=Required;";

        // 🔹 GET CONNECTION METHOD
        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}

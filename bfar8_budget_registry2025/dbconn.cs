using MySql.Data.MySqlClient;

namespace bfar8_budget_registry2025
{
    internal class dbconn
    {
        // MySQL connection parameters
        private static readonly string server = "10.8.2.7";       // LAN IP of XAMPP
        private static readonly string database = "db_bfar8";     // Database name
        private static readonly string uid = "bfar8budget";       // MySQL username
        private static readonly string password = "";             // MySQL password
        private static readonly uint port = 3306;                 // MySQL port

        // Connection string
        private static readonly string connString =
            $"Server={server};Database={database};Uid={uid};Pwd={password};Port={port};";

        // Static method to get a new MySQL connection
        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connString);
        }
    }
}

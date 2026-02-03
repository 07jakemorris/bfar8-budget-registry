using MySql.Data.MySqlClient;

namespace bfar8_budget_registry2025
{
    internal class dbconn
    {
        // Database configuration
        public static string connString =
            @"Server=localhost;
            Port=3306;
            Database=db_bfar8;
            Uid=root;
            Pwd=;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connString);
        }
    }
}

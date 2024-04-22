using MySqlConnector;
using System.Data;

namespace TrailTents.Database
{
    public class Data
    {
        private string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=trailtents;";
        MySqlConnection connection;
        MySqlCommand command;

        public void OpenConnection()
        {
            connection = new MySqlConnection(connectionString);
            connection.Open();
        }
        public void CloseConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
        public MySqlDataReader SelectQuery(string query)
        {
            Console.WriteLine(query);

            OpenConnection();
            command = new MySqlCommand(query, connection);
            return command.ExecuteReader();
        }
        internal int NotSelectQuery(string query)
        {
            Console.WriteLine(query);

            try
            {
                OpenConnection();
                command = new MySqlCommand(query, connection);
                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return -1;
            }
        }
    }
}

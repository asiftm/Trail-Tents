﻿using MySqlConnector;
using System.Data;

namespace TrailTents.Database
{
    public class Data
    {
        private string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=trailtents;AllowZeroDateTime=True";
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
            OpenConnection();
            command = new MySqlCommand(query, connection);
            return command.ExecuteReader();
        }
        internal int NotSelectQuery(string query)
        {
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
        internal int NotSelectQueryWithLink(string query,string link)
        {
            try
            {
                OpenConnection();
                command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@DisplayImage", link);
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

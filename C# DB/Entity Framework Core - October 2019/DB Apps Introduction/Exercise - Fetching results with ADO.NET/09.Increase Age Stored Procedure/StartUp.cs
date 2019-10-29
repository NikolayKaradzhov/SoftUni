using System;
using System.Data;
using System.Data.SqlClient;

namespace _09.Increase_Age_Stored_Procedure
{
    public class StartUp
    {
        public static string connectionString = @"Server = BGL063; Database = MinionsDB; Integrated Security = true";
        public static SqlConnection connection = new SqlConnection(connectionString);

        public static void Main(string[] args)
        {
            int minionId = int.Parse(Console.ReadLine());

            using (connection)
            {
                connection.Open();

                SqlCommand command = new SqlCommand(Queries.UpdateAgeStoredProc, connection);

                using (command)
                {
                    command.ExecuteNonQuery();
                }

                command = new SqlCommand("usp_GetOlder", connection);

                using (command)
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", minionId);

                    command.ExecuteNonQuery();
                }

                command = new SqlCommand(Queries.SelectNameAgeQuery, connection);

                using (command)
                {
                    command.Parameters.AddWithValue("@Id", minionId);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string minionName = (string)reader[0];
                        int minionAge = (int)reader[1];

                        Console.WriteLine($"{minionName} - {minionAge} years old");
                    }
                }
            }
        }
    }
}
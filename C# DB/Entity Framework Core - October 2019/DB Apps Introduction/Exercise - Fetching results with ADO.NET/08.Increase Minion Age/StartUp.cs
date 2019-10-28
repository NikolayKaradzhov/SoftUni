namespace _08.Increase_Minion_Age
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;

    public class StartUp
    {
        public static string connectionString = @"Server = BGL063; Database = MinionsDB; Integrated Security = true";
        public static SqlConnection connection = new SqlConnection(connectionString);

        public static void Main()
        {
            List<int> ids = Console.ReadLine()
                .Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            using (connection)
            {
                connection.Open();

                SqlCommand command = new SqlCommand(Queries.UpdateMinionsQuery, connection);

                using (command)
                {
                    foreach (var id in ids)
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        command.ExecuteNonQuery();
                        command.Parameters.Clear();
                    }
                }

                SqlCommand newCommand = new SqlCommand(Queries.SelectMinionInformation, connection);

                using (newCommand)
                {
                    SqlDataReader reader = newCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        string minionName = (string)reader[0];
                        int minionAge = (int)reader[1];

                        Console.WriteLine($"{minionName} {minionAge}");
                    }
                }
            }
        }
    }
}